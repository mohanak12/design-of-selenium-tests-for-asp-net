


		using Tests.SmokeTest.Core;
		using Tests.SmokeTest.PageObjects.Controls;
		using Selenium;
		
		namespace  Tests.SmokeTest.PageObjects
		{
			public partial class StorageAdminPage : PageBase
			{
				public StorageAdminPage() : base("Default.aspx") { }
				
					public void ClickClear()
	{
		Selenium.Click(@"xpath=/html/body/form[@id='form1']/div[3]/input[@id='btnClear']");
	}
					
							}
			
					}
