using Microsoft.AspNetCore.Mvc;
using RewardsSharePointIntegration.Services;

namespace RewardsSharePointIntegration.Controllers;

[ApiController]
[Route("[controller]")]
public class SharePointController(
    ISharePointService sharePointService
) : ControllerBase
{
    [HttpGet("me")]
    public async Task<IActionResult> GetMeAsync() =>
        Ok(
            await sharePointService.GetMeAsync()
        );

    //[HttpGet("files")]
    //public async Task<IActionResult> ListFiles(string siteId, string libraryId)
    //{
    //    var files = await sharePointService.GetSharePointDocumentsAsync(siteId, libraryId);
    //    return Ok(files);
    //}


    //[HttpGet("files")]
    //public async Task<IActionResult> ListFiles(string siteId, string libraryId)
    //{
    //    var files = await sharePointService.ListFilesInDocumentLibrary(siteId, libraryId);
    //    return Ok(files);
    //}

    //[HttpPost("upload")]
    //public async Task<IActionResult> UploadFile(IFormFile file, string siteId, string libraryId)
    //{
    //    using var stream = file.OpenReadStream();
    //    await sharePointService.UploadFile(siteId, libraryId, file.FileName, stream);
    //    return Ok();
    //}
}
