using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.DataLake.Store;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;
using System.IO;

namespace ADL.Handlers
{
    public class ADLHandler
    {
        //Azure active directory is coupled to a specific site, this is linked to http://www.mikaelstrid.net
        private static string applicationId = "22c5f7fb-be6a-405a-83ff-5618749f057f"; //Azure active directory Application ID  
        private static string clientSecret = "s4UF+48RiF6/knup/kscBiE/JcX+vCTr46MbOUaD7sg="; //Azure active directory AuthToken
        private static string tenantId = "c2d1d060-ad81-4403-b7a3-1ac5cd90d52d"; //Azure active directory tenant
        private static string adlsAccountFQDN = "mikaelstestdatalake.azuredatalakestore.net"; //Datalake Storage URL

        internal static void ADLsetup()
        {
            var creds = new ClientCredential(applicationId, clientSecret);
            var clientCreds = ApplicationTokenProvider.LoginSilentAsync(tenantId, creds).GetAwaiter().GetResult();

            throw new NotImplementedException();
        }
    }
}