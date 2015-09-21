using System;

namespace School.Droid
{
	public class Common
	{
		public static string checkSpaceValue(string text){
			
			if (text.Equals ("&nbsp;")) {
				return "";
			}
			return text;
		}

		public static string calPercent(int tiLe){


			return (100-tiLe).ToString()+"/"+tiLe;
		}
	}
}

