
using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
namespace TestRecorder.Tests
{
	[TestFixture]
	public class FiddlerRecorderTest
	{
		[Test]
		public void RecorderInvokesTestRun2Times()
		{
			var fakeWrapper = new FakeFiddlerWrapper();
			var rec= new TestRecorder(fakeWrapper);
			int invokeCount = 0;
			rec.SetTestCallback((q) => {
			                   	invokeCount++;
			                   });
			
			rec.Record();
			
			Assert.That(invokeCount, Is.EqualTo(2));
		}
		
		#region RequestStub
		const string RequestStub = @"GET / HTTP/1.1
Host: www.codeplex.com
User-Agent: Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
Accept-Language: en-us,en;q=0.5
Accept-Encoding: gzip,deflate
Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7
Keep-Alive: 300
Proxy-Connection: keep-alive
Cookie: omniID=1260569928800_7b9c_44f8_a03a_184220c63ef8; msresearch=1; ASP.NET_SessionId=1tmbie55banf3pmpoplefh55; s_cc=true; s_sq=%5B%5BB%5D%5D; TimezoneOffset=2

";
		#endregion
		
		private Fiddler.Session CreateSession()
		{
			
			return new Fiddler.Session(System.Text.Encoding.ASCII.GetBytes(RequestStub), new byte[0]);
		}
		
		[Test]
		public void RecorderReturnsAllSessions()
		{
			var fakeWrapper = new FakeFiddlerWrapper();
			fakeWrapper.AddSession(CreateSession());
			fakeWrapper.AddSession(CreateSession());
			
			var rec= new TestRecorder(fakeWrapper);
			rec.SetTestCallback((q) => {});
			
			rec.Record();
			
			Assert.That(rec.GetSessions().ToList(), Has.Count.EqualTo(2));
		}
		
	}
	
	internal class FakeFiddlerWrapper : IFiddlerWrapper
	{
		private List<Fiddler.Session> _sessions = new List<Fiddler.Session>();
		public void AddSession(Fiddler.Session session)
		{
			_sessions.Add(session);
		}
		
		public void Start()
		{
		}
		
		public System.Collections.Generic.IEnumerable<Fiddler.Session> GetSessions()
		{
			return _sessions;
		}
		
		public void Stop()
		{
		}
		
		public void Dispose()
		{
		}
	}
}
