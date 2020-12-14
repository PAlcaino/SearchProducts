using DataAccess;
using DataAccess.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProductsSearch.Api;
using ProductsSearch.Core.Dto;
using ProductsSearch.Core.Entities;
using ProductsSearch.Core.Operations;
using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductsUseCase;
using ProductsSearch.Core.UseCases.ProductsUseCases.GetProductUseCase;
using ProductsSearch.Infrastructure;
using ProductsSearch.Infrastructure.Helpers;
using ProductsSearch.Infrastructure.Interfaces;
using ProductsSearch.Infrastructure.Operations;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

[assembly: FunctionsStartup(typeof(Startup))]
namespace ProductsSearch.Api
{
    /// <summary>
    /// Punto de entrada de la Function
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup : FunctionsStartup
    {
        private IConfigurationRoot _functionConfig = null;

        private IConfigurationRoot FunctionConfig(string appDir) =>
            _functionConfig ??= new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(appDir, "global.settings.json"), optional: false, reloadOnChange: true)
                .Build();

        /// <summary>
        /// Configura las depedencias
        /// </summary>        
        public override void Configure(IFunctionsHostBuilder builder)
        {
            new ConfigurationBuilder()
              .SetBasePath(Environment.CurrentDirectory)
              .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .Build();

            //Create settings
            builder.Services.AddOptions<ResponsesSettings>()
                .Configure<IOptions<ExecutionContextOptions>>((mlSettings, exeContext) =>
                 FunctionConfig(exeContext.Value.AppDirectory).Bind("ResponsesSettings", mlSettings));

            builder.Services.AddSingleton(s =>
            {
                return MappingProfileConfig.Activate();
            });

            //Services
            builder.Services.AddScoped<IDataAccess, MongoDataAccess>();
            builder.Services.AddScoped<IMongoDBHelper, MongoDBHelper>();

            //Operations
            builder.Services.AddScoped<IGetListFromRepository<Product>, GetProductsFromRepository>();
            builder.Services.AddScoped<IGetPagedListFromRepository<Product>, GetPagedProductsFromRepository>();

            //Use cases
            builder.Services.AddScoped<IGetProductsUseCase, GetProductsUseCase>();

            builder.Services.AddLogging();
        }
    }
}
