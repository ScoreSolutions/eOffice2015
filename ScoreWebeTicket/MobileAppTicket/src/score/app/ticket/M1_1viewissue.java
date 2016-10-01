package score.app.ticket;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class M1_1viewissue extends Activity {
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m1_2);		
		
		Bundle extras = getIntent().getExtras();
		
		final TextView tc = (TextView)findViewById(R.id.txtcode);
		TextView tp = (TextView)findViewById(R.id.txtpro);
		TextView tb = (TextView)findViewById(R.id.txtbranch);
		TextView tm = (TextView)findViewById(R.id.txtmess);
					
		tc.setText(extras.getString("ticketcode").toString());
		tp.setText(extras.getString("pname").toString());
		tb.setText(extras.getString("bname").toString());
		tm.setText(extras.getString("desc").toString());
		
		
							
		  final Button button = (Button) findViewById(R.id.btnreply);
	         button.setOnClickListener(new View.OnClickListener() {
	             public void onClick(View v) {
	            	
	            		 Intent page = new Intent(M1_1viewissue.this, M1_2viewissue.class); 
		            	 
		            	 String s1 = tc.getText().toString();           		
		                 page.putExtra("ticketcode",s1);
		                 
		            	 startActivity(page);
		            	 finish();
	            	 

	             }
	         });
	}
	
}
