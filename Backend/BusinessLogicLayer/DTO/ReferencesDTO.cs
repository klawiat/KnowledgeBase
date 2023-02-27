using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ReferencesDTO
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public List<uint> NoteRefs { get; set; }
    }
}
