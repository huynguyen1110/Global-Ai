using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.IdentitiyServerEntities.Dto
{
    public class ConnectTokenDto
    {
        /// <summary>
        /// password hoặc refresh_token
        /// </summary>
        [FromForm(Name = "grant_type")]
        public string GrantType { get; set; }

        [FromForm(Name = "username")]
        public string Username { get; set; }

        [FromForm(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// openid offline_access
        /// </summary>
        [FromForm(Name = "scope")]
        public string Scope { get; set; }

        [FromForm(Name = "refresh_token")]
        public string RefreshToken { get; set; }

    }
}
