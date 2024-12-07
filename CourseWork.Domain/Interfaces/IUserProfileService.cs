using CourseWork.Domain.Contracts.UserContracts;

namespace CourseWork.Domain.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserResponse> ChangeUserData(ChangeUserDataRequest changeUserDataRequest);

        Task<UserResponse> GetMe();
    }
}
