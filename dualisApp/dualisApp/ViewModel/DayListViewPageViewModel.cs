using System;
using System.Collections.ObjectModel;
using dualisApp.Model;

namespace dualisApp.ViewModel
{
    public class DayListViewPageViewModel : ViewBaseViewModel
    {
        private DateTime _currentDate = DateTime.Today;
        private ObservableCollection<LectureModel> _lectures = new ObservableCollection<LectureModel> {new LectureModel
        {
            Day = DateTime.Now,
            EndTime = DateTime.Now,
            LectureName = "Test",
            StartTime = DateTime.Now
        } };

        public string CurrentDate
        {
            get { return _currentDate.ToString("ddd, dd.MM"); }
            set { }
        }

        public DayListViewPageViewModel()
        {
            SetProgressRing(false);
        }

        public ObservableCollection<LectureModel> Lectures
        {
            get { return _lectures; }
            set
            {
                if (_lectures != value)
                {
                    _lectures = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
