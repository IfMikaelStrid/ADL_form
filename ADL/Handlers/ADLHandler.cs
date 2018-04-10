using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.DataLake.Store;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;
using System.IO;
using System.Web.Services.Description;
using ADL.Models;

namespace ADL.Handlers
{
    public class ADLHandler
    {
        //Azure active directory is coupled to a specific site, this is linked to http://www.mikaelstrid.net
        private static string applicationId = "22c5f7fb-be6a-405a-83ff-5618749f057f"; //Azure active directory Application ID  
        private static string clientSecret = "s4UF+48RiF6/knup/kscBiE/JcX+vCTr46MbOUaD7sg="; //Azure active directory AuthToken
        private static string tenantId = "c2d1d060-ad81-4403-b7a3-1ac5cd90d52d"; //Azure active directory tenant
        private static string adlsAccountFQDN = "mikaelstestdatalake.azuredatalakestore.net"; //Datalake Storage URL
        private static string fileName = "/DataLakeLunch.csv";



        public async Task<AdlsClient> GetAdlCredentials()
        {
            try
            {
                // Obtain AAD token
                var creds = new ClientCredential(applicationId, clientSecret);

                // Create ADLS client object
                var clientCreds = await ApplicationTokenProvider.LoginSilentAsync(tenantId, creds);
                AdlsClient client = AdlsClient.CreateClient(adlsAccountFQDN, clientCreds);
                return client;
            }
            catch (AdlsException e)
            {
                PrintAdlsException(e);
                return null;
            }
        }

        public void CreateFile(AdlsClient client)
        {
            using (var streamWriter = new StreamWriter(client.CreateFile(fileName, IfExists.Overwrite)))
            {
                var row = $"Name:, " +
                          $"Age:, " +
                          $"Country:, " +
                          $"Town:, " +
                          $"Favorite color:";
                streamWriter.WriteLine(row);
            }
        }

        public void CreateFile(AdlsClient client, string newfilename, string content)
        {
            using (var streamWriter = new StreamWriter(client.CreateFile(newfilename, IfExists.Overwrite)))
            {
                var row = $"{content}";
                streamWriter.WriteLine(row);
            }
        }
        public void AppendToFile(AdlsClient client, FormValues formValues)
        {
            //Append to existing file
            using (var streamWriter = new StreamWriter(client.GetAppendStream(fileName)))
            {
                var row = $"{formValues.FirstName}, " +
                          $"{formValues.Age}, " +
                          $"{formValues.Country}, " +
                          $"{formValues.Town}, " +
                          $"{formValues.FavoriteColor}";
                streamWriter.WriteLine(row);
            }
        }

        public void ReadFromFile(AdlsClient client)
        {
            // Read file contents
            using (var readStream = new StreamReader(client.GetReadStream(fileName)))
            {
                string line;
                while ((line = readStream.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void GetFileProperties(AdlsClient client)
        {
            // Get the properties of the file
            var directoryEntry = client.GetDirectoryEntry(fileName);
            PrintDirectoryEntry(directoryEntry);
        }

        public void RenameFile(AdlsClient client)
        {
            // Rename a file
            string destFilePath = "/Test/testRenameDest3.txt";
            client.Rename(fileName, destFilePath, true);
        }

        public void EnumerateDirectory(AdlsClient client)
        {
            // Enumerate directory
            foreach (var entry in client.EnumerateDirectory("/Test"))
            {
                PrintDirectoryEntry(entry);
            }
        }

        public void DeleteDirectory(AdlsClient client)
        {
            // Delete a directory and all it's subdirectories and files
            client.DeleteRecursive("/Test");
        }

        private static void PrintDirectoryEntry(DirectoryEntry entry)
        {
            Console.WriteLine($"Name: {entry.Name}");
            Console.WriteLine($"FullName: {entry.FullName}");
            Console.WriteLine($"Length: {entry.Length}");
            Console.WriteLine($"Type: {entry.Type}");
            Console.WriteLine($"User: {entry.User}");
            Console.WriteLine($"Group: {entry.Group}");
            Console.WriteLine($"Permission: {entry.Permission}");
            Console.WriteLine($"Modified Time: {entry.LastModifiedTime}");
            Console.WriteLine($"Last Accessed Time: {entry.LastAccessTime}");
            Console.WriteLine();
        }

        private static void PrintAdlsException(AdlsException exp)
        {
            Console.WriteLine("ADLException");
            Console.WriteLine($"   Http Status: {exp.HttpStatus}");
            Console.WriteLine($"   Http Message: {exp.HttpMessage}");
            Console.WriteLine($"   Remote Exception Name: {exp.RemoteExceptionName}");
            Console.WriteLine($"   Server Trace Id: {exp.TraceId}");
            Console.WriteLine($"   Exception Message: {exp.Message}");
            Console.WriteLine($"   Exception Stack Trace: {exp.StackTrace}");
            Console.WriteLine();
        }

    }
}