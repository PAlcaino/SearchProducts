namespace ProductsSearch.Core.Tests
{
    using Microsoft.Extensions.Configuration;
    using ProductsSearch.Core.Dto;
    using System.IO;

    /// <summary>
    /// Configuration Settings Helper
    /// </summary>
    public static class TestsConfigurationHelper
    {
        public static ResponsesSettings _responsesSettings;

        /// <summary>
        /// Returns Responses Settings
        /// </summary>
        public static ResponsesSettings ResponsesSettings
        {
            get
            {
                if (_responsesSettings != null)
                {
                    return _responsesSettings;
                }

                var configurationRoot = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("global.settings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                _responsesSettings = new ResponsesSettings();
                configurationRoot.Bind("ResponsesSettings", _responsesSettings);

                return _responsesSettings;
            }
        }
    }
}
