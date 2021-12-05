using System.ComponentModel.DataAnnotations;
using AdminApi.DataContracts;

namespace AdminApi.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public User()
        {
        }

        public User(AddEditUserRequest request)
        {
            Update(request);
        }

        public void Update(AddEditUserRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
        }
    }
}