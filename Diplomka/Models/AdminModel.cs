using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteCkEditor.Models
{
    public class AdminNewModel
    {
        public News news = new News();
        public IEnumerable<News> lst_news { get; set; }
    }
}