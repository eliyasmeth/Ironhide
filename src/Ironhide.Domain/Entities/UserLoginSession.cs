using System;
using System.Linq;
using AcklenAvenue.Commands;

namespace Ironhide.Users.Domain.Entities
{
    public class UserLoginSession : Entity, IUserSession
    {
        protected UserLoginSession()
        {            
        }

        public UserLoginSession(Guid token, User user, DateTime expires, string jwtToken)
        {
            Id = token;
            User = user;
            Expires = expires;
            JwtToken = jwtToken;
            Claims = string.Join(",", user.UserRoles.Select(x => x.Description));
        }

        public virtual User User { get; protected set; }
        public virtual DateTime Expires { get; protected set; }
        public virtual string Claims { get; protected set; }
        public virtual string JwtToken { get; protected set; }

        public virtual string[] GetClaimsAsArray()
        {

            return Claims.Split(',');
        }

    }
}