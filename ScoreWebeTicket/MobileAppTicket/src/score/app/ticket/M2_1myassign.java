package score.app.ticket;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class M2_1myassign extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m2_2);
		
		Bundle extras = getIntent().getExtras();
		
		TextView tc = (TextView)findViewById(R.id.edtproject);
		TextView tp = (TextView)findViewById(R.id.edtbranch);
		TextView tb = (TextView)findViewById(R.id.edtissue);
		TextView tm = (TextView)findViewById(R.id.edtresolve);
		TextView tm1 = (TextView)findViewById(R.id.textView5);
					
		tc.setText(extras.getString("proid").toString());
		tp.setText(extras.getString("braid").toString());
		tb.setText(extras.getString("descr").toString());
		tm.setText(extras.getString("asres").toString());
		tm1.setText(extras.getString("bsla").toString());
		
		final String tkid = extras.getString("tkid").toString();	
		
		  final Button button = (Button) findViewById(R.id.button1);
	         button.setOnClickListener(new View.OnClickListener() {
	             public void onClick(View v) {
	            	 Intent page = new Intent(M2_1myassign.this, M2_2myassign.class); 
	            	 	                 		
	                 page.putExtra("tkid1",tkid);
	                 
	            	 startActivity(page);
	            	 finish();

	             }
	         });
	}
	
}
