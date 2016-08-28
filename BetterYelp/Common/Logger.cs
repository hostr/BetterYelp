using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Common
{
    public class Logger : ILogger
    {
        private ILog _logger;

        public Logger()
        {
            _logger = LogManager.GetLogger(this.GetType());
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }
    }
}
