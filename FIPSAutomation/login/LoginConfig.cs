using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace find_information_products_services_tests.FIPSAutomation.login
{
    public class LoginConfig
    {
        [JsonPropertyName("activeEnv")]
        public string ActiveEnv { get; set; } = string.Empty;

        [JsonPropertyName("loginRequired")]
        public bool LoginRequired { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("loginURL")]
        public string LoginURL { get; set; } = string.Empty;

        [JsonPropertyName("envs")]
        public List<EnvironmentDetail> Envs { get; set; } = new();
    }

    public class EnvironmentDetail
    {
        [JsonPropertyName("env")]
        public string Env { get; set; } = string.Empty;

        [JsonPropertyName("applicationURL")]
        public string ApplicationURL { get; set; } = string.Empty;

        [JsonPropertyName("oAuthURL")]
        public string OAuthURL { get; set; } = string.Empty;
    }
}
