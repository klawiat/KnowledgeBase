using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IReferenceService
    {
        IResponse<IEnumerable<Reference>> GetAll();
        IResponse<IEnumerable<Reference>> GetByNoteId(int id);
        IResponse<bool> DeleteByNoteId(int id);
    }
}
