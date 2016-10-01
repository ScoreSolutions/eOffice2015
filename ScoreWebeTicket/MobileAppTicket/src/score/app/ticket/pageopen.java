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

import android.support.v4.app.Fragment;
import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ListView;
import android.widget.TextView;

public class pageopen extends Fragment {
	private ListView lst;
	private TextAdapter textadp;
	ArrayList<HashMap<String, Object>> myArrList =new ArrayList<HashMap<String, Object>>();
	ArrayList<String> List =new ArrayList<String>();

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater.inflate(R.layout.fragment_open, container, false);
		lst = (ListView) rootView.findViewById(R.id.listView1);
        	
		lst.setClipToPadding(false);
		textadp = new TextAdapter(getActivity());
		lst.setAdapter(textadp);
		new LoadContentFromServer().execute();
		return rootView;
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
				convertView = inflater.inflate(R.layout.rowstatus, null);
			}
			
			TextView tcode = (TextView)convertView.findViewById(R.id.textView1);
			TextView tdes = (TextView)convertView.findViewById(R.id.textView2);
			TextView tstate = (TextView)convertView.findViewById(R.id.textView3);
			TextView tdate = (TextView)convertView.findViewById(R.id.textView4);
			
			tcode.setText(myArrList.get(position).get("ticket_code").toString());
			tdes.setText(myArrList.get(position).get("ticket_description").toString());
			tstate.setText(myArrList.get(position).get("statusticket_name").toString());
			tdate.setText(myArrList.get(position).get("create_on").toString());
//			
//			if (myArrList.get(position).get("statusticket_name").toString().equals("Open")){
//			convertView.setBackgroundColor(Color.parseColor("#FF4040"));
//			}					
		
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
			String url = "http://192.168.1.107/WS_TK/?Type=ticket";
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
					if (c.getString("statusticket_name").toString().equals("New")){
					map = new HashMap<String, Object>();
					map.put("create_on", c.getString("create_on").toString());
					map.put("ticket_code", c.getString("ticket_code").toString());
					map.put("ticket_description", c.getString("ticket_description").toString());
					map.put("statusticket_name", c.getString("statusticket_name").toString());
					myArrList.add(map);
					List.add(c.getString("ticket_code").toString());
					publishProgress(i);
					}
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
