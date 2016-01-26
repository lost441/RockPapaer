// <copyright file="Logger.cs" company="PayM8">
//     Copyright ©  2015
// </copyright>

namespace RockPaper.Instrumentation.Logging
{
    using System;
    using NLog;

    [Serializable]
    public class Logging : ILogging
    {
        private const string DefaultModule = "";
        public string Module { get; private set; }

        public Logging() : this(null) {}

        public Logging(string module = DefaultModule)
        {
            if (string.IsNullOrWhiteSpace(module))
            {
                Module = module;
            }
            else
            {
                Module = string.Format("{0}::", module);
            }
        }

        /// <summary>
        /// The _logger
        /// </summary>
        private static Logger _logger;

        /// <summary>
        /// Gets the local logger.
        /// </summary>
        /// <value>The local logger</value>
        protected static Logger LocalLogger
        {
            get
            {
                if (_logger != null)
                {
                    return _logger;
                }

                return _logger =  LogManager.GetCurrentClassLogger();
            }
        }

        /// <summary>
        /// Traces the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public virtual void Verbose(string msg)
        {
            WriteLog(LogLevel.Verbose, msg);
        }

        /// <summary>
        /// Verboses the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public void Verbose(string msg, params object[] messageArgs)
        {
            this.Verbose(string.Format(msg, messageArgs));
        }

        /// <summary>
        /// Debugs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public virtual void Debug(string msg)
        {
            WriteLog(LogLevel.Debug, msg);
        }

        /// <summary>
        /// Debugs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public void Debug(string msg, params object[] messageArgs)
        {
            this.Debug(string.Format(msg, messageArgs));
        }

        /// <summary>
        /// Informations the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public virtual void Info(string msg)
        {
            WriteLog(LogLevel.Info, msg);
        }

        /// <summary>
        /// Informations the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public void Info(string msg, params object[] messageArgs)
        {
            this.Info(string.Format(msg, messageArgs));
        }

        /// <summary>
        /// Warns the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public virtual void Warn(string msg)
        {
            WriteLog(LogLevel.Warn, msg);
        }

        /// <summary>
        /// Warns the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public void Warn(string msg, params object[] messageArgs)
        {
            this.Warn(string.Format(msg, messageArgs));
        }

        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public virtual void Error(string msg)
        {
            this.WriteLog(LogLevel.Error, msg);
        }

        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public void Error(string msg, params object[] messageArgs)
        {
            this.Error(string.Format(msg, messageArgs));
        }

        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>The error reference</returns>
        public virtual Guid ErrorWithRef(string msg)
        {
            var errorToken = Guid.NewGuid();
            this.WriteLog(
                LogLevel.Error, 
                string.Format("{0} - Reference [{1}]", msg, errorToken));

            return errorToken;
        }

        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        /// <returns>The error refernce</returns>
        public Guid ErrorWithRef(string msg, params object[] messageArgs)
        {
            return this.ErrorWithRef(string.Format(msg, messageArgs));
        }

        /// <summary>
        /// Fatals the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public virtual void Critical(string msg)
        {
            WriteLog(LogLevel.Critical, msg);
        }

        /// <summary>
        /// Criticals the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        public void Critical(string msg, params object[] messageArgs)
        {
            this.Critical(string.Format(msg, messageArgs));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {}

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="msg">The MSG.</param>
        protected void WriteLog(LogLevel logLevel, string msg)
        {
            var theEvent = new LogEventInfo(Map(logLevel), "", msg);
            theEvent.Properties["Module"] = this.Module;
            LocalLogger.Log(theEvent);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is verbose.
        /// </summary>
        /// <value><c>True</c> if this instance is verbose; otherwise, <c>false</c>.</value>
        public bool IsVerbose
        {
            get 
            {
                return LocalLogger.IsTraceEnabled;
            }
        }

        /// <summary>
        /// Maps the specified original this allows for specialized loggers
        /// that do not need to reference NLog
        /// </summary>
        /// <param name="original">The original.</param>
        /// <returns>The NLog Log Level</returns>
        /// <exception cref="System.InvalidCastException"></exception>
        private static NLog.LogLevel Map(LogLevel original)
        {
            switch(original)
            {
                case LogLevel.Verbose :
                    return NLog.LogLevel.Trace;
                case LogLevel.Info:
                    return NLog.LogLevel.Info;
                case LogLevel.Debug:
                    return NLog.LogLevel.Debug;
                case LogLevel.Warn:
                    return NLog.LogLevel.Warn;
                case LogLevel.Error:
                    return NLog.LogLevel.Error;
                case LogLevel.Critical:
                    return NLog.LogLevel.Fatal;
                default :
                    throw new InvalidCastException(string.Format("Unknown Log Level [{0}]", original));
            }
        }
    }
}
