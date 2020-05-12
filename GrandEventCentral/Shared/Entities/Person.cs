using System;
using System.ComponentModel.DataAnnotations;

namespace GrandEventCentral.Shared.Entities
{
    public class Person : Base
    {
        [Required(ErrorMessage = "Enter your first name")]
        [StringLength(10, ErrorMessage = "That name is too long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [StringLength(15, ErrorMessage = "That name is too long")]
        public string LastName { get; set; }

        /// <summary>
        /// TODO: Add auto generation of name = fname+lname
        /// </summary>
        public string Name { get; set; }

        [Required(ErrorMessage = "An email is required")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        public string Email { get; set; }

        public int? Gender { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/2020", "1/12/2030",
            ErrorMessage = "Value for {0} must be between {1:dd MMM yyyy} and {2:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Choose the team and technology you want to work on")]
        public string PreferredTeam { get; set; }

        public string Biography { get; set; }

        public string Picture { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Person p2)
            {
                return Id == p2.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
