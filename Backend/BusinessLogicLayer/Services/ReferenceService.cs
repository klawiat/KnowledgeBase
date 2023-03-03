using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Response;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using DataLayer.EF;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Reference> references;
        public ReferenceService(AppDbContext context)
        {
            this._appDbContext= context;
            this.references = context.Refs;
        }

        public IResponse<bool> DeleteByNoteId(int id)
        {
            try
            {
                var refs = references.Where(x => x.FromId == id);
                references.RemoveRange(refs);
                _appDbContext.SaveChanges();
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.OK, Data = true, Description = "Успех!" };
            }
            catch
            {
                return new BaseResponse<bool> { StatusCode = HttpStatusCode.NotFound, Data = false, Description = "Ошибка!" };
            }
        }

        public IResponse<IEnumerable<Reference>> GetByNoteId(int id)
        {
            try
            {
                var refs = references.Where(x=>x.FromId == id);
                if (refs.Any())
                    throw new ArgumentNullException();
                return new BaseResponse<IEnumerable<Reference>> {  StatusCode = HttpStatusCode.OK,Data = refs,Description="Успех" };
            }
            catch
            {
                return new BaseResponse<IEnumerable<Reference>> { StatusCode = HttpStatusCode.NotFound, Description = "Ошибка!" };
            }
        }
    }
}
