using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSiteCkEditor.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; } // int
        public string Title { get; set; } // nvarchar(250)
        public string Desc { get; set; } // nvarchar(1000)
        public string Content { get; set; } // nvarchar(max)
        public bool IsShow { get; set; } // nvarchar(max)
        public string PhotoUrl { get; set; } // nvarchar(max)
    }

}
