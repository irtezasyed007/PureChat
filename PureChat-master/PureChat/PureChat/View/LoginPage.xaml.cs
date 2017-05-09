using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PureChat
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		void Login(object sender, System.EventArgs e)
		{
			Manager.attemptLogin(username.Text, password.Text);
		}

	}
}
