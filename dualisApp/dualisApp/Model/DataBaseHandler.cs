using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Security.Credentials;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace dualisApp.Model
{
    public class DataBaseHandler
    {
        private static DataBaseHandler _instance ;

        public static DataBaseHandler Instance => _instance ?? (_instance = new DataBaseHandler());

        /// <summary>
		/// The data base name.
		/// </summary>
		const string DataBaseName = "dualis.sqlite";

        static readonly string DataBasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DataBaseName);

        private DataBaseHandler()
        {
            CreateLocalDB();
        }

        private void CreateLocalDB()
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), DataBasePath))
            {
                conn.CreateTable<LectureModel>();
            }
        }

        public ObservableCollection<LectureModel> GetLectures()
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), DataBasePath))
            {
                var query = conn.Query<LectureModel>($"SELECT * FROM {nameof(LectureModel)}");
                
                return new ObservableCollection<LectureModel>(query.ToList());
            }
        }

        public void InsertLectures(List<LectureModel> lectures)
        {
            if (lectures.Count == 0) return;

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), DataBasePath))
            {
                conn.Query<LectureModel>($"DELETE FROM {nameof(LectureModel)}");
                
                conn.InsertOrReplaceAll(lectures);
            }
        }

        public PasswordCredential GetUserData()
        {
            var vault = new PasswordVault();
            return vault.FindAllByResource("dualisApp").FirstOrDefault();
        }

        public void SaveUserData(string email, string password)
        {
            var vault = new PasswordVault();
            vault.Add(new PasswordCredential("dualisApp", email, password));
        }

        public void DeleteUserData()
        {
            var vault = new PasswordVault();
            var result = vault.FindAllByResource("dualisApp");
            foreach (var passwordCredential in result)
            {
                vault.Remove(passwordCredential);
            }
            
        }
    }
}
