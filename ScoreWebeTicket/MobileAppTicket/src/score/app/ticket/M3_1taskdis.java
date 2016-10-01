package score.app.ticket;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class M3_1taskdis extends Activity {
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m3_2);
		Bundle extras = getIntent().getExtras();
		
		TextView tc = (TextView)findViewById(R.id.txtcode);
		TextView tp = (TextView)findViewById(R.id.txtpro);
		TextView tb = (TextView)findViewById(R.id.txtbranch);
		TextView tm = (TextView)findViewById(R.id.txtmess);
					
		tc.setText(extras.getString("ticketcode1").toString());
		tp.setText(extras.getString("pname1").toString());
		tb.setText(extras.getString("bname1").toString());
		tm.setText(extras.getString("desc1").toString());
		
	
		 
		  final Button button = (Button) findViewById(R.id.btnreply);
	         button.setOnClickListener(new View.OnClickListener() {
	             public void onClick(View v) {
	            	 Intent page = new Intent(M3_1taskdis.this, M3_2taskdis.class); 
	            	 startActivity(page);
	            	 finish();

	             }
	         });
	}

}
