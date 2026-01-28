using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace FiinX.Localizer
{
    public static class LocalizerExtensions
    {
        private static ILocalizer _localizer = default!;

        public static IServiceCollection AddLocalizer(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                string enUSCulture = "en";
                var supportedCultures = new[]
                {
                    new CultureInfo(enUSCulture),
                    new CultureInfo("vi"),
                };
                options.DefaultRequestCulture = new RequestCulture(enUSCulture, enUSCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Clear();
                options.RequestCultureProviders.Add(new CustomRequestCultureProvider(context =>
                {
                    var lang = GetLang(context);
                    return Task.FromResult(new ProviderCultureResult(lang, lang));
                }));
            });
            services.AddSingleton<ILocalizer, Localizer>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));
            return services;
        }

        public static IApplicationBuilder UseLocalizer(this IApplicationBuilder app)
        {
            _localizer = app.ApplicationServices.GetRequiredService<ILocalizer>();
            app.UseRequestLocalization();
            return app;
        }

        /// <summary>
        /// Gets the string resource with the given name.
        /// </summary>
        public static string ToLocalizer(this string name)
        {
            return _localizer[name];
        }

        /// <summary>
        /// Gets the string resource with the given name and formatted with the supplied arguments.
        /// </summary>
        public static string ToLocalizer(this string name, params object[] arguments)
        {
            return _localizer[name, arguments];
        }

        /// <summary>
        /// Gets the string resource with the given name.
        /// </summary>
        public static string ToLocalizer<T>(this string name) where T : notnull
        {
            return _localizer.ToLocalizer<T>(name);
        }

        /// <summary>
        /// Gets the string resource with the given name and formatted with the supplied arguments.
        /// </summary>
        public static string ToLocalizer<T>(this string name, params object[] arguments) where T : notnull
        {
            return _localizer.ToLocalizer<T>(name, arguments);
        }

        private static string GetLang(HttpContext context)
        {
            var lang = context.Request.Headers["Language"];
            if (string.IsNullOrWhiteSpace(lang))
            {
                lang = context.Request.Query["Language"];
            }
            if (string.IsNullOrWhiteSpace(lang))
            {
                lang = "vi";
            }
            return lang;
        }
    }
}
