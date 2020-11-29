using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.WebApp.Infrastructure.Abstract;

namespace Vic.SportsStore.WebApp.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private EFDbContext context = new EFDbContext();

        public bool Authenticate(string username, string password)
        {
            //#pragma warning disable CS0618 // Type or member is obsolete
            //            bool result = FormsAuthentication.Authenticate(username, password);
            //#pragma warning restore CS0618 // Type or member is obsolete

            bool result = false;

            var user = context
                .AdminUsers
                .FirstOrDefault(x => x.Username == username);

            if (user != null && user.Password == password)
            {
                result = true;
            }

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }

}