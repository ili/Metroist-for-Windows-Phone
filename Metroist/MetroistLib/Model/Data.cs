using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using GeneralLib;

namespace MetroistLib.Model 
{
    [DataContract]
    public class Data
    {
        [DataMember]
        public Int64 seq_no_global { get; set; }
        //public List<object> Collaborators { get; set; }
        [DataMember]
        public string DayOrdersTimestamp { get; set; }
        [DataMember]
        public List<Note> Notes { get; set; }
        [DataMember]
        public List<Label> Labels { get; set; }
        [DataMember]
        public Int64 UserId { get; set; }
        //public List<object> CollaboratorStates { get; set; }
        //public List<object> LiveNotifications { get; set; }
        [DataMember]
        public Int64 seq_no { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public List<Filter> Filters { get; set; }
        [DataMember]
        public List<Item> Items { get; set; }
        [DataMember]
        public Dictionary<string, int> TempIdMapping { get; set; }
        //public List<object> Reminders { get; set; }
        [DataMember]
        public List<Project> Projects { get; set; }
        [DataMember]
        public Int64 LiveNotificationsLastRead { get; set; }
    }

    [DataContract]
    public class Project
    {
        [DataMember]
        public string last_updated { get; set; }
        [DataMember]
        public int color { get; set; }
        [DataMember]
        public Int64 collapsed { get; set; }
        //public object archived_date { get; set; }
        [DataMember]
        public Int64 archived_timestamp { get; set; }
        [DataMember]
        public Int64 cache_count { get; set; }
        [DataMember]
        public Int64 id { get; set; }
        [DataMember]
        public Int64 indent { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Int64 user_id { get; set; }
        [DataMember]
        public Int64 is_deleted { get; set; }
        [DataMember]
        public Int64 item_order { get; set; }
        [DataMember]
        public bool shared { get; set; }
        [DataMember]
        public Int64 is_archived { get; set; }
        [DataMember]
        public bool? inbox_project { get; set; }
    }

    [DataContract]
    public class Item : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        [IgnoreDataMember]
        private bool _selectedListBoxItem_ProjectDetail;
        [IgnoreDataMember]
        public bool selectedListBoxItem_ProjectDetail
        {
            get { return _selectedListBoxItem_ProjectDetail; }
            set
            {
                _selectedListBoxItem_ProjectDetail = value;
                OnPropertyChanged("selectedListBoxItem_ProjectDetail");
            }
        }

        [DataMember]
        public string due_date { get; set; }
        [DataMember]
        public Int64 day_order { get; set; }
        [DataMember]
        public Int64 assigned_by_uid { get; set; }
        [DataMember]
        public Int64 is_archived { get; set; }
        //public List<object> labels { get; set; }
        //public object sync_id { get; set; }
        [DataMember]
        public Int64 in_history { get; set; }
        [DataMember]
        public Int64 has_notifications { get; set; }
        [DataMember]
        public string date_added { get; set; }
        [DataMember]
        public Int64 indent { get; set; }
        //public object children { get; set; }
        [DataMember]
        public string content { get; set; }
        [DataMember]
        public Int64 is_deleted { get; set; }
        [DataMember]
        public Int64 user_id { get; set; }
        [DataMember]
        public string due_date_utc { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Int64 priority { get; set; }
        [DataMember]
        public Int64 item_order { get; set; }
        //public object responsible_uid { get; set; }
        [DataMember]
        public Int64 project_id { get; set; }
        [DataMember]
        public Int64 collapsed { get; set; }

        [IgnoreDataMember]
        public bool _checked;
        [DataMember(Name="checked")]
        public bool is_checked { 
            get 
            {
                return _checked;
            } set 
            {
                _checked = value;
            } 
        }


        [DataMember]
        public string date_string { get; set; }
    }

