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

public class M3taskdis extends Activity {
	String s1,s2,s3,s4,s5,s6;
	private ListView lst;
	private TextAdapter textadp;
	ArrayList<HashMap<String, Object>> myArrList =new ArrayList<HashMap<String, Object>>();
	ArrayList<String> List = new ArrayList<String>();


	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m3_taskdis);
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
            
                Intent page = new Intent(M3taskdis.this, M3_1taskdis.class);    
                
                TextView des = (TextView)lst.getChildAt(position).findViewById(R.id.textView8);
                TextView tcode = (TextView)lst.getChildAt(position).findViewById(R.id.textView5);
                TextView pname = (TextView)lst.getChildAt(position).findViewById(R.id.textView6);
                TextView bname = (TextView)lst.getChildAt(position).findViewById(R.id.textView7);
                TextView tid = (TextView)lst.getChildAt(position).findViewById(R.id.textView9);
                
                s1 = tcode.getText().toString();
                s2 = pname.getText().toString();
                s3 = bname.getText().toString();
                s4 = des.getText().toString();
                s5 = tid.getText().toString();
                
                
//                s1 = myArrList.get(position).get("ticket_description").toString();
//                s2 = myArrList.get(position).get("ticket_code").toString();
//                s3 = myArrList.get(position).get("project_name").toString();
//                s4 = myArrList.get(position).get("branch_name").toString();
                                            		
               page.putExtra("ticketcode1",s1);
               page.putExtra("pname1",s2);
               page.putExtra("bname1",s3);
               page.putExtra("desc1",s4);
             
               
           	
   			SharedPreferences prefs1 = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
   	        SharedPreferences.Editor editor = prefs1.edit();
   	        editor.putString("tkcode",s5);
   	        editor.commit();
                
               startActivity(page);  
               finish();
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
				convertView = inflater.inflate(R.layout.rowlistview_m3, null);
			}
			
			TextView acc_id = (TextView)convertView.findViewById(R.id.textView1);
			TextView alram = (TextView)convertView.findViewById(R.id.textView3);
			TextView neww = (TextView)convertView.findViewById(R.id.textView4);
			
			TextView tic_des = (TextView)convertView.findViewById(R.id.textView2);
			
			TextView tco = (TextView)convertView.findViewById(R.id.textView5);
			TextView tic_des1 = (TextView)convertView.findViewById(R.id.textView8);
			TextView pnam = (TextView)convertView.findViewById(R.id.textView6);
			TextView bnam = (TextView)convertView.findViewById(R.id.textView7);
			TextView tid = (TextView)convertView.findViewById(R.id.textView9);
			
			tco.setVisibility(View.GONE);
			pnam.setVisibility(View.GONE);
			bnam.setVisibility(View.GONE);
			tic_des1.setVisibility(View.GONE);
			tid.setVisibility(View.GONE);

								
			acc_id.setText(myArrList.get(position).get("account_name").toString());
			alram.setText(myArrList.get(position).get("create_on").toString());
			
			tid.setText(myArrList.get(position).get("ticket_id").toString());
			tic_des.setText("กรุณากดเพื่อดูข้อมูลเพิ่ม");
			tic_des1.setText(myArrList.get(position).get("ticket_description").toString());
			tco.setText(myArrList.get(position).get("ticket_code").toString());
			pnam.setText(myArrList.get(position).get("project_code").toString());
			bnam.setText(myArrList.get(position).get("branch_name").toString());
			
			String tcode;
			tcode = myArrList.get(position).get("ticket_id").toString();
		
			String a;
			
			a = myArrList.get(position).get("statusticket_id").toString();
			if (a.equals("1")){
				neww.setTextColor(Color.parseColor("#FF0000"));
				neww.setText("New");
				convertView.setBackgroundColor(Color.parseColor("#FFFFFF"));
			}
			else{
				//convertView.setOnClickListener(null);
				neww.setTextColor(Color.parseColor("#FFFFFF"));
				neww.setText("Wait assign");
				convertView.setBackgroundColor(Color.parseColor("#C0C0C0"));
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
		SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
        String tempValue = sharedPreferences.getString("name", "");
		@Override
		protected Object doInBackground(Object... params) {
			// TODO Auto-generated method stub
			String url = "http://192.168.1.107/WS_TK/?Type=ticket2&"+"spn="+tempValue;
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
					if (c.getString("statusticket_id").toString().equals("1")){
					map = new HashMap<String, Object>();
					map.put("ticket_id", c.getInt("ticket_id"));
					map.put("account_name", c.getString("account_name").toString());
					map.put("ticket_description", c.getString("ticket_description").toString());
					map.put("create_on", c.getString("create_on").toString());
					map.put("ticket_code", c.getString("ticket_code").toString());
					map.put("project_code", c.getString("project_code").toString());
					map.put("branch_name", c.getString("branch_name").toString());
					map.put("statusticket_id", c.getString("statusticket_id").toString());
					myArrList.add(map);
					List.add(c.getString("account_name").toString());
					publishProgress(i);
					cnt = i ;
					}
				}
				
				for (int j = 0 ; j < dataset.length(); j ++){
					JSONObject d = dataset.getJSONObject(j);
					if (d.getString("statusticket_id").toString().equals("2")){
						
					map = new HashMap<String, Object>();
					map.put("ticket_id", d.getInt("ticket_id"));
					map.put("account_name", d.getString("account_name").toString());
					map.put("ticket_description", d.getString("ticket_description").toString());
					map.put("create_on", d.getString("create_on").toString());
					map.put("ticket_code", d.getString("ticket_code").toString());
					map.put("project_code", d.getString("project_code").toString());
					map.put("branch_name", d.getString("branch_name").toString());
					map.put("statusticket_id", d.getString("statusticket_id").toString());
					myArrList.add(map);
					List.add(d.getString("account_name").toString());
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
	

}
