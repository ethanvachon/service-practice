using System;
using service_practice.Models;
using service_practice.Repositories;

namespace service_practice.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal Profile GetProfileById(string id)
    {
      Profile profile = _repo.GetById(id);
      if (profile == null)
      {
        throw new Exception("invalid id");
      }
      return profile;
    }

    internal object GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }
  }
}