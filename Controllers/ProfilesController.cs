using Microsoft.AspNetCore.Mvc;
using service_practice.Models;
using service_practice.Services;

namespace service_practice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;

    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet("{id}")]
    public ActionResult<ProfilesController> Get(string id)
    {
      try
      {
        Profile profile = _ps.GetProfileById(id);
        return Ok(profile);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}