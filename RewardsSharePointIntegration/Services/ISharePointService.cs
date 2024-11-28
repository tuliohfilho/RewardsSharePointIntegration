using Microsoft.Graph.Models;

namespace RewardsSharePointIntegration.Services;

public interface ISharePointService
{
    Task<MessageCollectionResponse?> GetMeAsync();
    //Task<List<DriveItem>> GetSharePointDocumentsAsync(string siteId, string driveId);
}