using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface INoteService
    {
        IResponse<IEnumerable<NoteDTO>> GetNotes();
        IResponse<NoteDTO> GetNote(int id);
        IResponse<bool> CreateNote(NoteDTO note);
        IResponse<bool> EditNote(NoteDTO note);
        IResponse<bool> DeleteNote(int id);
    }
}
