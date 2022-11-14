using Core.Business.Entites.ResponseModels;
using Core.Business.Entites.Utils;
using Core.Common.Settings;
using Microsoft.WindowsAzure.Storage;

namespace Core.Business.Services.Concrete {
    public class BlobStorageService {

        private readonly static string _blobStorageAccount = GlobalSettings.BlobStorageAccount;
        private readonly static string _blobContainerName = GlobalSettings.BlobContainerName;
        public string UploadFileToAzureBlob(string fileIdentifier, byte[] fileData) {
            try {
                string uri = null;
                var directoryName = "";
                // Retrieve storage account from connection string.
                var storageAccount = CloudStorageAccount.Parse(_blobStorageAccount);

                // Create the blob client.
                var blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve reference to a previously created container.
                var container = blobClient.GetContainerReference(_blobContainerName);
                var resourceContainer = !string.IsNullOrWhiteSpace(directoryName)
                    ? directoryName + "/" + fileIdentifier
                    : fileIdentifier;

                var blockBlob = container.GetBlockBlobReference(resourceContainer);

                //Todo : Dharminder  MimeMapping.GetMimeMapping
                // blockBlob.Properties.ContentType = MimeMapping.GetMimeMapping(fileIdentifier);
                blockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);

                uri = blockBlob.Uri.AbsoluteUri;
                return uri;
            } catch (Exception) { return null; }
        }

        public string GetBlobLinkByFileIdentifier(string fileIdentifier) {
            var directoryName = "";

            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(_blobStorageAccount);

            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            var container = blobClient.GetContainerReference(_blobContainerName);
            var resourceContainer = !string.IsNullOrWhiteSpace(directoryName)
                ? directoryName + "/" + fileIdentifier
                : fileIdentifier;

            var blockBlob = container.GetBlockBlobReference(resourceContainer);
            return blockBlob.Uri.AbsoluteUri;
        }

        public FileUpload UploadFileToBlob(string fileName, byte[] fileData) {
            FileUpload response = null;
            var fileIdentifier = GetUniqueFileName(fileName);

            string uri = UploadFileToAzureBlob(fileIdentifier, fileData);
            if (!string.IsNullOrWhiteSpace(uri)) {
                response = new FileUpload();
                response.FileName = fileName;
                response.FileIdentifier = fileIdentifier;
                response.FileLink = uri;
            }
            return response;
        }


        private string GetUniqueFileName(string fileName) {
            var rand = new Random();
            var firstGuid = Guid.NewGuid().ToString().Split('-')[rand.Next(0, 4)];
            var secondGuid = Guid.NewGuid().ToString().Split('-')[rand.Next(0, 4)];
            fileName = fileName.GenerateSlug();
            fileName = Path.GetFileNameWithoutExtension(fileName) + Path.GetExtension(fileName);
            return $"{firstGuid}-{secondGuid}-{fileName}";
        }
    }
}
