using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Services.Contract;


namespace Tensech.CarApi.Services
{
    public class TokenService : ITokenService
    {
        public async Task<AuthTokenResponse> ValidateTokenAync(string token)
        {
            //returning hardcoded values for now it will get modified after real token service will be in picture
            return new AuthTokenResponse
            {
                CreatedOn = DateTime.Now.Date,
                ExpiresOn = DateTime.Now.AddHours(3),
                Token = token,
                UserId = "testUser"

            };
        }
    }
}
