package score.app.ticket;


import java.io.UnsupportedEncodingException;

import org.apache.http.HttpResponse;
import org.apache.http.StatusLine;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.StrictMode;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.RadioGroup.OnCheckedChangeListener;
import android.widget.Toast;

public class M1_2viewissue extends Activity {
	

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m1_3);
		
		RadioGroup rag = (RadioGroup)findViewById(R.id.radioGroup1);
		rag.setOnCheckedChangeListener(new OnCheckedChangeListener() {

	        @Override
	        public void onCheckedChanged(RadioGroup group, int checkedId) {
	        	EditText text2 = (EditText)findViewById(R.id.txtnote);
	            switch(checkedId) {
	            case R.id.radio0:
	            	text2.setEnabled(false);
	            	text2.setText("");
	            	break;
	            case R.id.radio1:
	            	text2.setEnabled(true);
	            	break;
	            }
	        }
	    });
	}
	
	


	public void submit(View view) throws UnsupportedEncodingException{
		
		Bundle extras = getIntent().getExtras();
		
		String tc;
		SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(getApplicationContext());
        String tempValue= sharedPreferences.getString("name", "");
        //Toast.makeText(getApplicationContext(), tempValue, Toast.LENGTH_SHORT).show();
		
		tc = extras.getString("ticketcode").toString();
		String spn,tr,ts,tn,tti;
		EditText text1 = (EditText)findViewById(R.id.txtres);
		EditText text2 = (EditText)findViewById(R.id.txtnote);
		RadioButton rb1 = (RadioButton)findViewById(R.id.radio0);
		RadioButton rb2 = (RadioButton)findViewById(R.id.radio1);
		
		tr = text1.getText().toString();
		tn = text2.getText().toString();
		
		if (tr.equals("")){
			Toast.makeText(this,"Please enter information", Toast.LENGTH_SHORT).show();
			return;
		}
		
		if (android.os.Build.VERSION.SDK_INT > 9) {
			StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
			StrictMode.setThreadPolicy(policy);
		}
		if(rb1.isChecked() == true){
			ts = "Y";
			HttpClient client = new DefaultHttpClient();
			
			String url = "http://192.168.1.107/ws_tk/Default.aspx?Type=Support&"+"spn="+tempValue+"&"+"tr="+tr.replace(" ", "_")+"&ts="+ts.replace(" ", "_")+"&tn="+tn.replace(" ", "_")+"&ttid="+tc;
			//String encode_url=URLEncoder.encode(url,"UTF-8");
			HttpGet http = new HttpGet(url);
			try{
				
				HttpResponse response = client.execute(http);
				StatusLine status= response.getStatusLine();
				int statusCode = status.getStatusCode();
			}catch(Exception e){
				Log.e("AsycC1",e.toString());
			}
		}
		else if(rb2.isChecked() == true){
			ts = "N";
			HttpClient client = new DefaultHttpClient();
			
			String url = "http://192.168.1.107/ws_tk/Default.aspx?Type=Support&"+"spn="+tempValue+"&"+"tr="+tr.replace(" ", "_")+"&ts="+ts.replace(" ", "_")+"&tn="+tn.replace(" ", "_")+"&ttid="+tc;
			//String encode_url=URLEncoder.encode(url,"UTF-8");
			HttpGet http = new HttpGet(url);
			try{
				
				HttpResponse response = client.execute(http);
				StatusLine status= response.getStatusLine();
				int statusCode = status.getStatusCode();
			}catch(Exception e){
				Log.e("AsycC1",e.toString());
			}
		}
		
		Toast.makeText(this, "Insert Complete", Toast.LENGTH_SHORT).show();
		 Intent page = new Intent(M1_2viewissue.this, M1viewissue.class); 
		 startActivity(page);
		 finish();
		}
			
		
	

}
