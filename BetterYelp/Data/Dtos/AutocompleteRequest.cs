using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShouldGo.Data.Dtos
{
    public class AutocompleteRequest
    {
        public string text { get; set; }

        public decimal latitude { get; set; }

        public decimal longitude { get; set; }

        public string locale { get; set; }
    }

    public class AutocompleteResponse
    {
        public List<Term> terms { get; set; }

        public List<Business> businesses { get; set; }

        public List<Category> categories { get; set; }
    }

    public class Term
    {
        public string text { get; set; }
    }
}
