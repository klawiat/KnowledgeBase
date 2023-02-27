using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Response;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> notes;
        private readonly IRepository<Reference> references;
        public NoteService(IRepository<Note> notes, IRepository<Reference> references)
        {
            this.notes = notes;
            this.references = references;
        }
        public IResponse<bool> CreateNote(NoteDTO noteDTO)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<NoteDTO, Note>();
                }).CreateMapper();
                Note note = mapper.Map<NoteDTO, Note>(noteDTO);
                notes.Create(note);
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.OK, Data = true, Description = "Успех!" };
            }
            catch
            {
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.InternalServerError, Data = false, Description = "Ошибка!" };
            }
        }

        public IResponse<bool> DeleteNote(int id)
        {
            try
            {
                var note = notes.Get(id);
                if (note != null)
                {
                    notes.Delete(id);
                    return new BaseResponse<bool> { StatusCode = HttpStatusCode.OK, Description = "Успех!", Data = true };
                }
                else
                {
                    throw new Exception("Заметка отсутствует в системе!");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.InternalServerError, Description = ex.Message, Data = false };
            }
        }

        public IResponse<bool> EditNote(NoteDTO noteDTO)
        {
            try
            {
                Note note = notes.Get(noteDTO.Id);
                if (note == null)
                    throw new Exception("Заметка отсутствует в системе!");
                note.Title = noteDTO.Title;
                note.Content = noteDTO.Content;
                notes.Update(note);
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.OK, Data = true, Description = "Успех!" };
            }
            catch
            {
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.InternalServerError, Data = false, Description = "Ошибка!" };
            }
        }

        public IResponse<NoteDTO> GetNote(int id)
        {
            Note note = notes.Get(id);
            if (note == null)
            {
                BaseResponse<NoteDTO> response = new();
                response.StatusCode = HttpStatusCode.NotFound;
                response.Description = "Заметка с выбранным id не найдена";
                return response;
            }
            else
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Note, NoteDTO>();
                }).CreateMapper();
                NoteDTO transferNote = mapper.Map<Note, NoteDTO>(notes.Get(id));
                BaseResponse<NoteDTO> response = new();
                response.StatusCode = HttpStatusCode.OK;
                response.Data = transferNote;
                response.Description = "Успех!";
                return response;
            }
        }

        public IResponse<IEnumerable<NoteDTO>> GetNotes()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Note, NoteDTO>();
                }).CreateMapper();
                var notesDto = mapper.Map<IEnumerable<Note>, List<NoteDTO>>(notes.GetAll().OrderBy(item => item.Id));
                if (notesDto == null)
                    throw new Exception("Список пуст");
                return new BaseResponse<IEnumerable<NoteDTO>>() { StatusCode = HttpStatusCode.OK, Data = notesDto, Description = "Успех!" };
            }
            catch (Exception)
            {
                return new BaseResponse<IEnumerable<NoteDTO>> { StatusCode = HttpStatusCode.NotFound, Description = "Ошибка!" };
            }
        }
    }
}
