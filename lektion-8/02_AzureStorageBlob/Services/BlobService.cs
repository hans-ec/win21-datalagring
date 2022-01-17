using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AzureStorageBlob.Services
{
    internal class BlobService
    {
        private BlobServiceClient _blobServiceClient;
        private BlobContainerClient _containerClient;

        public BlobService(string connectionstring)
        {
            _blobServiceClient = new BlobServiceClient(connectionstring);
        }

        private async Task<BlobContainerClient> GetContainerClientAsync(string containerName)
        {
            try { return await _blobServiceClient.CreateBlobContainerAsync(containerName); }
            catch { return _blobServiceClient.GetBlobContainerClient(containerName); }
        }


        /// <summary>
        /// Uploads a blob object to a blob storage
        /// </summary>
        /// <param name="containerName">name of the container</param>
        /// <param name="filePath">the absolute path to the file</param>
        /// <returns>BlobClient object</returns>
        public async Task<BlobClient> UploadAsync(string containerName, string filePath)
        {
            _containerClient =  await GetContainerClientAsync(containerName);

            BlobClient blobClient = _containerClient.GetBlobClient(Path.GetFileName(filePath));
            await blobClient.UploadAsync(filePath, true);

            return blobClient;
        }

        public async Task<BlobClient> GetAsync(string containerName, string fileName)
        {
            _containerClient = await GetContainerClientAsync(containerName);
            return await Task.Run(() => _containerClient.GetBlobClient(fileName));
        }

        public async Task<List<BlobItem>> GetAllAsync()
        {
            var list = new List<BlobItem>();
            await foreach (var blobItem in _containerClient.GetBlobsAsync())
                list.Add(blobItem);

            return list;
        }

        public async Task DownloadAsync(BlobClient blobClient, string downloadPath)
        {
            await blobClient.DownloadToAsync(downloadPath);
        }

        public async Task DeleteAsync(BlobClient blobClient)
        {
            await blobClient.DeleteAsync();
        }
    }
}
