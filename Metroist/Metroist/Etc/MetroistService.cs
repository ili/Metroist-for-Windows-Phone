using MetroistLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metroist.Etc
{
    class MetroistService : TodoistService
    {
        public void GetNews(Int32 todoistUserId, Action<List<NewsItem>> onSuccess, Action<string> onError, Action onFinally = null)
        {
            Dictionary<String, Object> Arguments = new Dictionary<string, object>()
            {
                { "todoistUserId", todoistUserId }
            };

            post<List<NewsItem>>(urlMetroistServer + "getNews.php", Arguments,
            (response) =>
            {
                onSuccess(response);
                if (onFinally != null)
                    onFinally();
            },
            (stringError) =>
            {
                onError(stringError);
                if (onFinally != null)
                    onFinally();
            });
        }

        public void readNews(int todoistUserId, double id_news, Action<String> onSuccess, Action<String> onError, Action onFinally = null)
        {
            Dictionary<String, Object> Arguments = new Dictionary<string, object>()
            {
                { "todoistUserId", todoistUserId },
                { "id_news", id_news }
            };

            post<String>(urlMetroistServer + "readNews.php", Arguments,
            (response) =>
            {
                onSuccess(response);
                if (onFinally != null)
                    onFinally();
            },
            (stringError) =>
            {
                onError(stringError);
                if (onFinally != null)
                    onFinally();
            });
        }
    }
}
