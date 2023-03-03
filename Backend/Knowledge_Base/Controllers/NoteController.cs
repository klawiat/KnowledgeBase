using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using Knowledge_Base.Interfaces;
using Knowledge_Base.Models.ViewModels;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Knowledge_Base.Controllers
{
    //[Route("Notes")]
    [Route("/")]
    public class NoteController : Controller
    {
        [HttpGet]
        [Route("/")]
        //[Route("All")]
        public IActionResult Index([FromServices] INoteService service, [FromServices] IMapper mapper)
        {
            var response = service.GetNotes();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)response.StatusCode, response.Description);
            }
            List<LeftMenuNoteViewModel> notes = mapper.Map<IEnumerable<NoteDTO>, List<LeftMenuNoteViewModel>>(response.Data);
            return Json(notes);
        }
        [HttpGet("{id:int}")]
        public IActionResult CurrentNote([FromRoute] int id, [FromQuery] bool raw, [FromServices] INoteService service, [FromServices] IMarkdown markdown, [FromServices] IMapper mapper)
        {
            var response = service.GetNote(id);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)response.StatusCode, response.Description);
            }
            NoteViewModel note = mapper.Map<NoteDTO, NoteViewModel>(response.Data);
            if (raw == false)
            {
                note.Content = markdown.ToHTML(note.Content);
            }
            return Json(note);
        }
        [HttpPost("/")]
        public IActionResult CreateNote([FromBody] NoteViewModel note, [FromServices] INoteService service, [FromServices] IMapper mapper)
        {
            if (ModelState.IsValid)
            {
                NoteDTO noteDTO = mapper.Map<NoteViewModel, NoteDTO>(note, opt => { opt.BeforeMap((view, dto) => { view.Id = 0; view.Id = 0; }); });
                var request = service.CreateNote(noteDTO);
                if (request.StatusCode != HttpStatusCode.OK)
                {
                    ModelState.AddModelError("Description", request.Description);
                    return StatusCode((int)request.StatusCode, request.Description);
                }
            }
            else
                return BadRequest();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public IActionResult EditNote([FromRoute] int id, [FromBody] NoteViewModel note, [FromServices] INoteService service, [FromServices] IMarkdown markdown, [FromServices] IMapper mapper)
        {
            if (ModelState.IsValid)
            {
                NoteDTO noteDTO = mapper.Map<NoteViewModel, NoteDTO>(note, opt => { opt.AfterMap((view, dto) => { view.Id = id; dto.Id = id; }); });
                var response = service.EditNote(noteDTO);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return StatusCode((int)response.StatusCode, response.Description);
                }
            }
            else
                return BadRequest();
            note.Content = markdown.ToHTML(note.Content);
            return Ok(note);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteNote([FromRoute] int id, [FromServices] INoteService service)
        {
            var response = service.DeleteNote(id);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)response.StatusCode, response.Description);
            }
            return Ok();
        }
    }
}
