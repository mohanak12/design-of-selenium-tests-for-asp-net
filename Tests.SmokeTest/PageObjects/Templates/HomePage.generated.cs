




		using Tests.SmokeTest.Core;
		using Tests.SmokeTest.PageObjects.Controls;
		using Selenium;
		
		namespace  Tests.SmokeTest.PageObjects
		{
			public partial class HomePage : PageBase
			{
				public HomePage() : base("Home.aspx") { }
				
						private Label _userName = null;
		public Label UserName
		{
			get
			{
				if(_userName == null)
				{
					_userName = new Label(Selenium, @"xpath=/html/body/form[@id='form1']/div[3]/span[@id='lblUserName']");
				}
				return _userName;
			}
		}
	public void ClickLogout()
	{
		Selenium.Click(@"xpath=/html/body/form[@id='form1']/div[3]/input[@id='btnLogout']");
	}
			private TextField _name = null;
		public TextField Name
		{
			get
			{
				if(_name == null)
				{
					_name = new TextField(Selenium, @"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[3]/td[2]/input[@id='txtName']");
				}
				return _name;
			}
		}
		private TextField _password = null;
		public TextField Password
		{
			get
			{
				if(_password == null)
				{
					_password = new TextField(Selenium, @"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[4]/td[2]/input[@id='txtPassword']");
				}
				return _password;
			}
		}
	public void ClickAddUser()
	{
		Selenium.Click(@"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[5]/td/input[@id='btnAddUser']");
	}
			private Label _error = null;
		public Label Error
		{
			get
			{
				if(_error == null)
				{
					_error = new Label(Selenium, @"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[2]/td/span[@id='lblError']");
				}
				return _error;
			}
		}
		private Label _ajaxErrorMessage = null;
		public Label AjaxErrorMessage
		{
			get
			{
				if(_ajaxErrorMessage == null)
				{
					_ajaxErrorMessage = new Label(Selenium, @"xpath=/html/body/form[@id='form1']/div[4]/span[@id='lblAjaxErrorMessage']");
				}
				return _ajaxErrorMessage;
			}
		}
				
						public int GetUserTableRowsCount()
		{
			return (int)Selenium.GetXpathCount("/html/body/form[@id='form1']/div[3]/div[@id='holderUsers']/table/tbody/tr");
		}
		 
		public UserTablePageRow GetUserTableRow(int number)
		{
			return new UserTablePageRow(Selenium, number);
		}
			}
			
					public partial class UserTablePageRow : ControlBase
		{
		 	private readonly int _number;
			
			public UserTablePageRow(ISelenium selenium, int number) : base(selenium)
			{
            	_number = number;
        	}
	
					private Label _user = null;
		public Label User
		{
			get
			{
				if(_user == null)
				{
					_user = new Label(Selenium, string.Format(@"xpath=/html/body/form[@id='form1']/div[3]/div[@id='holderUsers']/table/tbody/tr[{0}]/td[1]", _number));
				}
				return _user;
			}
		}
		private Label _password = null;
		public Label Password
		{
			get
			{
				if(_password == null)
				{
					_password = new Label(Selenium, string.Format(@"xpath=/html/body/form[@id='form1']/div[3]/div[@id='holderUsers']/table/tbody/tr[{0}]/td[2]", _number));
				}
				return _password;
			}
		}
		}
		}
