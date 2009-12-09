


		using Tests.SmokeTest.Core;
		using Tests.SmokeTest.PageObjects.Controls;
		using Selenium;
		
		namespace  Tests.SmokeTest.PageObjects
		{
			public partial class LoginPage : PageBase
			{
				public LoginPage() : base("Login.aspx") { }
				
						private Label _message = null;
		public Label Message
		{
			get
			{
				if(_message == null)
				{
					_message = new Label(Selenium, @"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[1]/td/span[@id='lblMessage']");
				}
				return _message;
			}
		}
		private TextField _user = null;
		public TextField User
		{
			get
			{
				if(_user == null)
				{
					_user = new TextField(Selenium, @"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[2]/td[2]/input[@id='txtUser']");
				}
				return _user;
			}
		}
		private TextField _password = null;
		public TextField Password
		{
			get
			{
				if(_password == null)
				{
					_password = new TextField(Selenium, @"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[3]/td[2]/input[@id='txtPassword']");
				}
				return _password;
			}
		}
	public void ClickLogin()
	{
		Selenium.Click(@"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[4]/td/input[@id='btnLogin']");
	}
					
							}
			
					}
