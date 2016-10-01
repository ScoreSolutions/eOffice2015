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

import score.app.ticket.M1viewissue.LoadContentFromServer;
import score.app.ticket.M1viewissue.TextAdapter;






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
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;

public class M2myassign extends Activity {
	String s1,s2,s3,s4,s5,s6;
	private ListView lst;
	private TextAdapter textadp;
	ArrayList<HashMap<String, Object>> myArrList =new ArrayList<HashMap<String, Object>>();
	ArrayList<String> List =new ArrayList<String>();


	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m2_myassign);
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
            try{
                Intent page = new Intent(M2myassign.this, M2_1myassign.class); 
                       
                TextView pro1 = (TextView)lst.getChildAt(position).findViewById(R.id.textView5);
                TextView bra1 = (TextView)lst.getChildAt(position).findViewById(R.id.textView6);
                TextView des1 = (TextView)lst.getChildAt(position).findViewById(R.id.textView7);
                TextView res1 = (TextView)lst.getChildAt(position).findViewById(R.id.textView8);
                TextView sla1 = (TextView)lst.getChildAt(position).findViewById(R.id.textView9);
                TextView tkid1 = (TextView)lst.getChildAt(position).findViewById(R.id.textView10);
                
                s1 = pro1.getText().toString();
                s2 = bra1.getText().toString();
                s3 = des1.getText().toString();
                s4 = res1.getText().toString();
                s5 = sla1.getText().toString();
                s6 = tkid1.getText().toString();
                
                page.putExtra("proid",s1);
                page.putExtra("braid",s2);
                page.putExtra("descr",s3);
                page.putExtra("asres",s4);
                page.putExtra("bsla",s5);
                page.putExtra("tkid",s6);
                                           	
               startActivity(page);
               finish();
            } catch (Exception e) {
            	
        		Toast.makeText(getApplicationContext(), e.getStackTrace().toString(),Toast.LENGTH_LONG).show();
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
				convertView = inflater.inflate(R.layout.rowlistview_m1_m2, null);
			}
			
			TextView tco = (TextView)convertView.findViewById(R.id.textView1);
			TextView tic_des = (TextView)convertView.findViewById(R.id.textView2);
			TextView alram = (TextView)convertView.findViewById(R.id.textView3);
			TextView stid = (TextView)convertView.findViewById(R.id.textView4);
			
			TextView pro = (TextView)convertView.findViewById(R.id.textView5);
			TextView bra = (TextView)convertView.findViewById(R.id.textView6);
			TextView des = (TextView)convertView.findViewById(R.id.textView7);
			TextView res = (TextView)convertView.findViewById(R.id.textView8);
			TextView sla = (TextView)convertView.findViewById(R.id.textView9);
			TextView tkid = (TextView)convertView.findViewById(R.id.textView10);
						
			pro.setVisibility(View.GONE);
			bra.setVisibility(View.GONE);
			des.setVisibility(View.GONE);
			res.setVisibility(View.GONE);
			sla.setVisibility(View.GONE);
			tkid.setVisibility(View.GONE);
			
			tkid.setText(myArrList.get(position).get("ticket_id").toString());
			tco.setText(myArrList.get(position).get("account_name").toString());
			tic_des.setText("กรุณาคลิกเพื่อดูข้อมูลเพิ่มเติม");
			alram.setText(myArrList.get(position).get("create_on").toString());
			pro.setText(myArrList.get(position).get("project_name").toString());
			bra.setText(myArrList.get(position).get("branch_name").toString());
			des.setText(myArrList.get(position).get("assign_resolved").toString());
			res.setText(myArrList.get(position).get("ticket_description").toString());
			sla.setText(myArrList.get(position).get("branch_sla").toString());
			
			stid.setTextColor(Color.parseColor("#FF0000"));
			stid.setText("New");
			            
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
        String tempValue= sharedPreferences.getString("name", "");
		@Override
		protected Object doInBackground(Object... params) {
			// TODO Auto-generated method stub
			String url = "http://192.168.1.107/WS_TK/?Type=myassign&"+"astoMA="+tempValue;
			JSONObject data ;
			JSONArray dataset;
			try {
				data = new JSONObject(getJSONUrl(url));
				dataset = data.getJSONArray("Ticket");
				myArrList = new ArrayList<HashMap<String,Object>>();
				List = new ArrayList<String>();
				HashMap<String, Object> map;
				for (int i = 0 ; i < dataset.length(); i ++){
					JSONObject c = dataset.getJSONObject(i);
					map = new HashMap<String, Object>();
					map.put("ticket_id", c.getString("ticket_id").toString());
					map.put("account_name", c.getString("account_name").toString());
					map.put("ticket_description", c.getString("ticket_description").toString());
					map.put("create_on", c.getString("create_on").toString());
					map.put("statusticket_id", c.getString("statusticket_id").toString());
					map.put("project_name", c.getString("project_name").toString());
					map.put("branch_name", c.getString("branch_name").toString());
					map.put("assign_resolved", c.getString("assign_resolved").toString());
					map.put("branch_sla", c.getString("branch_sla").toString());
					myArrList.add(map);
					List.add(c.getString("ticket_id").toString());
					publishProgress(i);
					
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