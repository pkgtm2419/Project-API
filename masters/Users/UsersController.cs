using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WinDLMSClientApp._Models;

namespace WinDLMSClientApp.Masters.Users
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsers users, IWebHostEnvironment webHost) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResUser>> GetUsers([FromHeader] string company)
        {
            var user = HttpContext.Items["User"] as JWTModel;
            if (user?.CompanyID != company)
            {
                return Unauthorized(new { status = 401, message = "User does not belong to this data." });
            }
            var res = await users.GetUserAsync();
            return res.status switch
            {
                200 => Ok(res),
                404 => NotFound(res),
                _ => StatusCode(500, res)
            };
        }

        [HttpPost]
        public async Task<ActionResult<ResUser>> AddUser([FromForm] UsersModel req, IFormFile profileImage, [FromHeader] string company)
        {
            var user = HttpContext.Items["User"] as JWTModel;
            if (user?.CompanyID != company)
            {
                return Unauthorized(new { status = 401, message = "User does not belong to this data." });
            }
            try
            {
                if (profileImage != null)
                {
                    if (profileImage.ContentType.StartsWith("image/"))
                    {
                        if (!Directory.Exists(webHost.WebRootPath + "\\UploadFiles"))
                        {
                            Directory.CreateDirectory(webHost.WebRootPath + "\\UploadFiles");
                        }

                        using (FileStream fs = System.IO.File.Create(webHost.WebRootPath + "\\UploadFiles\\" + profileImage.FileName))
                        {
                            profileImage.CopyTo(fs);
                            req.ProfilePicture = $"/UploadFiles/{profileImage.FileName}";
                            fs.Flush();
                        }
                    }
                    else
                    {
                        return BadRequest(new ResUser
                        {
                            status = 400,
                            message = "Invalid image format"
                        });
                    }
                }
                var res = await users.AddUserAsync(req);
                return res.status switch
                {
                    200 => Ok(res),
                    404 => NotFound(res),
                    _ => StatusCode(500, res)
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new ResUser
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }
    }
}
