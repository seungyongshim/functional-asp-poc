using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace functional_asp_poc
{
    public class Error
    {
        public virtual string Message { get; set; }
    }

    public class ResultDto<T>
    {
        public bool Succeeded { get; }
        public bool Failed => !Succeeded;
        public T Data { get; }
        public Error Error { get; }
        public ResultDto(T data) { Succeeded = true; Data = data; }
        public ResultDto(Error error) { Error = error; }
    }
}
