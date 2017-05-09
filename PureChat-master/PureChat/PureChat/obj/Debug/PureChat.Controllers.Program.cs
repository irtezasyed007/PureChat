using System.Collections.Generic;

namespace middleware
{
	class Program
	{
		static void Main(string[] args)
		{
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
		}
	}
}
