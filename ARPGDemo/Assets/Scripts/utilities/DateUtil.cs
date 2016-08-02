using UnityEngine;
using System.Collections;

public static class DateUtil {
	public static string GetTimeStrFromSecs(float secs){
		int h = 0;
		int m = 0;
		int s = (int)secs;

		if (secs >= 60) {
			m = s / 60;
			s = s % 60;
		}
		if (m >= 60) {
			h = m / 60;
			m = m % 60;
		}
		return string.Format ("{0:D2}:{1:D2}:{2:D2}", h, m, s);
	}
}
