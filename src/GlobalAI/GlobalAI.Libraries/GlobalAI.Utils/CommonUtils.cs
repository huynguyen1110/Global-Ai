using Shared = GlobalAI.Utils.ConstantVariables.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GlobalAI.Utils
{
    public static class CommonUtils
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes); // .NET 5 +
            }
        }

        public static string RandomNumber(int length = 6)
        {
            Random random = new Random();
            const string chars = "0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetCurrentRemoteIpAddress(IHttpContextAccessor httpContextAccessor)
        {
            string senderIpv4 = null;
            try
            {
                senderIpv4 = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                if (httpContextAccessor.HttpContext.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedIps))
                {
                    senderIpv4 = forwardedIps.FirstOrDefault();
                }
            }
            catch
            {
            }
            return senderIpv4;
        }

        public static string GetCurrentXForwardedFor(IHttpContextAccessor httpContextAccessor)
        {
            string forwardedIpsStr = null;
            try
            {
                if (httpContextAccessor.HttpContext.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedIps))
                {
                    forwardedIpsStr = JsonSerializer.Serialize(forwardedIps.ToList());
                }
            }
            catch
            {
            }
            return forwardedIpsStr;
        }

        public static string GetCurrentUsername(IHttpContextAccessor httpContextAccessor)
        {
            var usr = httpContextAccessor.HttpContext?.User.FindFirst(Shared.ClaimTypes.Username);
            return usr != null ? usr.Value : "";
        }

        public static int GetCurrentUserId(IHttpContextAccessor httpContextAccessor)
        {
            var claims = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var claim = claims?.FindFirst(Shared.ClaimTypes.UserId);
            if (claim == null)
            {
                throw new FaultException(new FaultReason($"Tài khoản không chứa claim \"{Shared.ClaimTypes.UserId}\""),
                    new FaultCode(((int)ErrorCode.NotHaveClaim).ToString()), "");
            }
            int userId = int.Parse(claim.Value);
            return userId;
        }

        public static int GetCurrentGPoint(IHttpContextAccessor httpContextAccessor)
        {
            var claims = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var claim = claims?.FindFirst(Shared.ClaimTypes.GPoint);
            if (claim == null)
            {
                throw new FaultException(new FaultReason($"Tài khoản không chứa claim \"{Shared.ClaimTypes.GPoint}\""),
                    new FaultCode(((int)ErrorCode.NotHaveClaim).ToString()), "");
            }
            int userId = int.Parse(claim.Value);
            return userId;
        }

        public static string GetCurrentRole(IHttpContextAccessor httpContextAccessor)
        {
            var claims = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var claim = claims?.FindFirst(Shared.ClaimTypes.Role);
            if (claim == null)
            {
                throw new FaultException(new FaultReason($"Tài khoản không chứa claim \"{Shared.ClaimTypes.Role}\""),
                    new FaultCode(((int)ErrorCode.NotHaveClaim).ToString()), "");
            }
            return claim?.Value;
        }
        public static TService GetService<TService>(IHttpContextAccessor httpContextAccessor) where TService : class
        {
            var service = httpContextAccessor.HttpContext.RequestServices.GetService(typeof(TService)) as TService;
            if (service == null)
            {
                throw new FaultException(new FaultReason($"Không lấy được service: {typeof(TService)}"),
                    new FaultCode(((int)ErrorCode.GetRequestService).ToString()), "");
            }
            return service;
        }
    }
}
