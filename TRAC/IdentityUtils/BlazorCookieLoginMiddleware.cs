using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRAC.IdentityUtils
{
    public class BlazorCookieLoginMiddleware<TUser> where TUser : class
    {
        #region Static Login Cache

        static IDictionary<Guid, LoginModel<TUser>> Logins { get; set; }
            = new ConcurrentDictionary<Guid, LoginModel<TUser>>();

        public static Guid AnnounceLogin(LoginModel<TUser> loginInfo)
        {
            loginInfo.LoginStarted = DateTime.Now;
            var key = Guid.NewGuid();
            Logins[key] = loginInfo;
            return key;
        }
        public static LoginModel<TUser> GetLoginInProgress(string key)
        {
            return GetLoginInProgress(Guid.Parse(key));
        }

        public static LoginModel<TUser> GetLoginInProgress(Guid key)
        {
            if (Logins.ContainsKey(key))
            {
                return Logins[key];
            }
            else
            {
                return null;
            }
        }

        #endregion

        private readonly RequestDelegate _next;

        public BlazorCookieLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SignInManager<TUser> signInMgr)
        {
            if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]);
                var info = Logins[key];

                var result = await signInMgr.PasswordSignInAsync(info.Login, info.Password, info.RememberMe, lockoutOnFailure: false);
                
                //Uncache password for security:
                info.Password = null;

                if (result.Succeeded)
                {
                    Logins.Remove(key);
                    context.Response.Redirect("/");
                    return;
                }

               
                else
                {
                   
                    await _next.Invoke(context);
                }
            }
           
            else if (context.Request.Path.StartsWithSegments("/logout"))
            {
                await signInMgr.SignOutAsync();
                context.Response.Redirect("/login");
                return;
            }

            //Continue http middleware chain:
            await _next.Invoke(context);
        }
    }
}
