using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;



namespace myApp
{
    public class LogEntryUploader
    {
        private static string EndpointUrl = "https://pellefrykman-cosmos1.documents.azure.com:443/";
        private static string PrimaryKey = "bdYhxMzTOl6uGrmm3yg4i02b5Fp6lqvvKw8Mpr8goi52YrSiMjcQb2ImDG0ffGZ3vC97cw4PouSUel6xq5liEg==";

        public static void UploadToCosmos(LogEntryInformation logEntryInfo) {
            DocumentClient client = new DocumentClient(new Uri(LogEntryUploader.EndpointUrl), LogEntryUploader.PrimaryKey);
            client.CreateDatabaseIfNotExistsAsync(new Database { Id = "LogTracerEntry" }).Wait();

            client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("LogTracerEntry"), new DocumentCollection { Id = "Entries" }).Wait();
            client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("LogTracerEntry", "Entries"), logEntryInfo).Wait();
            
        }
    }
}
