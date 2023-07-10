using GlobalAI.FileDomain.Interfaces;
using GlobalAI.FileEntities.Dto.UploadFile;
using GlobalAI.Utils;
using GlobalAI.Utils.Controllers;
using GlobalAI.Utils.Net.MimeTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalAI.FileAPI.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : BaseController
    {
        private readonly IFileServices _fileServices;
        public FileController(IFileServices fileServices)
        {
            _fileServices = fileServices;
        }

        /// <summary>
        /// Get File
        /// </summary>
        /// <returns></returns>
        [Route("get")]
        [HttpGet]
        public IActionResult GetFile([FromQuery] string folder, [FromQuery] string file, [FromQuery] bool download)
        {
            try
            {
                var result = _fileServices.GetFile(folder, file);

                if (download)
                {
                    return File(result, MimeTypeNames.ApplicationOctetStream, file);
                }
                return FileByFormat(result, file);
            }
            catch (Exception ex)
            {
                return Ok(OkException(ex));
            }
        }

        /// <summary>
        /// Upload File
        /// </summary>
        /// <returns></returns>
        [Route("upload")]
        [DisableRequestSizeLimit]
        [HttpPost]
        //[Authorize]
        public APIResponse UploadFile(IFormFile file, [FromQuery] string folder)
        {
            try
            {
                var result = _fileServices.UploadFile(new UploadFileDto
                {
                    File = file,
                    Folder = folder,
                });
                return new APIResponse(Utils.StatusCode.Success, result, 200, "Ok");
            }
            catch (Exception ex)
            {
                return OkException(ex);
            }
        }
    }
}
