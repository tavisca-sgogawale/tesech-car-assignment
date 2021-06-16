using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Common
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<ErrorInfo> Info { get; set; }
        public Error(string code, string msg, List<ErrorInfo> info)
        {
            Code = code;
            Message = msg;
            Info = info;

        }
    }
}
