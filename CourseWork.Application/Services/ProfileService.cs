using CourseWork.Domain.Contracts.UserContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;

namespace CourseWork.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly CharityDBContext _charityDbContext;

        public ProfileService(CharityDBContext charityDbContext)
        {
            _charityDbContext = charityDbContext;
        }
        public async Task ChangeUserLanguageAsync(int userId, string languageCode)
        {
            var user = await _charityDbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var userLanguage = user.UserLanguages.FirstOrDefault(x => x.Language == languageCode)!;
            if (userLanguage == null)
            {
                // Если язык для пользователя еще не настроен, создаем запись
                userLanguage = new UserLanguage
                {
                    IdUser = userId,
                    Language = languageCode
                };

                userLanguage.Language = languageCode;
                await _charityDbContext.SaveChangesAsync();
            }
            else
            {
                // Если уже существует, обновляем язык
                userLanguage.Language = languageCode;
                await _charityDbContext.SaveChangesAsync();
            }
        }

    }
}
