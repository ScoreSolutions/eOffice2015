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

import score.app.ticket.M2myassign.LoadContentFromServer;
import score.app.ticket.M2myassign.TextAdapter;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.DialogInterface.OnClickListener;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity {
	private ListView lst;
	private TextAdapter textadp;
	ArrayList<HashMap<String, Object>> myArrList =new ArrayList<HashMap<String, Object>>();
	ArrayList<String> List =new ArrayList<String>();
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.login);	
		ImageButton login =(ImageButton)findViewById(R.id.imglogin);
		lst = (ListView)findViewById(R.id.listView3);
		lst.setClipToPadding(false);
		textadp = new TextAdapter(getApplicationContext());
		lst.setAdapter(textadp);
		final ProgressBar pg;
		pg = (ProgressBar)findViewById(R.id.progressBar1);
		pg.setVisibility(View.INVISIBLE);
		 SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
	        String tempValue = sharedPreferences.getString("name", "");
		if (tempValue != ""){
		Intent page = new Intent(MainActivity.this, Mainmenu.class);
		startActivity(page);
		finish();}
		
		
		login.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				pg.setVisibility(View.VISIBLE);
				new Thread(){
					public void run(){						
							try {
								ImageButton btnln = (ImageButton)findViewById(R.id.imglogin);							
								btnln.setEnabled(false);								
								EditText luser = (EditText)findViewById(R.id.txtuser);
								EditText lpass = (EditText)findViewById(R.id.txtcode);
								//luser.setEnabled(false);
								//lpass.setEnabled(false);
								new LoadContentFromServer().execute();
								sleep(1000);
								String logid = luser.getText().toString();
								String logpas = lpass.getText().toString();
								int i;			

								for (i = 0 ; i < myArrList.size(); i++){
									String u;
									String p;
									u = (String) myArrList.get(i).get("username").toString();
									p = (String) myArrList.get(i).get("pwd").toString();				
								if (u.equals(logid) && p.equals(logpas)){					
									Intent page = new Intent(MainActivity.this, Mainmenu.class);
									page.putExtra("uname",logid);
									SharedPreferences prefs = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
					                SharedPreferences.Editor editor = prefs.edit();
					                editor.putString("name",logid);
					                editor.commit();	
									startActivity(page);
									finish();
									return;
									}	
								else if(i == myArrList.size()-1){
									Intent page = new Intent(MainActivity.this, MainActivity.class);
									startActivity(page);
									finish();
								} 
																	
							}
								
							} catch (Exception e) {
						}
					}
				}.start();
							
			}
		});
		
	}
	
	@Override
	public void onBackPressed() {
		AlertDialog.Builder dialog = new AlertDialog.Builder(this);
        dialog.setTitle("Ticket App");
        dialog.setIcon(R.drawable.logo);
        dialog.setCancelable(true);
        dialog.setMessage("Do you want to exit?");
        dialog.setPositiveButton("Yes(いい)", new OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
            finish();
            }
        });
        
        dialog.setNegativeButton("No(だめ)", new OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });
        
        dialog.show();     
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
				convertView = inflater.inflate(R.layout.rowlogin, null);
				
				 //SharedPreferences sharedpreferences;
				// sharedpreferences = getSharedPreferences(MyPREFERENCES, Context.MODE_PRIVATE);
																														
				
//				u = (String) myArrList.get(position).get("username").toString();
//				p = (String) myArrList.get(position).get("pwd").toString();
																						
				
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
			String url = "http://192.168.1.107/WS_TK/?Type=user";
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
					map.put("username", c.getString("username").toString());
					map.put("pwd", c.getString("pwd").toString());
					myArrList.add(map);
					List.add(c.getString("username").toString());
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
