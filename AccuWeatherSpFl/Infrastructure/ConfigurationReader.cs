using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpecFlowProject1
{
    public static class ConfigurationReader
    {
        public static IConfiguration Configuration;
        static ConfigurationReader()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine("specflow.json"))
                .AddEnvironmentVariables();
            Configuration = configurationBuilder.Build(); 
        }
        public static string GetValue(string key)
        {
            string result = Configuration.GetSection("config").GetSection(key).Value;
            return result;
        }
    }
}
