using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ForgeExplorer.Models
{
    class Credentials
    {
        public string TokenInternal { get; set; }

        private Credentials() { }

        static public Credentials GetFromAdWebServices()
        {
            string revitPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            Assembly ssonet = Assembly.LoadFrom(revitPath + "\\SSONET.dll");

            object adWebServicesBase = ssonet.GetTypes()
                .First(q => q.FullName == "Autodesk.Revit.AdWebServicesBase")
                .GetMethod("GetInstance")
                .Invoke(null, null);

            string token = adWebServicesBase
                .GetType()
                .GetMethod("GetOAuth2AccessToken")
                .Invoke(adWebServicesBase, null) as string;

            Credentials credentials = new Credentials();
            credentials.TokenInternal = token;

            return credentials;
        }
    }
}
