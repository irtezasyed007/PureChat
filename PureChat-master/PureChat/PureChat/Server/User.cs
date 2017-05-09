using Datalayer;

namespace middleware
{
    class User
    {
		private int id;
        private string message;
        private string name;
        private User(int id, string name)
        {
			this.id = id;
            this.name = name;
            this.message = "";
        }
        public void sendMessage(string msg)
        {
            this.message += msg + "\n";
        }
        public string getMsg()
        {
            string tmp = this.message;
            this.message = "";
            return tmp;
        }
        public string peekMsg()
        {
            return this.message;
        }
        public override string ToString()
        {
            return name;
        }
        public static User login(string username, string password) {
			int id = AccountDataSet.verifyAccount(username, password);
			//use database things to do checks here
			if (id == -1) return null;
			return new User(id, username);
        }
		public int getId() {
			return id;
		}
    }
}
