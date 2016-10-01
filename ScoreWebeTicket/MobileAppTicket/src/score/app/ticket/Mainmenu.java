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


import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;

import android.annotation.TargetApi;
import android.app.ActionBar;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ListView;
import android.widget.Toast;

public class Mainmenu extends Activity {
	private ListView lst;
	private TextAdapter textadp;
	ArrayList<HashMap<String, Object>> myArrList =new ArrayList<HashMap<String, Object>>();
	ArrayList<String> List =new ArrayList<String>();
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.mainmenu);
		lst = (ListView)findViewById(R.id.listView4);
		lst.setClipToPadding(false);
		textadp = new TextAdapter(getApplicationContext());
		lst.setAdapter(textadp);
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
            	android.os.Process.killProcess(android.os.Process.myPid());  
            	System.exit(0);}
        });
        
        dialog.setNegativeButton("No(だめ)", new OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });
        
        dialog.show();     
    } 
	
	public void Ibtn (View v){
		Intent myIntent = new Intent(getBaseContext(), M1viewissue.class);
		startActivity(myIntent);
	}
	public void Gabtn (View v){
		Intent myIntent = new Intent(getBaseContext(), M2myassign.class);
		startActivity(myIntent);
	}
	public void Abtn (View v){
		SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
        String tempValue= sharedPreferences.getString("name", "");
               
        new LoadContentFromServer().execute();
		
		int i;			

		for (i = 0 ; i < myArrList.size(); i++){
		String u;
		u = (String) myArrList.get(i).get("username").toString();
		if(tempValue.equals(u)){
		Intent myIntent = new Intent(getBaseContext(), M3taskdis.class);
		startActivity(myIntent);
		finish();
		return;}  
		else if(i == myArrList.size()-1){
			Intent page = new Intent(Mainmenu.this, Mainmenu.class);
			startActivity(page);
			finish();
			}	
		}
	}
	public void tbtn (View v){
		Intent myIntent = new Intent(getBaseContext(), M4viewstatus.class);
		startActivity(myIntent);
	}
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.menu1, menu);
		return true;
	}
	//On selecting action bar icons
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Take appropriate action for each action item click
		ActionBar mActionbar;
		switch (item.getItemId()) {
		
			/*Actionbar menu*/
			case R.id.action_settings2://here very **important**| select res/menu/__this activity.xml__ >>(1) add upper^
					//set to default page//
				
				SharedPreferences prefs = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
                SharedPreferences.Editor editor = prefs.edit();
                editor.putString("name","");
                editor.commit();
					
					Intent intent = new Intent(getApplicationContext(), MainActivity.class);
					intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
					startActivity(intent);
					//END set to default page//
				return true;
				
			default:
				return super.onOptionsItemSelected(item);
		}
	}
	
	@TargetApi(Build.VERSION_CODES.HONEYCOMB)
	private void setupActionBar() {
		if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB) {
			getActionBar().setDisplayHomeAsUpEnabled(true);
		}
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
			String url = "http://192.168.1.107/WS_TK/?Type=specialist";
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

