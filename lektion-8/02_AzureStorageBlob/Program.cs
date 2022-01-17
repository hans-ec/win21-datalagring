using _02_AzureStorageBlob.Services;

string filePath = @"C:\Users\HansMattin-Lassei\Desktop\demo\users.json";
string downloadPath = @"C:\Users\HansMattin-Lassei\Desktop\demo\downloads\users.json";
string connectionstring = "DefaultEndpointsProtocol=https;AccountName=win21220117;AccountKey=nqiNlosfLbITx2wzOM9cXGc5v5Qo76HoCz/Vu7sdI17o6Fo4GoxncVtzXjD5vI7GDUWuJ+ONKUIUaSU/alVaEA==;EndpointSuffix=core.windows.net";
string containerName = "tadaaa";

BlobService blobService = new BlobService(connectionstring);

var created = await blobService.UploadAsync(containerName, filePath);

var get = await blobService.GetAsync(containerName, "users.json");
await blobService.DownloadAsync(get, downloadPath);

var delete = await blobService.GetAsync(containerName, "users.json");
await blobService.DeleteAsync(delete);
