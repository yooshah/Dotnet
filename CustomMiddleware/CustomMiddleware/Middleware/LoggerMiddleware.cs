namespace CustomMiddleware.Middleware
{
    public class LoggerMiddleware
    {

        private readonly RequestDelegate _next;
        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Request Handled " + context.Request.Path);

            await _next(context);

            Console.WriteLine("Handling Completed");

        }
    }
}
