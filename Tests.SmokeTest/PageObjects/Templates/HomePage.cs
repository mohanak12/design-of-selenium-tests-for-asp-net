


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
					_userName = new Label(Selenium, @"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[1]/td/span[@id='lblUserName']");
				}
				return _userName;
			}
		}
				
							}
			
					}
