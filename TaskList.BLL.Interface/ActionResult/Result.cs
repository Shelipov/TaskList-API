using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.BLL.Interface.ActionResult
{
    
    public class Result
    {
        public bool IsSucceed { get; }

        public string ErrorMessage { get; }

        protected Result(bool isSucceed, string errorMessage)
        {
            IsSucceed = isSucceed;
            ErrorMessage = errorMessage;
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null);
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default, false, message);
        }

        public Result<K> ToFailedResult<K>()
        {
            return Fail<K>(ErrorMessage);
        }

        public void EnsureSuccess()
        {
            if (!IsSucceed)
            {
                throw new ResultException(ErrorMessage);
            }
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        protected internal Result(T value, bool success, string error)
            : base(success, error)
        {
            Value = value;
        }

        public Result<K> ToResult<K>(Func<T, K> converter)
        {
            return new Result<K>(IsSucceed ? converter(Value) : default, IsSucceed, ErrorMessage);
        }
    }
}
