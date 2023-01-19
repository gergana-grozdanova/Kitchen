using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Logging
{
   public interface ILogger
    {
        Task LogException(Exception ex);
        Task LogMessage(string message);
    }
}
