
using System;
using System.Windows.Input;
using dualisApp.Misc;

namespace dualisApp.ViewModel
{
    public class ViewBaseViewModel : BaseViewModel
    {
        public ViewBaseViewModel()
        {
            ShowSettingsViewCommand = InitializeCommand(ShowSettings, CanShowSettings, nameof(IsPageEnabled));
            UpdateDataCommand = InitializeCommand(UpdateData, CanUpdateData, nameof(IsPageEnabled));
            ShowWeekViewCommand = InitializeCommand(ShowWeekView, CanShowWeekView, nameof(IsPageEnabled));
            ShowMonthViewCommand = InitializeCommand(ShowMonthView, CanShowMonthView, nameof(IsPageEnabled));
            ShowDayViewCommand = InitializeCommand(ShowDayView, CanShowDayView, nameof(IsPageEnabled));
        }

        public ICommand ShowSettingsViewCommand { get; set; }

        public ICommand UpdateDataCommand { get; set; }

        public ICommand ShowWeekViewCommand { get; set; }

        public ICommand ShowMonthViewCommand { get; set; }

        public ICommand ShowDayViewCommand { get; set; }

        public bool CanShowSettings(object obj)
        {
            return IsPageEnabled;
        }

        public bool CanUpdateData(object obj)
        {
            return IsPageEnabled;
        }

        public bool CanShowWeekView(object obj)
        {
            return IsPageEnabled;
        }

        public bool CanShowMonthView(object obj)
        {
            return IsPageEnabled;
        }

        public bool CanShowDayView(object obj)
        {
            return IsPageEnabled;
        }

        public void ShowSettings(object obj)
        {
            FrameNavigator.NavigateTo(typeof(SettingsPageViewModel));
        }

        public void UpdateData(object obj)
        {
            DataHasUpdated();
        }

        protected virtual void DataHasUpdated()
        {
            throw new NotImplementedException();
        }

        public void ShowWeekView(object obj)
        {
            FrameNavigator.NavigateTo(typeof(WeekViewPageViewModel));
        }

        public void ShowMonthView(object obj)
        {
            FrameNavigator.NavigateTo(typeof(MonthViewPageViewModel));
        }

        public void ShowDayView(object obj)
        {
            FrameNavigator.NavigateTo(typeof(DayListViewPageViewModel));
        }
    }
}
