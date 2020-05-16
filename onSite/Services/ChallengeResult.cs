using Microsoft.AspNetCore.Authentication;
using System.Web.Mvc;

namespace onSite.Services
{
    public class ChallengeResult : HttpUnauthorizedResult
    {
        private const string XsrfKey = "XsrfId";
        public ChallengeResult(string provider, string redirectUri)
            : this(provider, redirectUri, null) { }

        public ChallengeResult(string provider, string redirectUri, string userId)
        {
            LoginProvider = provider;
            RedirectUri = redirectUri;
            UserId = userId; 
        }

        public string LoginProvider { get; set; }
        public string RedirectUri { get; set; }
        public string UserId { get; set; }

        //public override void ExecuteResult(ControllerContext context)
        //{
        //    var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
        //    if(UserId != null)
        //    {
        //        properties.Dictionary[XsrfKey] = UserId;
        //    }
        //    context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        //}
    }
}
