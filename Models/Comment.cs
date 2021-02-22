using System.ComponentModel.DataAnnotations;

namespace service_practice.Models
{
  public class Comment
  {
    public Comment()
    {

    }
    public Comment(int id, string body, int postId, Post post)
    {
      Id = id;
      Body = body;
      PostId = postId;
      Post = post;
    }

    [Required]
    public int Id { get; set; }

    [Required]
    public string Body { get; set; }
    [Required]
    public int PostId { get; set; }
    public Post Post { get; set; }
  }
}