using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhanhVn.Services.DTOs.Response
{
    public class Response<T> : Dictionary<string,T>, IResponse where T : class 
    {
    }
}
