using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeShouldGo.Models
{
    public class SearchRequestViewModel
    {
        public string Term { get; set; }

        public string Location { get; set; }
    }
}