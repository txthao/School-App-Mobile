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
	}
}

