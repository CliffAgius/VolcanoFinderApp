namespace VolcanoFinder.Services
{
    public class Constants
    {
        public static string RedirectUri = "msal17b9b17b-21da-449b-9ddd-997a4cabf968://auth";
        public static string ClientId = "17b9b17b-21da-449b-9ddd-997a4cabf968";
        public static string TenantId = "e801a3ad-3690-4aa0-a142-1d77cb360b07";
        //public static string iOSKeyChainSecurityGroup = "com.companyname.AuthWithAAD";
        public static string iOSKeyChainSecurityGroup = "com.CASoftware.VolcanoFinder";
        public static string[] Scopes = new string[] { "api://4e67e20f-1eaa-4aae-b09e-66ffae21dff7/access_cosmos_data" };

        public static readonly string APIURL = "https://cmapimdemo.azurewebsites.net/volcano";
    }
}
