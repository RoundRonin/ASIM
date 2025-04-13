using System;
using System.ComponentModel.DataAnnotations;
namespace Application.DTOs;


public class CreateTestDTO
{
    [Required(ErrorMessage = "Text is required.")]
    [StringLength(100, ErrorMessage = "Text must not exceed 100 characters.")]
    public string Text { get; set; } = string.Empty;

    
}