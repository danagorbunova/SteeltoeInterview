using System.ComponentModel.DataAnnotations;

namespace AdminApi.DataContracts
{
    public class AddEditUserRequest
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}