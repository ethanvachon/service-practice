using System.ComponentModel.DataAnnotations;

namespace service_practice.Models
{
  public class Comment
  {
    public string creatorId { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    public string Body { get; set; }
    [Required]
    public int PostId { get; set; }
    public Post Post { get; set; }
    public Profile Creator { get; set; }
  }
}