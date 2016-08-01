using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Business.Directors
{
    public class RequestDirector
    {
        private AuthDirector _authDirector;

        public RequestDirector (AuthDirector authDirector)
        {
            _authDirector = authDirector;
        }        
    }
}
