using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.MiddleWare
{
    public class BlockerMiddleware
    {
        private readonly RequestDelegate next;

        public BlockerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/Vehicle/id"))
            {
                context.Response.StatusCode = 403;
                return;
            }

            // do job 
            await next.Invoke(context);
        }
    }
}
