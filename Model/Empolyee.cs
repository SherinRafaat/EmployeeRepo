using System.ComponentModel.DataAnnotations;

namespace taskinterview.Model
{
    
        public class Empolyee
        {
        [Required]
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")] 
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")] 
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 200 characters.")]
        public string Address { get; set; }


    }
    }


