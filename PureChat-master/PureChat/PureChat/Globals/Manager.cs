using System;
using System.Collections.Generic;

namespace PureChat
{
	public class Manager
	{
		public static int attemptLogin(string username, string password) {
			string output = sendCommand(String.Format("login:{0},{1}", username, password));
			if (output == "success") return 0;
			return 1;
		}

		public static void loginOut() {
			//send logout statement
		}
		private static string sendCommand(string cmd) {
			return "success";
		}
	}
}
