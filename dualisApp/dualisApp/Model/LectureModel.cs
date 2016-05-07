using System;

namespace dualisApp.Model
{
    public class LectureModel
    {
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int Id { get; set; }
        public int RemoteId { get; set; }
        public DateTime Day { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string LectureName { get; set; }
    }
}
