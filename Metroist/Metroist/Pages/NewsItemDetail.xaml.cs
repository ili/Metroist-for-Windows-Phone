using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MetroistLib.Model;
using System.Windows.Markup;
using System.Text.RegularExpressions;
using Metroist.Etc;

namespace Metroist.Pages
{
    public partial class NewsItemDetail : PhoneApplicationPage
    {
        App app = Application.Current as App;
        public static NewsItem NewsItem;

        public NewsItemDetail()
        {
            InitializeComponent();
            NewsItem.content = Regex.Replace(NewsItem.content, @"<[^>]+>|&nbsp;", "").Trim();
            DataContext = NewsItem;

            MetroistService metroistService = new MetroistService();
            metroistService.readNews(app.loginInfo.id, NewsItem.timestamp, 
            (data)=>
            {
            },
            (error)=>
            {
            });
        }

        private void NewsItemDetailPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void htmlTextBlock_NavigationRequested(object sender, NavigationEventArgs e)
        {
            // due to the internal workings of the hyperlink, command will execute first (if attached) and event will be ignored.
        }

    }
}