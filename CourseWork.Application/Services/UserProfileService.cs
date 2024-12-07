using CourseWork.Domain.Contracts.UserContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;
using System;

namespace CourseWork.Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly CharityDBContext _charityDbContext;
        private readonly IUserService _userService;

        public UserProfileService(CharityDBContext charityDbContext, IUserService userService)
        {
            _charityDbContext = charityDbContext;
            _userService = userService;
        }
        
        public async Task<UserResponse> ChangeUserData(ChangeUserDataRequest changeUserDataRequest)
        {
            var user = await _userService.GetCurrentUser();

            if (!int.TryParse(changeUserDataRequest.PhoneNumber, out int test))
            {
                throw new InvalidDataFormatException();
            }
            user.PhoneNumber = changeUserDataRequest.PhoneNumber;
            user.Biography = changeUserDataRequest.Biography;
            user.City = changeUserDataRequest.City;
            user.Email = changeUserDataRequest.Email;
            user.FirstName = changeUserDataRequest.FirstName;
            user.LastName = changeUserDataRequest.LastName;
            user.Country = changeUserDataRequest.Country;

            return new UserResponse
            {
                Biography = user.Biography,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
        
        public async Task<UserResponse> GetMe()
        {
            var user = await _userService.GetCurrentUser();
            return new UserResponse
            {
                Biography = user.Biography,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

    }
}
