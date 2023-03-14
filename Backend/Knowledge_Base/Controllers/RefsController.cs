using BusinessLogicLayer.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Knowledge_Base.Controllers
{
    [Route("refs")]
    public class RefsController : Controller
    {
        private IReferenceService service;
        public RefsController(IReferenceService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll() 
        {
            var response = service.GetAll();
            byte[] data;
            Response.Headers.Add("Content-Type", "application/octet-stream");
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Response.StatusCode = (int)response.StatusCode;
                data = Encoding.UTF8.GetBytes(response.Description);
                await Response.Body.WriteAsync(data,0,data.Length);
                return new EmptyResult();
            }
            else
            {
                Response.StatusCode=(int)response.StatusCode;
                string json;
                foreach(var item in response.Data) 
                {
                    json = JsonSerializer.Serialize(item, typeof(Reference));
                    data = Encoding.UTF8.GetBytes(json);
                    await Response.Body.WriteAsync(data, 0, data.Length);
                    await Response.Body.FlushAsync();
                }
                return new EmptyResult();
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetByNoteId([FromRoute]int id)
        {
            var response = service.GetByNoteId(id);
            if (response.StatusCode != HttpStatusCode.OK && response.Data.Count()>0)
                return StatusCode((int)response.StatusCode, response.Description);
            return Json(response.Data);
        }
        /*[HttpDelete("{id:int}")]
        public IActionResult DeleteByNoteId([FromRoute]int id)
        { 
            var response = service.DeleteByNoteId(id);
            if(response.StatusCode != HttpStatusCode.OK)
                return StatusCode((int)response.StatusCode,response.Description);
            return Json(response.Data);
        }*/
    }
}
