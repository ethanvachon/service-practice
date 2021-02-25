using service_practice.Models;
using System.Collections.Generic;
using System;
using service_practice.Repositories;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace service_practice.Services
{
  public class PostsService
  {
    private readonly PostRepository _repo;

    public PostsService(PostRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Post> Get()
    {
      return _repo.GetAll();
    }

    public Post Get(int id)
    {
      Post post = _repo.GetById(id);
      return post;
    }
    public Post Create(Post newPost)
    {
      _repo.Create(newPost);
      return newPost;
    }

    public Post Edit(Post editPost)
    {
      Post post = Get(editPost.Id);
      _repo.Edit(editPost);
      return editPost;
    }

    public string Delete(int id)
    {
      Post postToRemove = Get(id);
      if (postToRemove == null)
      {
        throw new Exception("invalid id");
      }
      _repo.Delete(id);
      return "deleted";
    }
  }
}