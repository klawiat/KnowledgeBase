using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Reference
    {
        /// <summary>
        /// Родительская заметка
        /// </summary>
        public int FromId { get; set; }
        public int ToId { get; set; }
        public Note NoteFrom { get; set; }
        public Note NoteTo { get; set; }
    }
}
