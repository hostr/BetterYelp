using BetterYelp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models.Entities
{
    public class Search
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Location { get; set; }

        public static Search DtoToEntity(SearchViewModel vm)
        {
            return new Search
            {
                Term = vm.Term,
                Location = vm.Location                
            };
        }
    }
}
