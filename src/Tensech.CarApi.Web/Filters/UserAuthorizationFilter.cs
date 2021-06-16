using Tensech.CarApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using Tensech.CarApi.Services;
using Tensech.CarApi.Services.Contract;


using System.Threading.Tasks;

namespace Tensech.CarApi.Web
{
    public class UserAuthorizationFilter : IAuthorizationFilter
    {
        private readonly ITokenService _tokenService;

        public UserAuthorizationFilter(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
             CallContext.Current.Headers.TryGetValue(KeyStore.Headers.Authorization, out string token);
            if (string.IsNullOrEmpty(token) == true)
                throw Errors.ClientSide.InvalidFieldValue(KeyStore.Headers.Authorization);

            AuthTokenResponse response = null;
            try
            {
                response = _tokenService.ValidateTokenAync(token).ConfigureAwait(false).GetAwaiter().GetResult();
               
            }
            catch (BaseApplicationException ex)
            {
                //log exception. since we want to override the exception
                if(ex.ErrorCode.Equals(FaultCodes.ExpiredToken))
                    throw Errors.ClientSide.InvalidHeader(KeyStore.Headers.Authorization);

                throw;
            }
            catch (Exception ex)
            {
                //log exception. since we want to override the exception               
                    throw Errors.ServerSide.InternalServerError();
            }
            if (response == null || string.IsNullOrEmpty(response.UserId) == true)
            {
                throw Errors.ClientSide.InvalidHeader(KeyStore.Headers.Authorization);
            }
            CallContext.Current.SetUserId(response.UserId);
            CallContext.Current.SetToken(response.Token);
        }
    }
}
