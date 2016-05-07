// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameNavigator.cs" company="">
//   
// </copyright>
// <summary>
//   The frame navigator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace dualisApp.Misc
{
    /// <summary>
	/// The frame navigator.
	/// </summary>
	public static class FrameNavigator
    {
		/// <summary>
		/// The registered pages.
		/// </summary>
		static readonly Dictionary<Type, Type> RegisteredPages = new Dictionary<Type, Type>();

		/// <summary>
		/// Gets or sets the application frame.
		/// </summary>
		public static Frame ApplicationFrame { get; set; }

		/// <summary>
		/// The register page.
		/// </summary>
		/// <param name="typeOfPage">
		/// The type of page.
		/// </param>
		/// <param name="typeOfViewModel">
		/// The type of view model.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		public static bool RegisterPage(Type typeOfPage, Type typeOfViewModel)
        {
            if (!RegisteredPages.ContainsKey(typeOfViewModel))
            {
                RegisteredPages.Add(typeOfViewModel, typeOfPage);

                return true;
            }

            return false;
        }

		/// <summary>
		/// The un register page.
		/// </summary>
		/// <param name="typeOfViewModel">
		/// The type of view model.
		/// </param>
		/// <returns>
		/// The <see cref="bool"/>.
		/// </returns>
		public static bool UnRegisterPage(Type typeOfViewModel)
        {
            if (RegisteredPages.ContainsKey(typeOfViewModel))
            {
                RegisteredPages.Remove(typeOfViewModel);

                return true;
            }

            return false;
        }

		/// <summary>
		/// The navigate to.
		/// </summary>
		/// <param name="typeOfViewModel">
		/// The type of view model.
		/// </param>
		/// <param name="parameter">
		/// The parameter.
		/// </param>
		public static void NavigateTo(Type typeOfViewModel, object parameter = null)
        {
            if (RegisteredPages.ContainsKey(typeOfViewModel))
            {
                if (parameter == null)
                {
                    ApplicationFrame.Navigate(RegisteredPages[typeOfViewModel]);
                }
                else
                {
                    ApplicationFrame.Navigate(RegisteredPages[typeOfViewModel], parameter);
                }
            }
        }

		/// <summary>
		/// The navigate back.
		/// </summary>
		public static void NavigateBack()
	    {
		    if (ApplicationFrame.CanGoBack)
		    {
			    ApplicationFrame.GoBack();
			}
		}
    }
}
