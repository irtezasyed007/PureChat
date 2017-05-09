using System;
using System.Data;

namespace Datalayer
{
	public class AccountDataSet
	{
		public static int verifyAccount(string username, string password)
		{
			password = Common.getMd5Hash(password);
			//string commandText = "SELECT * FROM accounts where `account_username`='" + username + "' and `account_password`='" + password + "'";

			string[] columns = { "*" };
			string[] from = { "accounts" };
			string where = "`account_username`='" + username + "' and `account_password`='" + password + "'";

			DataSet dst = Common.select(columns, from, where);
			return (dst.Tables[0].Rows.Count > 0) ? (int)(dst.Tables[0].Rows[0].ItemArray[0]) : -1;
		}
		public static int createAccount(string username, string password)
		{
			password = Common.getMd5Hash(password);
			//"INSERT INTO `chat`.`accounts` (`account_username`, `account_password`) VALUES ('" + username + "', '" + password + "');";

			string[] columns = { "account_username", "account_password" };
			string[] values = { username, password };
			return Common.insert("accounts", columns, values);
		}

		static void Main(string[] args)
		{ 
		
		}
	}
}