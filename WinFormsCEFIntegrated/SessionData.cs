using System;
using System.Collections.Generic;
using System.Threading;

namespace WinFormsCEFIntegrated
{
    public class SessionData
    {
        private static readonly SessionData _instance = new SessionData();
        public static SessionData Instance => _instance;

        private static readonly Mutex _mutex = new Mutex();

        private string _username;
        private Dictionary<string, object> _sessionVariables = new Dictionary<string, object>();

        public string Username
        {
            get
            {
                _mutex.WaitOne();
                try
                {
                    return _username;
                }
                finally
                {
                   _mutex.ReleaseMutex();
                }
            }
            set
            {
                _mutex.WaitOne();
                try
                {
                    _username = value;
                }
                finally
                {
                   _mutex.ReleaseMutex();
                }
            }
        }

        public Dictionary<string, object> SessionVariables
        {
            get
            {
                _mutex.WaitOne();
                try
                {
                    return new Dictionary<string, object>(_sessionVariables);
                }
                finally
                {
                    _mutex.ReleaseMutex();
                }
            }
            set
            {
                _mutex.WaitOne();
                try
                {
                    _sessionVariables = new Dictionary<string, object>(value);
                }
                finally
                {
                   _mutex.ReleaseMutex();
                }
            }
        }

        private void Log(string action)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} [Thread {Thread.CurrentThread.ManagedThreadId}] {action}");
        }
    }

}

