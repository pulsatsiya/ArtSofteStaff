using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizeWebAPI.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "VladimirPolyakov"; 
        public const string AUDIENCE = "AuthClient"; 
        const string KEY = "hZUOAanC1997!";   
        public const int LIFETIME = 1; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
