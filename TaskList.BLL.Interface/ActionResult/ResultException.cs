using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.BLL.Interface.ActionResult
{
    public class ResultException : Exception
    {
        public ResultException(string message) : base(message)
        {
        }
    }
}
