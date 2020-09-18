using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace functional_asp_poc
{
    public static class EitherExt
    {
        public static ResultDto<T> ToResult<T>(this Either<Error, T> @this)
           => @this.Match(
              Right: data => new ResultDto<T>(data),
              Left: error => new ResultDto<T>(error));
    }
}
