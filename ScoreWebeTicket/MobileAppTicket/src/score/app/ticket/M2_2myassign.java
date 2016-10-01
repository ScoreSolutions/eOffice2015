package score.app.ticket;

import org.apache.http.HttpResponse;
import org.apache.http.StatusLine;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class M2_2myassign extends Activity {
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m2_3);
		
		 final Button button = (Button) findViewById(R.id.button1);
         button.setOnClickListener(new View.OnClickListener() {
             public void onClick(View v) {
            	 Bundle extras = getIntent().getExtras();
         		String tkid = extras.getString("tkid1").toString();	
         		
         		EditText text1 = (EditText)findViewById(R.id.edtname);
         		EditText text2 = (EditText)findViewById(R.id.edtphone);
         		EditText text3 = (EditText)findViewById(R.id.edtmail);
         		EditText text4 = (EditText)findViewById(R.id.edtresolve);
         		String t1,t2,t3,t4;
         		t1 = text1.getText().toString();
         		t2 = text2.getText().toString();
         		t3 = text3.getText().toString();
         		t4 = text4.getText().toString();
         		
         		if (t1.equals("") || t2.equals("") || t3.equals("") || t4.equals("")){
         			Toast.makeText(getApplicationContext(),"Please enter information", Toast.LENGTH_SHORT).show();
       			return;
         		}
         		
         		if (android.os.Build.VERSION.SDK_INT > 9) {
         			StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
         			StrictMode.setThreadPolicy(policy);
         		}
         			HttpClient client = new DefaultHttpClient();
         			
         			String url = "http://192.168.1.107/ws_tk/Default.aspx?Type=cusdetail&"+"reso="+t4.replace(" ", "_")+"&"+"cusname="+t1.replace(" ", "_")+"&cusphone="+t2.replace(" ", "_")+"&cusmail="+t3.replace(" ", "*")+"&tkid="+tkid;
         			//String encode_url=URLEncoder.encode(url,"UTF-8");
         			HttpGet http = new HttpGet(url);
         			try{
         				
         				HttpResponse response = client.execute(http);
         				StatusLine status= response.getStatusLine();
         				int statusCode = status.getStatusCode();
         			}catch(Exception e){
         				Log.e("AsycC1",e.toString());
         			}
         		
         	 Toast.makeText(getApplicationContext(),"Insert Complete", Toast.LENGTH_SHORT).show();
         	 Intent page = new Intent(M2_2myassign.this, Mainmenu.class); 
         	 startActivity(page);
         	 finish();
             }
         });
	}
	
//	public void Reply(View v){
//		Bundle extras = getIntent().getExtras();
//		String tkid = extras.getString("tkid").toString();	
//		
//		EditText text1 = (EditText)findViewById(R.id.edtname);
//		EditText text2 = (EditText)findViewById(R.id.edtphone);
//		EditText text3 = (EditText)findViewById(R.id.edtmail);
//		EditText text4 = (EditText)findViewById(R.id.edtresolve);
//		String t1,t2,t3,t4;
//		t1 = text1.getText().toString();
//		t2 = text2.getText().toString();
//		t3 = text3.getText().toString();
//		t4 = text4.getText().toString();
//		
//		if (android.os.Build.VERSION.SDK_INT > 9) {
//			StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
//			StrictMode.setThreadPolicy(policy);
//		}
//			HttpClient client = new DefaultHttpClient();
//			
//			String url = "http://192.168.1.107/ws_tk/Default.aspx?Type=cusdetail&"+"reso="+t1.replace(" ", "_")+"&"+"cusname="+t2.replace(" ", "_")+"&cusphone="+t3.replace(" ", "_")+"&cusmail="+t4.replace(" ", "_")+"&tkid="+tkid;
//			//String encode_url=URLEncoder.encode(url,"UTF-8");
//			HttpGet http = new HttpGet(url);
//			try{
//				
//				HttpResponse response = client.execute(http);
//				StatusLine status= response.getStatusLine();
//				int statusCode = status.getStatusCode();
//			}catch(Exception e){
//				Log.e("AsycC1",e.toString());
//			}
//		
//	 Toast.makeText(this, "Insert Complete", Toast.LENGTH_SHORT).show();
//	 Intent page = new Intent(M2_2.this, M2myassign.class); 
//	 startActivity(page);
//	
//	}
		
	


}
