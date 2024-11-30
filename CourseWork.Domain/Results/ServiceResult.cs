namespace CourseWork.Domain.Results
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public object Data { get; set; } // Универсальный контейнер для данных (файлы, пользователи, посты и т.д.)
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        // Общие методы для успешных и неуспешных операций
        public static ServiceResult SuccessResult(string message, object data = null)
        {
            return new ServiceResult { Success = true, Message = message, Data = data };
        }

        public static ServiceResult ErrorResult(string message, List<string>? errors = null)
        {
            return new ServiceResult { Success = false, Message = message, Errors = errors ?? new List<string> { message } };
        }
    }

}
