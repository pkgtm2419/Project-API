namespace ProjectAPI._Helpers
{
    public class HeaderMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("company", out var companyHeader) || companyHeader != "MYCOMPANY")
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                var errorResponse = new
                {
                    status = 400,
                    message = "Bad Request. Missing or incorrect 'company' header."
                };
                await context.Response.WriteAsJsonAsync(errorResponse);
                return;
            }
            await _next(context);
        }
    }
}
