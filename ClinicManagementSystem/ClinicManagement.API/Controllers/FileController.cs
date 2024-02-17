using ClinicManagement.Application;
using ClinicManagement.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpPost("Upload")]

        public async Task<SharedResponse<List<UploadedFile>>> Upload()
        {
            SharedResponse<List<UploadedFile>> sharedResponse = new();
            List<UploadedFile> uploadedFiles = new List<UploadedFile>();
            try
            {
                if (Request.HasFormContentType)
                {
                    string root = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                    if (!Directory.Exists(root))
                        Directory.CreateDirectory(root);

                    await Request.ReadFormAsync();

                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";


                    foreach (var file in Request.Form.Files)
                    {
                        string localFileName = Path.Combine(root, file.FileName);
                        await using (var stream = new FileStream(localFileName, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        uploadedFiles.Add(new UploadedFile
                        {
                            Name = Path.GetFileNameWithoutExtension(file.FileName)?.Split('_').FirstOrDefault(),
                            Path = $"{baseUrl}/uploads/{file.FileName}",
                        Extension = Path.GetExtension(file.FileName)?.TrimStart('.')
                        });
                    }
                    sharedResponse.Data = uploadedFiles;
                }
                else
                {
                    sharedResponse.Successed = false;
                    sharedResponse.Message = "error while uploading file";
                    //ResponseMessageHelper.BadRequest(sharedResponse.Message, sharedResponse);

                }
            }
            catch (Exception ex)
            {
                sharedResponse.Successed = false;
                sharedResponse.Message = ex.Message;
                //ResponseMessageHelper.ServerError(sharedResponse.Message, sharedResponse);
                
            }
            return sharedResponse;
        }
    }
}
