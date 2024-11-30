using CourseWork.Domain.Contracts.UserContracts;

namespace CourseWork.Domain.Interfaces
{
    public interface IProfileService
    {
        Task ChangeUserLanguageAsync(int userId, string languageCode);
    }
}
