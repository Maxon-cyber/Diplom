using Newtonsoft.Json;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace OnlineStore.Domain.User;

public sealed class UserParameters
{
    public const Role DEFAULT_ROLE = Role.User;

    private static readonly string _alphanumericCharacters = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToString()
                                                             + Enumerable.Range('A', 'A' - 'A' + 1).Select(c => (char)c).ToString()
                                                             + Enumerable.Range('0', '9' - '0' + 1).Select(c => (char)c).ToString()!;
    private UserParameters() { }

    public sealed class Login
    {
        private const int LENGTH_OF_LOGIN = 10;

        private Login() { }

        public static string Generate()
        {
            StringBuilder loginBuilder = new StringBuilder();
            Random random = new Random();

            for (int index = 0; index < LENGTH_OF_LOGIN; index++)
                loginBuilder.Append(_alphanumericCharacters[random.Next(_alphanumericCharacters.Length)]);

            for (int index = 0; index < LENGTH_OF_LOGIN; index++)
            {
                int randomIndex = index + (int)(random.NextDouble() * (LENGTH_OF_LOGIN - index));
                (loginBuilder[index], loginBuilder[randomIndex])
                    = (loginBuilder[randomIndex], loginBuilder[index]);
            }

            return loginBuilder.ToString();
        }
    }

    public sealed class Password
    {
        private static readonly int LENGTH_OF_PASSWORD = 10;

        private Password() { }

        public static string Generate()
        {
            StringBuilder loginBuilder = new StringBuilder();
            Random random = new Random();

            for (int index = 0; index < LENGTH_OF_PASSWORD; index++)
                loginBuilder.Append(_alphanumericCharacters[random.Next(_alphanumericCharacters.Length)]);

            for (int index = 0; index < LENGTH_OF_PASSWORD; index++)
            {
                int randomIndex = index + (int)(random.NextDouble() * (LENGTH_OF_PASSWORD - index));
                (loginBuilder[index], loginBuilder[randomIndex])
                    = (loginBuilder[randomIndex], loginBuilder[index]);
            }

            return loginBuilder.ToString();
        }
    }

    public sealed class UserGeolocation
    {
        public static async Task<Location> GetLocationAsync()
        {
            using HttpClient client = new HttpClient();

            string ipAddress = await client.GetStringAsync("https://api.ipify.org");
            string info = await client.GetStringAsync($"http://ipinfo.io/{ipAddress}");

            IpInfo ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);

            RegionInfo region = new RegionInfo(ipInfo.Country);
            ipInfo.Country = region.EnglishName;

            Location location = new Location();

            PropertyInfo[] locationProperties = location.GetType().GetProperties();
            PropertyInfo[] ipInfoProperties = ipInfo.GetType().GetProperties();

            foreach (PropertyInfo locationProperty in locationProperties)
            {
                PropertyInfo? ipInfoProperty = ipInfoProperties.FirstOrDefault(pi => pi.Name == locationProperty.Name);

                if (ipInfoProperty != null)
                    locationProperty.SetValue(location, ipInfoProperty.GetValue(ipInfo));
            }

            return location;
        }

        private sealed class IpInfo
        {
            [JsonProperty("hostname")]
            internal string Hostname { get; set; }

            [JsonProperty("street")]
            internal string Street { get; set; }

            [JsonProperty("city")]
            internal string City { get; set; }

            [JsonProperty("region")]
            internal string Region { get; set; }

            [JsonProperty("country")]
            internal string Country { get; set; }
        }
    }
}