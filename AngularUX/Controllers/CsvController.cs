using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AngularUX.Controllers
{
    [Route("api/[controller]")]
    public class CsvController : Controller
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];

                Console.WriteLine($"*** Uploaded file length: {file?.Length}");
                
                if (file.Length > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
