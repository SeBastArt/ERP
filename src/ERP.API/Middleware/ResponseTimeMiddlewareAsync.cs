using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Middleware
{
    /// <summary>
    /// ResponseTimeMiddlewareAsync
    /// </summary>
    public class ResponseTimeMiddlewareAsync
    {
        private const string X_RESPONSE_TIME_MS = "X-Response-Time-ms";

        private readonly RequestDelegate _next;

        /// <summary>
        /// ResponseTimeMiddlewareAsync
        /// </summary>
        /// <param name="next"></param>
        public ResponseTimeMiddlewareAsync(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// InvokeAsync
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task InvokeAsync(HttpContext context)
        {

            Stopwatch watch = new Stopwatch();

            watch.Start();

            context.Response.OnStarting(() =>
            {

                watch.Stop();

                long responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                context.Response.Headers[X_RESPONSE_TIME_MS] = responseTimeForCompleteRequest.ToString();

                return Task.CompletedTask;
            });

            return _next(context);
        }
    }
}
