using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Response;
using DataLayer.EF;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _appDbContext;
        private DbSet<Note> notes;
        private DbSet<Reference> references;
        public NoteService(AppDbContext context)
        {
            this.notes = context.Notes;
            this.references = context.Refs;
            this._appDbContext = context;
        }
        /// <summary>
        /// Создает заметку и заносит её в базу данных
        /// </summary>
        /// <param name="noteDTO">Объект заметки</param>
        /// <returns>Объект содержащий статус код, описание(если произошла ошибка) и данные</returns>
        public IResponse<bool> CreateNote(NoteDTO noteDTO)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<NoteDTO, Note>();
                }).CreateMapper();
                Note note = mapper.Map<NoteDTO, Note>(noteDTO);
                notes.Add(note);
                _appDbContext.SaveChanges();
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.OK, Data = true, Description = "Успех!" };
            }
            catch
            {
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.InternalServerError, Data = false, Description = "Ошибка!" };
            }
        }
        /// <summary>
        /// Удаляет заметку из бд по выбранному идентификатору
        /// </summary>
        /// <param name="id">Идентификатор заметки</param>
        /// <returns>Объект содержащий статус код, описание(если произошла ошибка) и данные</returns>
        public IResponse<bool> DeleteNote(int id)
        {
            try
            {
                var note = notes.Find(id);
                if (note != null)
                {
                    notes.Remove(note);
                    _appDbContext.SaveChanges();
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
        /// <summary>
        /// Редактирует заметку в бд
        /// </summary>
        /// <param name="noteDTO">Объект заметки</param>
        /// <returns>Объект содержащий статус код, описание(если произошла ошибка) и данные</returns>
        public IResponse<bool> EditNote(NoteDTO noteDTO)
        {
            try
            {
                Note note = notes.Find(noteDTO.Id);
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
        /// <summary>
        /// Позволяет получить конкретну заметку по id
        /// </summary>
        /// <param name="id">Идентификатор заметки</param>
        /// <returns>Объект содержащий статус код, описание(если произошла ошибка) и данные</returns>
        public IResponse<NoteDTO> GetNote(int id)
        {
            Note note = notes.Find(id);
            if (note == null)
            {
                BaseResponse<NoteDTO> response = new() { StatusCode= HttpStatusCode.NotFound, Description = "Заметка с выбранным id не найдена"};
                return response;
            }
            else
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Note, NoteDTO>();
                }).CreateMapper();
                NoteDTO transferNote = mapper.Map<Note, NoteDTO>(note);
                return new BaseResponse<NoteDTO> { StatusCode=HttpStatusCode.OK,Data=transferNote,Description="Успех!"};
            }
        }
        /// <summary>
        /// Возвращает все заметки содержащиеся в бд
        /// </summary>
        /// <returns></returns>
        public IResponse<IEnumerable<NoteDTO>> GetNotes()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Note, NoteDTO>();
                }).CreateMapper();
                var notesDto = mapper.Map<IEnumerable<Note>, List<NoteDTO>>(notes.OrderBy(item => item.Id));
                if (notesDto == null || notesDto.Count==0)
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
