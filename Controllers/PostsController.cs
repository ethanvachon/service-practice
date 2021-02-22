using Microsoft.AspNetCore.Mvc;
using service_practice.Models;
using service_practice.Services;
using System;
using System.Collections.Generic;

namespace service_practice
{
  [ApiController]
  [Route("api/[controller]")]
  public class PostsController : ControllerBase
  {
    private readonly PostsService _ps;
    private readonly CommentsService _commentsService;

    public PostsController(PostsService ps, CommentsService commentsService)
    {
      _ps = ps;
      _commentsService = commentsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Post>> Get()
    {
      try
      {
        return Ok(_ps.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Post> Get(int id)
    {
      try
      {
        Post post = _ps.Get(id);
        return Ok(post);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/comments")]
    public ActionResult<IEnumerable<Comment>> GetCommentsByPost(int id)
    {
      try
      {
        return Ok(_commentsService.GetCommentsByPost(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Post> Create([FromBody] Post newPost)
    {
      try
      {
        Post post = _ps.Create(newPost);
        return Ok(post);
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
        _ps.Delete(id);
        return Ok("deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}