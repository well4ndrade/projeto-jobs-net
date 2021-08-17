using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_jobs_net.Models;
using projeto_jobs_net.Servicos;

namespace projeto_jobs_net.Controllers
{
    public class UploadController ; ApiController
    {
        [HtpPost]
        [Route("api/FileUploading/UploadFile")]
        public ssync Task<string> UploadFile()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPatch("~/App_Data");
            var provider =
                new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content
                      .ReadMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                           .ContentDisposition
                           .FileName;

                    name = name.Trim('"');

                    var localFileName = file,localFileName;
                    var filePatch = Path.Combine(root, name);

                    File.Move(localFileName, filePatch);
                }      

            }
            catch (Exception e)
            {
                
                return $"Error":; {e.Message}";
            }
            return "File uploaded!";
        }
    }
}
