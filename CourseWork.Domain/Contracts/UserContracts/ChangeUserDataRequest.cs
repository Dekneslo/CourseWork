﻿namespace CourseWork.Domain.Contracts.UserContracts
{
    public class ChangeUserDataRequest
    {
        public required string FirstName { get; set; }
        
        public required string LastName { get; set; }
        
        public required string Email { get; set; }
        
        public required string City { get; set; }
        
        public required string Country { get; set; }
        
        public required string PhoneNumber { get; set; }
        
        public required string Biography { get; set; }
    }
}
