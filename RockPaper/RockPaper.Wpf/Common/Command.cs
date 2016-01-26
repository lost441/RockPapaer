// <copyright file="Command.cs" company="PayM8">
//     Copyright ©  2015
// </copyright>

namespace RockPaper.Wpf.Common
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Class Command.
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// The can execute flag.
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// The execute action.
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="canExecute">The can execute flag.</param>
        /// <param name="execute">The execute action.</param>
        public Command(Func<bool> canExecute, Action execute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            var canExecute = this._canExecute();
            return canExecute;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            this._execute();
        }

        /// <summary>
        /// The can execute changed event handler.
        /// </summary>
        public void OnCanExecuteChanged()
        {
            if (this.CanExecuteChanged == null)
            {
                return;
            }

            this.CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
