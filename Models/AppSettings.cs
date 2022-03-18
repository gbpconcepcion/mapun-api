namespace mapun_api.Models
{
    public class AppSettings
    {
        public string KeyCloak_baseUrl { get; set; }
        public string KeyCloak_realm { get; set; }
        public string KeyCloak_realmId { get; set; }
        public string KeyCloak_secret { get; set; }
        public string Default_Password { get; set; }
    }
}