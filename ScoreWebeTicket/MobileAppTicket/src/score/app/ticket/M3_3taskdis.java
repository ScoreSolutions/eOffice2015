package score.app.ticket;

import android.app.Activity;
import android.os.Bundle;
import android.widget.TextView;

public class M3_3taskdis extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.m3_4);
		Bundle extras = getIntent().getExtras();
		
		TextView tc = (TextView)findViewById(R.id.txtres);
		TextView tp = (TextView)findViewById(R.id.txtnote);
		
		tc.setText(extras.getString("resol").toString());
		tp.setText(extras.getString("not").toString());
	}
	

}