    [DataContract]
    public class Label
    {
        [DataMember]
        public Int64 is_deleted { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Int64 color { get; set; }
        [DataMember]
        public Int64 id { get; set; }
        [DataMember]
        public Int64 uid { get; set; }
    }

    [DataContract]
    public class Note
    {
        [DataMember]
        public Int64 is_deleted { get; set; }
        [DataMember]
        public Int64 is_archived { get; set; }
        [DataMember]
        public string content { get; set; }
        [DataMember]
        public Int64 posted_uid { get; set; }
        [DataMember]
        public Int64 item_id { get; set; }
        //public object uids_to_notify { get; set; }
        [DataMember]
        public Int64 id { get; set; }
        [DataMember]
        public string posted { get; set; }
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string start_page { get; set; }
        [DataMember]
        public string avatar_small { get; set; }
        [DataMember]
        public bool is_premium { get; set; }
        [DataMember]
        public Int64 sort_order { get; set; }
        [DataMember]
        public string full_name { get; set; }
        [DataMember]
        public bool has_push_reminders { get; set; }
        [DataMember]
        public string timezone { get; set; }
        [DataMember]
        public Int64 id { get; set; }
        [DataMember]
        public Int64 next_week { get; set; }
        [DataMember]
        public Int64 completed_count { get; set; }
        //public List<object> tz_offset { get; set; }
        [DataMember]
        public string avatar_medium { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public double karma { get; set; }
        [DataMember]
        public Int64 start_day { get; set; }
        [DataMember]
        public string avatar_big { get; set; }
        [DataMember]
        public Int64 date_format { get; set; }
        [DataMember]
        public Int64 inbox_project { get; set; }
        [DataMember]
        public Int64 time_format { get; set; }
        [DataMember]
        public string image_id { get; set; }
        [DataMember]
        public Int64 beta { get; set; }
        [DataMember]
        public string karma_trend { get; set; }
        //public object business_account_id { get; set; }
        [DataMember]
        public string mobile_number { get; set; }
        [DataMember]
        public string mobile_host { get; set; }
        [DataMember]
        public Int64 is_dummy { get; set; }
        [DataMember]
        public string premium_until { get; set; }
        [DataMember]
        public string join_date { get; set; }
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public bool is_biz_admin { get; set; }
        [DataMember]
        public string default_reminder { get; set; }
    }

    [DataContract]
    public class Filter
    {
        [DataMember]
        public Int64 user_id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Int64 color { get; set; }
        [DataMember]
        public Int64 is_deleted { get; set; }
        [DataMember]
        public Int64 item_order { get; set; }
        [DataMember]
        public string query { get; set; }
        [DataMember]
        public Int64 id { get; set; }
    }

    // ------------------------------------------------------------------------------
    // Customized data models

    public enum FilterTask
    {
        Today, Tomorrow, Next7Days, AllUncompleted
    }

    public class FilterOption
    {
        public static FilterOption TodayFilterOption =
            new FilterOption { Key = FilterTask.Today, FriendlyName = "today", Value = "Today" };

        public static ObservableCollection<FilterOption> filteringOptions =
        new ObservableCollection<FilterOption>
        {
            TodayFilterOption,
            new FilterOption { Key = FilterTask.Tomorrow, FriendlyName="tomorrow", Value = "Tomorrow" },
            new FilterOption { Key = FilterTask.Next7Days, FriendlyName = "next 7 days", Value = "Next 7 days" },
            new FilterOption { Key = FilterTask.AllUncompleted, FriendlyName = "all uncompleted", Value = "View all uncompleted" },
        };

        public FilterTask Key { get; set; }
        public string Value { get; set; }
        public string FriendlyName { get; set; }
        public bool Selected { get; set; }
    }

    //[DataContract]
    //public class QueryItem
    //{
    //    [DataMember]
    //    public string query { get; set; }
    //    [DataMember]
    //    public string type { get; set; }

    //    [DataMember(Name = "data")]
    //    public QueryDataItem[] item { get; set; }
    //}
}
