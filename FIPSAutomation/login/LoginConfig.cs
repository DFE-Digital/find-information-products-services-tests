using System.Text.Json.Serialization;

namespace find_information_products_services_tests.FIPSAutomation.login
{
    public class LoginConfig
    {
        [JsonPropertyName("activeEnv")]
        public string ActiveEnv { get; set; }

        [JsonPropertyName("loginRequired")]
        public bool LoginRequired { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("loginURL")]
        public string LoginURL { get; set; }

        [JsonPropertyName("envs")]
        public List<EnvironmentDetail> Envs { get; set; } = new();
    }

    public class EnvironmentDetail
    {
        [JsonPropertyName("env")]
        public string Env { get; set; }

        [JsonPropertyName("applicationURL")]
        public string ApplicationURL { get; set; }

        [JsonPropertyName("oAuthURL")]
        public string OAuthURL { get; set; }
    }
}
