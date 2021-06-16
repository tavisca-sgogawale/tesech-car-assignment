using System.Collections.Generic;

namespace Tensech.CarApi.Common
{
    public class ErrorInfo
    {
        public ErrorInfo(string code, string message)
        {
            Code = code;
            Message = message;
        }
        public ErrorInfo()
        {
           
        }

        public string Code { get; set; }
        public string Message { get; set; }
        
    }
}