using System.ComponentModel.DataAnnotations;

namespace CVProfile.Data.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Technology name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Years of experience is required")]
        [Range(0, 50, ErrorMessage = "Years must be between 0 and 50")]
        public int YearsOfExperience { get; set; }

        [Required(ErrorMessage = "Skill level is required")]
        [Range(1, 100, ErrorMessage = "Skill level must be between 1 and 100")]
        public int SkillLevel { get; set; }

        [Required(ErrorMessage = "Icon class is required")]
        public string IconClass { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
} 