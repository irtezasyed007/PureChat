using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace Datalayer
{
	class Common
	{
		private readonly static string database = "chat";
		private readonly static string _conString = String.Format("server={0};User Id={1};password={2};database={3}", "localhost", "root", "", database);
		//this is microsoft's function
		public static string getMd5Hash(string input)
		{
			MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
			byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
				sBuilder.Append(data[i].ToString("x2"));
			return sBuilder.ToString();
		}

		public static DataSet select(string[] columns, string[] from, string where)
		{
			string columnsStr = String.Join(",", columns);
			string fromStr = String.Join(",", from);
			string whereStr = (where == null || where == "") ? "1" : where;

			string commandText = String.Format("SELECT {0} FROM {1} where {2};", columnsStr, fromStr, whereStr);
			MySqlDataAdapter dad = new MySqlDataAdapter(commandText, Common._conString);

			DataSet dst = new DataSet();
			using (dad)
				dad.Fill(dst);
			return dst;
		}

		public static int insert(string tableName, string[] columns, string[] values)
		{
			int error = 0;

			string columnStr = String.Join(",", columns);
			string valuesStr = "\"" + String.Join("\",\"", values) + "\"";

			MySqlConnection con = new MySqlConnection(Common._conString);
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			string sql = String.Format("INSERT INTO `{0}`.`{1}` ({2}) VALUES ({3});", database, tableName, columnStr, valuesStr);

			con.Open();

			try
			{
				adapter.InsertCommand = new MySqlCommand(sql, con);
				adapter.InsertCommand.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.WriteLine(sql);
				Console.WriteLine(e.ToString());
				error = 2;
			}
			con.Close();

			return error;
		}
	}
}