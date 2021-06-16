using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tensech.CarApi.Services
{

    public class AuthTokenResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }

}
