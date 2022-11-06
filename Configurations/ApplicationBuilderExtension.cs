namespace GlobalErrorApi.Configurations
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<GlobalExceptionHandlignMiddleware>();
    }
}