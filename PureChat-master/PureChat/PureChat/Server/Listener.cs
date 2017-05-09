using System.Collections.Generic;
using System.Net.Sockets;
using System;
using System.Text;  

//thoughts
//more thoughts
//add comments of thoughts
//fin.

namespace middleware
{
	class Listener
	{
		private static IDictionary<string,User> users = new Dictionary<string, User>();
		private static List<Server> servers = new List<Server>();
		private const int portNum = 8080;
		public static void Main(string[] args)
		{/*
			User u1 = User.login("john", "pass");
			User u2 = User.login("bill", "pass");
			//if (u1 == null)
			//	Console.WriteLine("not valid login");

			Server s = new Server(u1);
			s.join(u2);

			u1.sendMessage("HI");
			u1.sendMessage("bye");
			u2.sendMessage("fill");
			u1.sendMessage("will");
			u2.sendMessage("wow");

			s.update();

			Stack<string> log = s.getChatLog();
			//while (log.Count() > 0)
			//	Console.WriteLine(log.Pop());
			//	Console.Read();
*/


			bool done = false;


			TcpListener listener = new TcpListener(portNum);

			listener.Start();

			while (!done)
			{
				Console.Write("Waiting for connection...");
				TcpClient client = listener.AcceptTcpClient();

				Console.WriteLine("Connection accepted.");
				NetworkStream ns = client.GetStream();

				byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
				String buf = null;

				//read first
				try
				{
					byte[] bytes = new byte[1024];
					int bytesRead = ns.Read(bytes, 0, bytes.Length);
					buf = Encoding.ASCII.GetString(bytes, 0, bytesRead);
					Console.WriteLine(buf);

				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}


				//switch statement based on input
				buf = decision(buf)+'\n';


				//write response
				try
				{
					ns.Write(Encoding.ASCII.GetBytes(buf), 0, buf.Length);
					Console.WriteLine(buf);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
				ns.Close();
				client.Close();
			}


			listener.Stop();

		}
		private static string decision(string input)
		{
			input = input.Remove(input.Length-1);
			User u;
			string[] args = input.Split(':');
			switch (args[0]) { 
				case "login":
					String[] credientials = args[1].Split(',');
					u = User.login(credientials[0], credientials[1]);
					if (u != null)
						users.Add(u.getId().ToString(), u);
					else return "invalid credientials";
					break;
				case "sendMsg":
					String[] msg = args[1].Split(',');//"userid,content"
					users[msg[0]].sendMessage(msg[1]);
					break;
				case "newServer":
					String userId = args[1];
					u = users[userId];
					if (u != null)
						servers.Add(new Server(u));
					else return "invalid credientials";
					break;
				//add the join case	
			}
			return "success";
		}
	}
}
