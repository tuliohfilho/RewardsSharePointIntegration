using Microsoft.Graph.Models;
using Microsoft.Graph;
using Microsoft.Graph.Me;

namespace RewardsSharePointIntegration.Services;

public class SharePointService(
    GraphServiceClient graphClient
) : ISharePointService
{
    public async Task<List<DriveItem>> ListFilesInDocumentLibrary(string siteId, string libraryId)
    { var items = await graphClient
            .Sites[siteId]
            .Drives[libraryId]
            .Root
            .Children
            .Request()
            .GetAsync();

        return items.ToList();
       
    }

    public async Task UploadFile(string siteId, string libraryId, string fileName, Stream fileStream)
    {
        await graphClient.Sites[siteId].Drives[libraryId].Root
            .ItemWithPath(fileName)
            .Content
            .Request()
            .PutAsync<DriveItem>(fileStream);
    }

    public async Task<List<DriveItem>> GetSharePointDocumentsAsync()
    {
        var driveItems = await graphClient
            .Users["user@domain.com"] // Ou Sites["siteId"] para SharePoint
            .Drive
            .Root
            .Children
            .GetAsync();

        return items.CurrentPage.ToList();
    }
}