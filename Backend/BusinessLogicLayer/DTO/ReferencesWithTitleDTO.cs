using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ReferencesWithTitleDTO
    {
        public int FromNote{ get; set;}
        public int ToNote { get; set;}
        public string Title { get; set;}
    }
}
