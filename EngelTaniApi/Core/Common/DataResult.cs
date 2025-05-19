using EngelTaniApi.Core.Common.MessagesConstants;

namespace EngelTaniApi.Core.Common
{
    public class DataResult<T>
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public List<ValidationItem>? Validations { get; set; }
        public static DataResult<T> Success(T data, string? message = null)
        {
            return new DataResult<T>
            {
                Succeeded = true,
                Data = data,
                Message = message ?? SuccessMessages.Saved 
            };
        }

        public static DataResult<T> Fail(string message = ErrorMessages.OperationFailed, List<ValidationItem>? validations = null)
        {
            return new DataResult<T>
            {
                Succeeded = false,
                Message = message,
                Validations = validations
            };
        }
    }
}
