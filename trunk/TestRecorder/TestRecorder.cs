
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestRecorder
{
	public class RecorderSession
	{
		
	}
	
	public class TestRecorder
	{
		private Action<int> _runTest = null;
		private IFiddlerWrapper _fiddler;
		
		public TestRecorder(IFiddlerWrapper fidler)
		{
			_fiddler = fidler;
		}
		
		private IEnumerable<Fiddler.Session> RunTest()
		{
			_fiddler.Start();
			_runTest(1);
			_fiddler.Stop();
			return _fiddler.GetSessions().ToList();
		}
		
		public void Record()
		{
			RunTest();
			RunTest();
		}
		
		public IEnumerable<RecorderSession> GetSessions()
		{
			yield return new RecorderSession();
			yield return new RecorderSession();
		}
		
		public void SetTestCallback(Action<int> runTest)
		{
			_runTest = runTest;
		}
	
	}
}