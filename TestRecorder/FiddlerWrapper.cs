
using System;
using System.Collections.Generic;

namespace TestRecorder
{
	public interface IFiddlerWrapper : IDisposable
	{
		void Start();
		IEnumerable<Fiddler.Session> GetSessions();
		void Stop();
	}
	
	public class FiddlerWrapper : IFiddlerWrapper
	{
		private const int ProxyPort = 1234;
		private static bool _started = false;
		
		private List<Fiddler.Session> _sessions = new List<Fiddler.Session>();
		
		public FiddlerWrapper()
		{
		}
		
		public void Start()
		{
			if(_started)
			{
				throw new InvalidOperationException("Fiddler app is already started");
			}
			_sessions.Clear();
			Fiddler.FiddlerApplication.AfterSessionComplete += FiddlerSessionComplete;
			Fiddler.FiddlerApplication.Startup(ProxyPort, true, false);
			_started = true;
		}
		
		private void FiddlerSessionComplete(Fiddler.Session session)
		{
			lock(session)
			{
				_sessions.Add(session);
			}
		}
		
		public IEnumerable<Fiddler.Session> GetSessions()
		{
			return _sessions;
		}
		
		public void Stop()
		{
			if(!_started)
			{
				throw new InvalidOperationException("Fiddler app is not started");
			}
			Fiddler.FiddlerApplication.Shutdown();
			Fiddler.FiddlerApplication.AfterSessionComplete -= FiddlerSessionComplete;
			_started = false;			
		}
		
		public void Dispose()
		{
			if(_started)
			{
				Stop();
			}
		}
	}
}
