using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using SeleniumObjectModel.Template;

namespace SeleniumObjectModel.Tests
{
    [TestFixture]
    public class ControlXPathParserTest
    {
        [Test]
        public void ParseOneItemPerLine()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[1]/table[1]/tbody/tr/td[1]/table/tbody/tr[1]/td/input[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_txtFundID']
/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[1]/table[1]/tbody/tr/td[1]/table/tbody/tr[2]/td/input[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_txtFundName']
/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[1]/table[1]/tbody/tr/td[1]/table/tbody/tr[3]/td/input[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_txtInceptionDate']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(3));
        }

        [Test]
        public void ParseInput()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[1]/table[1]/tbody/tr/td[1]/table/tbody/tr[1]/td/input[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_txtFundID']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[1]/table[1]/tbody/tr/td[1]/table/tbody/tr[1]/td/input[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_txtFundID']"));
            Assert.That(items[0].Name, Is.EqualTo("FundID"));
            Assert.That(items[0].Type, Is.EqualTo("TextField"));
        } 
        [Test]
        public void ParseCurrencyInput()
        {
            string elements =
                @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[3]/div[2]/div[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_CollapsiblePanel2']/table[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_editFundTable']/tbody/tr/td/div[1]/table/tbody/tr[6]/td/table/tbody/tr[1]/td/input[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_txtTotalDollarsInvested_txtCurrency']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=/html/body/form[@id='aspnetForm']/div[@id='content']/div[3]/div[2]/div[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_CollapsiblePanel2']/table[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_editFundTable']/tbody/tr/td/div[1]/table/tbody/tr[6]/td/table/tbody/tr[1]/td/input[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_txtTotalDollarsInvested_txtCurrency']"));
            Assert.That(items[0].Name, Is.EqualTo("TotalDollarsInvested"));
            Assert.That(items[0].Type, Is.EqualTo("TextField"));
        }
        
        [Test]
        public void ParseTextarea()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[1]/table[1]/tbody/tr/td[1]/table/tbody/tr[1]/td/textarea[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_txtFundID']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("FundID"));
            Assert.That(items[0].Type, Is.EqualTo("TextField"));
        }
        
        [Test]
        public void ParseCheckbox()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[1]/table[1]/tbody/tr/td[1]/table/tbody/tr[1]/td/input[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_chkFundID']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("FundID"));
            Assert.That(items[0].Type, Is.EqualTo("Checkbox"));
        }
        
        
        [Test]
        public void ParseDropdown()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[1]/table[1]/tbody/tr/td[1]/table/tbody/tr[1]/td/select[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_chkFundID']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("FundID"));
            Assert.That(items[0].Type, Is.EqualTo("Dropdown"));
        }

        [Test]
        public void ParseLinkButton()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/a[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_btnSave']/span";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("Save"));
            Assert.That(items[0].Type, Is.EqualTo("Button"));
        }

        [Test]
        public void ParseInputButton()
        {
            string elements = @"xpath=/html/body/form[@id='form1']/div[3]/table/tbody/tr[4]/td/input[@id='btnLogin']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("Login"));
            Assert.That(items[0].Type, Is.EqualTo("Button"));
        }

        [Test]
        public void ParseUserControlButtonButton()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[3]/div[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_panelEditButtons']/table/tbody/tr/td[3]/a[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_btnAddNew_ctrlButton']/span[@id='ctl00_ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_btnAddNew_buttonTextLabel']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("AddNew"));
            Assert.That(items[0].Type, Is.EqualTo("Button"));
        }

        [Test]
        public void ParseLabel()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[2]/table[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_dgrdFunds']/tbody/tr[0]/td[3]/span[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_lblFundName']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("FundName"));
            Assert.That(items[0].Type, Is.EqualTo("Label"));
        }
        
        [Test]
        public void ParseLabelInRoot()
        {
            string elements = @"/html/body/form[@id='form1']/div[3]/table/tbody/tr[1]/td/span[@id='lblMessage']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("Message"));
            Assert.That(items[0].Type, Is.EqualTo("Label"));
        }
        
        [Test]
        public void ParseLabelWithSimpleId()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[2]/table[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_dgrdFunds']/tbody/tr[0]/td[3]/span[@id='_lblFundName']";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=" + elements));
            Assert.That(items[0].Name, Is.EqualTo("FundName"));
            Assert.That(items[0].Type, Is.EqualTo("Label"));
        } 
        
        [Test]
        public void ParseLabelWithMetainformation()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[2]/table[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_dgrdFunds']/tbody/tr[0]/td[3]/span[0] {Name=lblFundName}";

            var items = ControlXPathParser.GetItems(elements);

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[2]/table[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_dgrdFunds']/tbody/tr[0]/td[3]/span[0]"));
            Assert.That(items[0].Name, Is.EqualTo("FundName"));
            Assert.That(items[0].Type, Is.EqualTo("Label"));
        }

        [Test]
        public void ApplyCounter()
        {
            string elements = @"/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[2]/table[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_dgrdFunds']/tbody/tr[0]/td[3]/span[@id='_lblFundName']";

            var items = ControlXPathParser.GetItems(elements, "/tbody/tr[{0}]/td[3]");

            Assert.That(items, Has.Count(1));
            Assert.That(items[0].XPath, Is.EqualTo("xpath=/html/body/form[@id='aspnetForm']/div[@id='content']/div[2]/div[2]/table[@id='ctl00_ctl00_ctl00_MainContantPlaceHolder_MainContantPlaceHolder_MainContantPlaceHolder_dgrdFunds']/tbody/tr[{0}]/td[3]/span[@id='_lblFundName']"));
        }
    }
}