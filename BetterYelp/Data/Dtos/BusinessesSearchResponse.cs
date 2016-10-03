using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShouldGo.Data.Dtos
{
    public class BusinessesSearchResponse
    {
        public int total { get; set; }

        public List<Business> businesses { get; set; }
    }
}
