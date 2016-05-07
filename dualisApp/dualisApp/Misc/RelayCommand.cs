// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="">
//   
// </copyright>
// <summary>
//   The relay command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Input;

namespace dualisApp.Misc
{
    /// <summary>
	/// The relay command.
	/// </summary>
	public sealed class RelayCommand : ICommand
	{
		/// <summary>
		/// The _execute action.
		/// </summary>
		private readonly Action<object> _executeAction;

		/// <summary>
		/// The _can execute predicate.
		/// </summary>
		private readonly Predicate<object> _canExecutePredicate;

		/// <summary>
		/// Initializes a new instance of the <see cref="RelayCommand"/> class.
		/// </summary>
		/// <param name="executeAction">
		/// The execute action.
		/// </param>
		/// <param name="canExecutePredicate">
		/// The can execute predicate.
		/// </param>
		public RelayCommand(Action<object> executeAction, Predicate<object> canExecutePredicate)
		{
			_executeAction = executeAction;
			_canExecutePredicate = canExecutePredicate;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RelayCommand"/> class.
		/// </summary>
		/// <param name="executeAction">
		/// The execute action.
		/// </param>
		public RelayCommand(Action<object> executeAction)
			: this(executeAction, null)
		{ }

		/// <summary>
		/// The can execute changed.
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// The raise can execute changed.
		/// </summary>
		public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

		/// <summary>
		/// The can execute.
		/// </summary>
		/// <param name="parameter">
		/// The parameter.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		public bool CanExecute(object parameter)
		{
			return _executeAction != null && (_canExecutePredicate == null || _canExecutePredicate(parameter));
		}

		/// <summary>
		/// The execute.
		/// </summary>
		/// <param name="parameter">
		/// The parameter.
		/// </param>
		public void Execute(object parameter)
		{
			if (_executeAction == null)
			{
				return;
			}

			_executeAction(parameter);
		}
	}
}