// <copyright file="ServiceLogging.cs" company="PayM8">
//     Copyright ©  2015
// </copyright>

namespace RockPaper.Instrumentation.Logging
{
    using System;

    /// <summary>
    /// The Service / Console Logger
    /// </summary>
    public class ServiceLogging : Logging
    {
        /// <summary>
        /// Traces the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public override void Verbose(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Verbose, msg);
            }
        }

        /// <summary>
        /// Debugs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public override void Debug(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Debug, msg);
            }
        }

        /// <summary>
        /// Informations the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public override void Info(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Info, msg);
            }
        }

        /// <summary>
        /// Warns the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public override void Warn(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Warn, msg);
            }
        }

        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public override void Error(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
            }
            else
            {
                WriteLog(LogLevel.Error, msg);
            }
        }

        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns>The error reference</returns>
        public override Guid ErrorWithRef(string msg)
        {
            var errorToken = Guid.NewGuid();
            var message = string.Format("{0} - Reference [{1}]", msg, errorToken);

            if (Environment.UserInteractive)
            {
                Console.WriteLine(message);
            }
            else
            {
                WriteLog(LogLevel.Error, message);
            }

            return errorToken;
        }

        /// <summary>
        /// Fatals the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public override void Critical(string msg)
        {
            if (Environment.UserInteractive)
            {
                Console.WriteLine(msg);
                Console.ReadKey();
            }
            else
            {
                WriteLog(LogLevel.Critical, msg);
            }
        }
    }
}
