package score.app.ticket;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;



public class TabsPagerAdapter extends FragmentPagerAdapter {

	public TabsPagerAdapter(FragmentManager fm) {
		super(fm);
	}

	public Fragment getItem(int index) {

		switch (index) {
		case 0:
			return new pageopen();
		case 1:
			return new pagewait();
		case 2:
			return new pageassign();
		case 3:
			return new pageclose();
		}

		return null;
	}

	public int getCount() {
		// get item count - equal to number of tabs
		return 4;
	}

}
