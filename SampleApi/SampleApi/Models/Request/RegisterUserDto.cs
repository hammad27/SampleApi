using System.ComponentModel.DataAnnotations;

namespace SampleApi.Models.Request
{
    public record RegisterUserRequest
    {
        [Required]
        public string FirstName { get; init; }

        [Required]
        public string LastName { get; init; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
