using italk.BL.Dtos.UploadFileDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace italk.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("UploadImage")]
        public ActionResult<UploadFileDto> UploadImage(IFormFile file)
        {
            return ProcessUploadedFile(file, "Images");
        }

        [HttpPost("UploadCourseImage")]
        public ActionResult<UploadFileDto> UploadCourseImage(IFormFile file)
        {
            return ProcessUploadedFile(file, "Courses");
        }
        [HttpPost("UploadCertificate")]
        public ActionResult<UploadFileDto> UploadCertificate(IFormFile file)
        {
            return ProcessUploadedFile(file, "Certificates");
        }
        private ActionResult<UploadFileDto> ProcessUploadedFile(IFormFile file, string subFolder)
        {
            #region Checking Extension

            var extension = Path.GetExtension(file.FileName);

            var allowedExtensions = new string[]
            {
            ".png",
            ".jpg",
            ".svg"
            };

            bool isExtensionAllowed = allowedExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return BadRequest(new UploadFileDto(false, "Extension is not valid"));
            }

            #endregion

            #region Checking Length

            bool isSizeAllowed = file.Length > 0 && file.Length <= 4_000_000;
            if (!isSizeAllowed)
            {
                return BadRequest(new UploadFileDto(false, "Size is not allowed"));
            }

            #endregion

            #region Storing The File

            var newFileName = $"{Guid.NewGuid()}{extension}";
            var filesPath = Path.Combine(Environment.CurrentDirectory, $"Files/{subFolder}");
            var fullFilePath = Path.Combine(filesPath, newFileName);

            using var stream = new FileStream(fullFilePath, FileMode.Create);
            file.CopyTo(stream);

            #endregion

            #region Generating URL

            var url = $"{Request.Scheme}://{Request.Host}/Files/{subFolder}/{newFileName}";
            return new UploadFileDto(true, "Success", url);

            #endregion
        }
    }
}
