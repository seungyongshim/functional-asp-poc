using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;
using Microsoft.AspNetCore.Mvc;

namespace functional_asp_poc.Controllers
{
    public class BookTransfer 
    {
        public string Method { get; set; }
    }

    [ApiController]
    public class BookTransferController : Controller
    {
        
        [HttpPost, Route("api/transfers/book")]
        public ResultDto<Unit> BookTransfer([FromBody] BookTransfer cmd)
            => Handle(cmd)
               .ToResult();

        private Either<Error, Unit> Handle(BookTransfer cmd)
            => Right(cmd)
               .Bind(CheckError)
               .Bind(Save);

        private Either<Error, BookTransfer> CheckError(BookTransfer cmd) => cmd switch
        {
            var c when string.Equals(c.Method, "Error")           => new Error { Message = "에러" },
            var c when string.Equals(c.Method, "Unhandled Error") => throw new Exception("캐치 안된 에러"),
            _                                                     => cmd,
        };

        private Either<Error, Unit> Save(BookTransfer cmd) => new Unit();
    }
}
