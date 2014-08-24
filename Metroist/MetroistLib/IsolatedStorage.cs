
using System.Linq;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using MetroistLib.Model;
using MetroistLib;
using System.Windows;

namespace GeneralLib
{
    [DataContract]
    //[KnownType("Project")]
    public class IsolatedStorage
    {
        private static readonly string storageKey = "isolated";
        private static readonly IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

        [DataMember]
        public Login LoginInfo { get; set; }

        [DataMember]
        public List<Project> Projects { get; set; }

        [DataMember]
        public List<Item> Items { get; set; }

        [DataMember]
        public List<Note> Notes { get; set; }

        [DataMember]
        public List<Item> StartPageTasks { get; set; }

        [DataMember]
        public LocalLogin LocalLoginInfo { get; set; }

        [DataMember]
        public Settings Settings { get; set; }

        [DataMember]
        public ObservableCollection<Dictionary<string, object>> ItemsToSync { get; set; }

        public IsolatedStorage()
        {
            
        }

        public static void clear()
        {
            IsolatedStorageSettings.ApplicationSettings.Clear();
        }

        public static IsolatedStorage load()
        {
            //IsolatedStorageSettings.ApplicationSettings.Clear();
            //MessageBox.Show("Data will be erased!", "Metroist", MessageBoxButton.OK);

            IsolatedStorage storage;
            settings.TryGetValue<IsolatedStorage>(storageKey, out storage);
            if (storage == null)
            {
                storage = new IsolatedStorage();
            }
            if(storage.LocalLoginInfo == null)
                storage.LocalLoginInfo = new LocalLogin() { isRecorded = false };
            //if (storage.LoginInfo == null)
            //    storage.LoginInfo = new Login();
            if (storage.Projects == null)
                storage.Projects = new List<Project>();
            if (storage.Items == null)
                storage.Items = new List<Item>();
            if (storage.StartPageTasks == null)
                storage.StartPageTasks = new List<Item>();
            if (storage.Notes == null)
                storage.Notes = new List<Note>();
            //if (storage.ActualLanguage == null)
            //    storage.ActualLanguage = new English();
            if (storage.Settings == null)
                storage.Settings = new Settings() { DateStringHome = FilterOption.TodayFilterOption };
            if (storage.ItemsToSync == null)
                storage.ItemsToSync = new ObservableCollection<Dictionary<string, object>>();

            return storage;
        }

        public static void save(IsolatedStorage storage)
        {
            settings[storageKey] = storage;
            settings.Save();
        }

    }
}
