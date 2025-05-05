using SampleApi.Data.Entities;

namespace SampleApi.Models.Response
{
    public record UserResponse(Guid Id, string FirstName, string LastName, string Email);

    public static class EmployeeExtensions
    {
        public static UserResponse MapResponse(this User user) =>
            new(user.Id, user.FirstName, user.LastName, user.Email);
    }
}
