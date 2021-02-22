using Microsoft.AspNetCore.Mvc;
using service_practice.Models;
using service_practice.Services;

namespace service_practice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CommentsController : ControllerBase
  {
    private readonly CommentsService _service;

    public CommentsController(CommentsService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<Comment> Create([FromBody] Comment newComment)
    {
      try
      {
        return Ok(_service.Create(newComment));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Comment> Edit([FromBody] Comment editComment, int id)
    {
      try
      {
        editComment.Id = id;
        return Ok(_service.Edit(editComment));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
