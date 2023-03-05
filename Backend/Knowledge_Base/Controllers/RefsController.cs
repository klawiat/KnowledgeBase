using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Knowledge_Base.Controllers
{
    [Route("refs")]
    public class RefsController : Controller
    {
        [HttpGet("{id:int}")]
        public IActionResult Index([FromRoute]int id, [FromServices]IReferenceService service)
        {
            var response = service.GetByNoteId(id);
            if (response.StatusCode != HttpStatusCode.OK)
                return StatusCode((int)response.StatusCode, response.Description);
            return Json(response.Data);
        }
    }
}
