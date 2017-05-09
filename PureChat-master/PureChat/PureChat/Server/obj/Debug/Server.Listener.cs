using System.Collections.Generic;
using System.Net.Sockets; 

namespace middleware
{
	class MainClass
	{
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
	  
	        while (!done) {  
	            Console.Write("Waiting for connection...");  
	            TcpClient client = listener.AcceptTcpClient();  
	  
	            Console.WriteLine("Connection accepted.");  
	            NetworkStream ns = client.GetStream();  
	  
	            byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());  
	  
	            try {  
	                ns.Write(byteTime, 0, byteTime.Length);  
	                ns.Close();  
	                client.Close();  
	            } catch (Exception e) {  
	                Console.WriteLine(e.ToString());  
	            }  
	        }  
	  
	        listener.Stop(); 

		}
	}
}
