using DBModel_DAL;
using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication4.App_Start
{
    public class AuthorizeCustom : AuthorizeAttribute
    {
        public AuthorizeCustom(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //base.OnAuthorization(filterContext);
            if (HttpContext.Current.Request.Cookies[".ASPXAUTH"] != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[".ASPXAUTH"].Value);
                var role = JsonConvert.DeserializeObject<UserModel>(ticket.UserData).Role.ToString();
                if (string.IsNullOrEmpty(Roles) || Roles.Contains(role))
                    return true;
                else
                {
                    return false;
                }
            }
            else
            {
                httpContext.Response.Redirect("~/Login/");
                return false;
            }
        }
    }
}