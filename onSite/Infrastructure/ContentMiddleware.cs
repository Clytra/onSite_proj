using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace onSite.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate _nextDelegate;
        private UptimeService _uptime;

        public ContentMiddleware(RequestDelegate next, UptimeService up)
        {
            _nextDelegate = next;
            _uptime = up;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync(
                    "Ten komunikat pochodzi z oprogramowania pośredniczącego: " +
                        $"(uptime: {_uptime.Uptime}ms)", Encoding.UTF8);
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}
