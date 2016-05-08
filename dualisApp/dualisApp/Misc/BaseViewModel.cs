// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The base view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using dualisApp.Annotations;

namespace dualisApp.Misc
{
    /// <summary>
	/// The base view model.
	/// </summary>
	public class BaseViewModel : INotifyPropertyChanged
    {
        #region CommandHelper

        protected void CanExecuteChanged(ICommand command)
        {
            var relayCommand = command as RelayCommand;
            relayCommand?.RaiseCanExecuteChanged();
        }

        readonly List<RelayCommand> _listeningCommands = new List<RelayCommand>(); 

        protected ICommand InitializeCommand(Action<object> executeAction, Predicate<object> canExecutePredicate, params string[] properties)
        {
            var newCommand = new RelayCommand(executeAction, canExecutePredicate, properties);
            _listeningCommands.Add(newCommand);
            return newCommand;
        }

        #endregion CommandHelper

        #region ProgressRing

        /// <summary>
        /// The _progress ring visibility.
        /// </summary>
        private Visibility _progressRingVisibility;

        /// <summary>
        /// The _progress ring is active.
        /// </summary>
        private bool _progressRingIsActive;

        /// <summary>
        /// The _is page enabled.
        /// </summary>
        private bool _isPageEnabled;

        /// <summary>
        /// Gets or sets the progress ring visibility.
        /// </summary>
        public Visibility ProgressRingVisibility
        {
            get { return _progressRingVisibility; }
            set
            {
                if (_progressRingVisibility != value)
                {
                    _progressRingVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether progress ring is active.
        /// </summary>
        public bool ProgressRingIsActive
        {
            get { return _progressRingIsActive; }
            set
            {
                if (_progressRingIsActive != value)
                {
                    _progressRingIsActive = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is page enabled.
        /// </summary>
        public bool IsPageEnabled
        {
            get { return _isPageEnabled; }
            set
            {
                if (_isPageEnabled != value)
                {
                    _isPageEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The set progress ring.
        /// </summary>
        /// <param name="activate">
        /// The activate.
        /// </param>
        protected void SetProgressRing(bool activate)
        {
            ProgressRingIsActive = activate;
            IsPageEnabled = !activate;
            ProgressRingVisibility = activate ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion ProgressRing

        #region PropertyChanged

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (_listeningCommands.Count > 0)
            {
                foreach (var listeningCommand in _listeningCommands)
                {
                    if (listeningCommand.CheckValueChangedProperties.Contains(propertyName))
                    {
                        CanExecuteChanged(listeningCommand);
                    }
                }
            }
        }

        #endregion PropertyChanged
    }
}
