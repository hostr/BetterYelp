using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShouldGo.Data.Dtos
{
    public class AuthResponse
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public decimal expires_in { get; set; }
    }
}
