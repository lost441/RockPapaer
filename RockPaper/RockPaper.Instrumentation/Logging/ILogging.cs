// <copyright file="ILogging.cs" company="PayM8">
//     Copyright ©  2015
// </copyright>

namespace RockPaper.Instrumentation.Logging
{
    using System;

    public interface ILogging : IDisposable
    {

        /// <summary>
        /// Gets a value indicating whether this instance is verbose.
        /// </summary>
        /// <value><c>True</c> if this instance is verbose; otherwise, <c>false</c>.</value>
        bool IsVerbose { get; }

        /// <summary>
        /// Traces the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Verbose(string msg);

        /// <summary>
        /// Verboses the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        void Verbose(string msg, params object[] messageArgs);

        /// <summary>
        /// Debugs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Debug(string msg);

        /// <summary>
        /// Debugs the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        void Debug(string msg, params object[] messageArgs);

        /// <summary>
        /// Informations the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Info(string msg);

        /// <summary>
        /// Informations the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        void Info(string msg, params object[] messageArgs);
        
        /// <summary>
        /// Warns the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Warn(string msg);

        /// <summary>
        /// Warns the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        void Warn(string msg, params object[] messageArgs);

        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Error(string msg);

        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        void Error(string msg, params object[] messageArgs);

        /// <summary>
        /// Fatals the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Critical(string msg);

        /// <summary>
        /// Criticals the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="messageArgs">The message arguments.</param>
        void Critical(string msg, params object[] messageArgs);
    }
}
