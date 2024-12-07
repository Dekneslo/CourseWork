﻿namespace CourseWork.Domain.Contracts.CourseContracts;

public class UpdateCourseRequest
{
    public required string CourseName { get; set; }
        
    public required string Description { get; set; }
        
    public required int CategoryId { get; set; }
}