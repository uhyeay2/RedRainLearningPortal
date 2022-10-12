using RedRainLearningPortal.Api.Middleware;

namespace RedRainLearningPortal.Api.Configuration
{
    public static class ApplicationBuilder
    {
        public static WebApplication BuildApp(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }
    }
}
