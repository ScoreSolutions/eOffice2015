package score.app.ticket;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;



import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.StatusLine;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.json.JSONArray;
import org.json.JSONObject;



import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Toast;

public class M3_2taskdis extends Activity {
	String s1,s2;
	private ListView lst;
	private TextAdapter textadp;
	ArrayList<HashMap<String, Object>> myArrList =new ArrayList<HashMap<String, Object>>();
	ArrayList<String> List =new ArrayList<String>();
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m3_3);
		caseListView();
	}
	public void caseListView(){
		lst = (ListView)findViewById(R.id.listView3);
		lst.setClipToPadding(false);
		textadp = new TextAdapter(getApplicationContext());
		lst.setAdapter(textadp);
		lst.setOnItemClickListener(new OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position,
                    long id) {
            	
           	try {
            
                Intent page = new Intent(M3_2taskdis.this, M3_3taskdis.class);    
                
              
           	 TextView stre = (TextView)lst.getChildAt(position).findViewById(R.id.textView5);
             TextView stn = (TextView)lst.getChildAt(position).findViewById(R.id.textView8);
             
             s1 = stre.getText().toString();
             s2 = stn.getText().toString();
        	 
        	  page.putExtra("resol",s1);
              page.putExtra("not",s2);
                
               startActivity(page);
            	} catch (Exception e) {
            		Toast.makeText(getApplicationContext(), "Error Program don't know why",Toast.LENGTH_LONG).show();
    			}
            }
        });
		new LoadContentFromServer().execute();
	}
	class TextAdapter extends BaseAdapter{
		private Context mContext;
		
		public TextAdapter(Context applicationContext) {
			// TODO Auto-generated constructor stub
			mContext = applicationContext;
		}

		@Override
		public int getCount() {
			// TODO Auto-generated method stub
			return myArrList.size();
		}

		@Override
		public Object getItem(int arg0) {
			// TODO Auto-generated method stub
			return myArrList.get(arg0);
		}

		@Override
		public long getItemId(int arg0) {
			// TODO Auto-generated method stub
			return arg0;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent) {
			// TODO Auto-generated method stub
			LayoutInflater inflater = (LayoutInflater)mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			if (convertView == null){
				convertView = inflater.inflate(R.layout.row_m3_2, null);
			}
			
			TextView stname = (TextView)convertView.findViewById(R.id.textView1);
			TextView stdes = (TextView)convertView.findViewById(R.id.textView2);
			TextView ststate = (TextView)convertView.findViewById(R.id.textView3);
			
			
			TextView stres = (TextView)convertView.findViewById(R.id.textView5);
			TextView stnot = (TextView)convertView.findViewById(R.id.textView8);
			TextView delete1 = (TextView)convertView.findViewById(R.id.textView6);
			TextView delete2 = (TextView)convertView.findViewById(R.id.textView7);
			
			stres.setVisibility(View.GONE);
			stnot.setVisibility(View.GONE);
			delete1.setVisibility(View.GONE);
			delete2.setVisibility(View.GONE);
			

								
			stname.setText(myArrList.get(position).get("create_by").toString());
			stdes.setText("คลิกเพื่อดูเพิ่มเติม");
						
			stres.setText(myArrList.get(position).get("resolve").toString());
			stnot.setText(myArrList.get(position).get("note").toString());
			
			
//			String tc = (String) myArrList.get(position).get("ticket_code");
//			String pn = (String) myArrList.get(position).get("project_name");
//			String bn = (String) myArrList.get(position).get("branch_name");
			
			String a;
			
			a = myArrList.get(position).get("status_specialist").toString();
			if (a.equals("Y")){
				ststate.setTextColor(Color.GREEN);
				ststate.setText("Avaliable");
			}
			else{
				//convertView.setOnClickListener(null);
				ststate.setTextColor(Color.RED);
				ststate.setText("Busy");
			}

			
			return convertView;
		}
}
	public String getJSONUrl(String url){
		StringBuilder str = new StringBuilder();
		HttpClient client = new DefaultHttpClient();
		HttpGet httpGet = new HttpGet(url);
		try {
			HttpResponse res = client.execute(httpGet);
			StatusLine status= res.getStatusLine();
			int statusCode = status.getStatusCode();
			if (statusCode == 200){
				HttpEntity entity = res.getEntity();
				InputStream content = entity.getContent();
				BufferedReader reader =  new BufferedReader(new InputStreamReader(content));
				String line;
				while((line = reader.readLine()) != null){
					str.append(line);
				}
			}else{
				Log.e("error","Failed to connected..");
			}
			
		} catch (Exception e) {
			// TODO: handle exception
		}
		return str.toString();
	}
	
	class LoadContentFromServer extends AsyncTask<Object, Integer, Object>{
		@Override
		protected Object doInBackground(Object... params) {
			// TODO Auto-generated method stub
			SharedPreferences sharedPreferences1 = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
	        String code = sharedPreferences1.getString("tkcode", "");
	        
			String url = "http://192.168.1.107/WS_TK/?Type=tkspec&"+"tkid="+code;
			JSONObject data ;
			JSONArray dataset;
			try {
				data = new JSONObject(getJSONUrl(url));
				dataset = data.getJSONArray("Ticket");
				myArrList = new ArrayList<HashMap<String,Object>>();
				List = new ArrayList<String>();
				HashMap<String, Object> map;
				int cnt =0;
				for (int i = 0 ; i < dataset.length(); i ++){
					JSONObject c = dataset.getJSONObject(i);
					if (c.getString("status_specialist").toString().equals("Y")){
					map = new HashMap<String, Object>();
					map.put("create_by", c.getString("create_by").toString());
					map.put("resolve", c.getString("resolve").toString());
					map.put("note", c.getString("note").toString());
					map.put("status_specialist", c.getString("status_specialist").toString());
					myArrList.add(map);
					List.add(c.getString("create_by").toString());
					publishProgress(i);
					cnt = i ;
					}
				}
				
				for (int j = 0 ; j < dataset.length(); j ++){
					JSONObject d = dataset.getJSONObject(j);
					if (d.getString("status_specialist").toString().equals("N")){
						map = new HashMap<String, Object>();
						map.put("create_by", d.getString("create_by").toString());
						map.put("resolve", d.getString("resolve").toString());
						map.put("note", d.getString("note").toString());
						map.put("status_specialist", d.getString("status_specialist").toString());
						myArrList.add(map);
						List.add(d.getString("create_by").toString());
					publishProgress(cnt+j);
					}
					
				}
				
			} catch (Exception e) {
				// TODO: handle exception
			}
			return null;
		}
		
		@Override
		protected void onPostExecute(Object result){
			textadp.notifyDataSetChanged();
		}	
	}
	
	public void Onassign (View view){
		Intent page = new Intent(M3_2taskdis.this, M3_4taskdis.class);  
        startActivity(page);    

	}
	

}
