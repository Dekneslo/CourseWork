namespace CourseWork.Domain.Contracts.CourseContracts
{
    public class AddMediaToCourseRequest
    {
        public int FileId { get; set; }  // ID файла, который будет привязан к курсу
        public int CourseId { get; set; }
    }
}
