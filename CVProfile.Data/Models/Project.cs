using System.ComponentModel.DataAnnotations;

namespace CVProfile.Data.Models;

public class Project
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Project name is required")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Technologies used is required")]
    [StringLength(200, ErrorMessage = "Technologies cannot be longer than 200 characters")]
    public string Technologies { get; set; } = string.Empty;

    public string? GitHubUrl { get; set; }

    public string? LiveUrl { get; set; }

    [Required(ErrorMessage = "Completion date is required")]
    public DateTime CompletionDate { get; set; }

    [Url(ErrorMessage = "Please enter a valid URL")]
    [StringLength(500, ErrorMessage = "URL cannot be longer than 500 characters")]
    public string? ProjectUrl { get; set; }

    [StringLength(200, ErrorMessage = "Image URL cannot be longer than 200 characters")]
    public string? ImageUrl { get; set; }
} 