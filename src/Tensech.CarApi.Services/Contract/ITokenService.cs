using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Services;

namespace Tensech.CarApi.Services.Contract
{
    public interface ITokenService
    {
        Task<AuthTokenResponse> ValidateTokenAync(string token);
    }
}
