using Microsoft.Extensions.Configuration;

namespace myApp
{
    public class Config
    {
        public string Path { get; set; }
        public string Filter { get; set; }
        public string Options { get; set; }

        public Config () {
            Path = "";
            Filter = "default";
            Options = "";
        }

        static public Config Parse(string ConfigPath)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(ConfigPath);
            IConfiguration configuration = configBuilder.Build();

            Config config = new Config();
            configuration.Bind(config);

            return config;
        }
    }
}
