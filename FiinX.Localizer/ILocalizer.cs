using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace FiinX.Localizer
{
    public interface ILocalizer
    {
        string this[string name] { get; }
        string this[string name, params object[] arguments] { get; }

        string ToLocalizer<T>(string name) where T : notnull;
        string ToLocalizer<T>(string name, params object[] arguments) where T : notnull;
    }

    internal class Localizer : ILocalizer
    {
        private readonly IStringLocalizer<Localizer> _localizer;
        private readonly IServiceProvider _serviceProvider;

        public Localizer(IStringLocalizer<Localizer> localizer, IServiceProvider serviceProvider)
        {
            _localizer = localizer;
            _serviceProvider = serviceProvider;
        }

        public string this[string name] => _localizer[name];

        public string this[string name, params object[] arguments] => _localizer[name, arguments];

        public string ToLocalizer<T>(string name) where T : notnull
        {
            var localizer = _serviceProvider.GetRequiredService<IStringLocalizer<T>>();
            return localizer[name];
        }

        public string ToLocalizer<T>(string name, params object[] arguments) where T : notnull
        {
            var localizer = _serviceProvider.GetRequiredService<IStringLocalizer<T>>();
            return localizer[name, arguments];
        }
    }
}
