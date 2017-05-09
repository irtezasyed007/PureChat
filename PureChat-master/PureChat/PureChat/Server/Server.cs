using System;
using System.Collections.Generic;

namespace middleware
{
	class Server
	{
		/*
            Change users to a set         
         */
		private List<User> users;
		private List<Message> chatLog;
		private struct Message
		{
			public DateTime timestamp;
			public string content;
			public User owner;

			public override string ToString()
			{
				return String.Format("{0}({1}): {2}", this.owner, this.timestamp.ToString("h:mm:ss tt"), this.content);
			}
		}
		public Server(User owner)
		{
			users = new List<User>();
			users.Add(owner);

			chatLog = new List<Message>();
		}
		public void join(User user)
		{
			users.Add(user);
		}
		private void recieveMsg()
		{
			foreach (User user in users)
			{
				Message msg;
				msg.timestamp = DateTime.Now;
				msg.content = user.getMsg();
				msg.owner = user;
				chatLog.Add(msg);
			}
		}
		public void update()
		{
			recieveMsg();
		}
		public Stack<String> getChatLog()
		{
			Stack<string> result = new Stack<string>();
			foreach (Message msg in this.chatLog)
				result.Push(msg.ToString());
				
			return new Stack<string>();
		}
	}
}
