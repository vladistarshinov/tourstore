using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TourStore.WebUI.Infrastructure.Abstract;

namespace TourStore.WebUI.Infrastructure.Concrete
{
    public class FormAuthProvider : IAuthProvider
    {
        public bool Authenticate(string Email, string Password)
        {
            bool result = FormsAuthentication.Authenticate(Email, Password);
            if (result)
                FormsAuthentication.SetAuthCookie(Email, false);
            return result;
        }
    }
}