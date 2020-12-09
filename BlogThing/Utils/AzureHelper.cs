using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogThing.Utils
{
    public class AzureHelper
    {
        private string connString { get; set; }
        private string folder { get; set; }
        public AzureHelper(string connectionString, string blobName)
        {
            connString = connectionString;
            folder = blobName;
        }

        public bool SaveToAzure(string fileName, System.IO.Stream stream)
        {
            // get the connection string
            // get the folder
            // upload the stream with the file name
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(connString);
                // Azure needs to know what folder you want to save in
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(folder);
                // Then, you can get a blob writer thing from azure
                containerClient.UploadBlob(fileName, stream);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        
        public bool DeleteFromAzure()
        {
            return false;
        }
    }
}
