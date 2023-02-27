using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IResponse<T>
    {
        string Description { get; set; }
        HttpStatusCode StatusCode { get; set; }
        T Data { get; set; }
    }
}
