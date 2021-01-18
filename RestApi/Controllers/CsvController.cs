using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sandbox.AngularUX.Controllers
{
	[Route("api/[controller]")]
	public class CsvController : Controller
	{
		private ICsvLogic _logic;

		public CsvController(ICsvLogic logic)
		{
			_logic = logic;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Upload(CancellationToken token)
		{
			IFormFile file = Request.Form.Files[0];

			Console.WriteLine($"*** Uploaded file length: {file?.Length}");

			if (file.Length > 0)
			{
				await _logic.InsertCsvData(file.OpenReadStream(), token);
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> Table(CancellationToken token)
		{
			JsonResult result = new JsonResult(await _logic.GetData(token));
			return result;
		}
	}
}
