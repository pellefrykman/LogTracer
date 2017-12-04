using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;



namespace myApp
{
    public class LogEntryUploader
    {
        private static string url = "https://pellefrykmanhelloworld.azurewebsites.net/api/LogTracerCreateEntry?code=G2CizTE9OH0lyznZFFzZM6akv9srSZtlKwMou7gLblYsA9E/ARDArA==";

        public static void Upload(LogEntryInformation logEntryInfo) {
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(logEntryInfo.ConvertToJson());
            client.PostAsync(url, content).Wait();
        }

        private static string EndpointUrl = "https://pellefrykman-cosmos1.documents.azure.com:443/";
        private static string PrimaryKey = "bdYhxMzTOl6uGrmm3yg4i02b5Fp6lqvvKw8Mpr8goi52YrSiMjcQb2ImDG0ffGZ3vC97cw4PouSUel6xq5liEg==";

        private static void UploadToCosmos(LogEntryInformation logEntryInfo) {
            DocumentClient client = new DocumentClient(new Uri(LogEntryUploader.EndpointUrl), LogEntryUploader.PrimaryKey);
            client.CreateDatabaseIfNotExistsAsync(new Database { id = "LogTracerEntry" });
            
        }
    }
}
