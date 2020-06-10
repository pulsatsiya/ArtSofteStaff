using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtSofteStaff
{
    public class AuthOptions
    {
        public const string ISSUER = "VovaPolyakov"; 
        public const string AUDIENCE = "Client"; 
        const string KEY = "hZUOAanC1997!";   
        public const int LIFETIME = 2; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
