using System;
using System.ComponentModel.DataAnnotations;

namespace service_practice.Models
{
  public class Post
  {
    [Required]
    public string Title { get; set; }
    [Required]
    public string Body { get; set; }
    public int Id { get; set; }
  }
}