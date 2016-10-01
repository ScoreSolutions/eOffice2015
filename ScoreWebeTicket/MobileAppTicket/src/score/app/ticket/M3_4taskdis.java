package score.app.ticket;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
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
import android.os.StrictMode;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class M3_4taskdis extends Activity {
	 Spinner spn1,spn2;
	 TextAdapter textadp;
	 TextAdapter1 textadp1;
	 Button submit;
	//private TextAdapter2 textadp2;
	ArrayList<HashMap<String, Object>> myArrList =new ArrayList<HashMap<String, Object>>();
	ArrayList<String> List =new ArrayList<String>();
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m3_5);
		caseSpinner();
		caseSpinner1();
	}
	public void caseSpinner(){
		spn1 = (Spinner) findViewById(R.id.spinner1);
		spn1.setClipToPadding(false);
		textadp = new TextAdapter(getApplicationContext());
		spn1.setAdapter(textadp);
		
		new LoadContentFromServer().execute();
		
		
		submit = (Button) findViewById(R.id.btnassignto);
		submit.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				
				SharedPreferences sharedPreferences1 = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
		        String code = sharedPreferences1.getString("tkcode", "");
		        
		        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
		        String tempValue = sharedPreferences.getString("name", "");
		        
		        String a = spn1.getSelectedItem().toString();
				String a2 = spn2.getSelectedItem().toString();
				String b = "=";
				String text3 = a.substring(a.indexOf(b)+1, a.length()-1);
				String text4 = a2.substring(a2.indexOf(b)+1, a2.length()-1);
				
				if (android.os.Build.VERSION.SDK_INT > 9) {
					StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
					StrictMode.setThreadPolicy(policy);
				}			
					HttpClient client = new DefaultHttpClient();
					
					String url = "http://192.168.1.107/ws_tk/Default.aspx?Type=Assignto&"+"asby="+tempValue+"&"+"asto="+text4+"&asres="+text3+"&ttid="+code;
					//String encode_url=URLEncoder.encode(url,"UTF-8");
					HttpGet http = new HttpGet(url);
					try{
						
						HttpResponse response = client.execute(http);
						StatusLine status= response.getStatusLine();
						int statusCode = status.getStatusCode();
					}catch(Exception e){
						Log.e("AsycC1",e.toString());
					}
					Toast.makeText(getApplicationContext(), "Insert Complete", Toast.LENGTH_SHORT).show();
					Intent page = new Intent(M3_4taskdis.this, M3taskdis.class);  
			        startActivity(page);
			        finish();
			}
		});
		
	}
	public void caseSpinner1(){
		spn2 = (Spinner) findViewById(R.id.Spinner2);
		spn2.setClipToPadding(false);
		textadp1 = new TextAdapter1(getApplicationContext());
		spn2.setAdapter(textadp1);
		
		new LoadContentFromServer().execute();

		
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
				convertView = inflater.inflate(R.layout.rowspiner1_m3, null);
			}
			
			TextView text1 = (TextView)convertView.findViewById(R.id.textView3);
			
			
			try {
				text1.setText(myArrList.get(position).get("create_by").toString());
				
			} catch(Exception e){
			}
			return convertView;
		}
	}
	class TextAdapter1 extends BaseAdapter{
		private Context mContext;

		public TextAdapter1(Context applicationContext) {
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
				convertView = inflater.inflate(R.layout.rowspiner2_m3, null);
			}
			
			TextView text2 = (TextView)convertView.findViewById(R.id.textView3);
			
			
			try {
				text2.setText(myArrList.get(position).get("create_by").toString());
			} catch(Exception e){
			}
			return convertView;
		}
	}
	class LoadContentFromServer extends AsyncTask<Object, Integer, Object>{
		SharedPreferences sharedPreferences1 = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
        String code = sharedPreferences1.getString("tkcode", "");
		
		@Override
		protected Object doInBackground(Object... params) {
			// TODO Auto-generated method stub
			String url = "http://192.168.1.107/WS_TK/?Type=staff&"+"tkid="+code;
			JSONObject data;
			JSONArray dataset;
			myArrList = new ArrayList<HashMap<String, Object>>();
			
			try {
				data = new JSONObject(getJSONUrl(url));
				dataset = data.getJSONArray("Ticket");
				myArrList = new ArrayList<HashMap<String,Object>>();
				List = new ArrayList<String>();
				HashMap<String, Object> map;
				for (int j = 0 ; j < dataset.length(); j ++){
					JSONObject c = dataset.getJSONObject(j);
					map = new HashMap<String, Object>();
					myArrList.add(map);
					map.put("create_by", c.getString("create_by").toString());					
					publishProgress(j);
					
				}
			} catch (Exception e) {
				// TODO: handle exception
			}
			return null;
		}
		
		@Override
		protected void onPostExecute(Object result){
			textadp.notifyDataSetChanged();
			textadp1.notifyDataSetChanged();
		}	
	}

	
}	
	