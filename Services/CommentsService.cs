using System;
using System.Collections.Generic;
using service_practice.Models;
using service_practice.Repositories;

namespace service_practice.Services
{
  public class CommentsService
  {
    private readonly CommentsRepository _repo;

    public CommentsService(CommentsRepository repo)
    {
      _repo = repo;
    }

    internal Comment Create(Comment newComment)
    {
      return _repo.Create(newComment);
    }

    internal Comment Edit(Comment editComment)
    {
      return _repo.Edit(editComment);
    }

    internal void Delete(int id)
    {
      _repo.Delete(id);
    }

    internal IEnumerable<Comment> GetCommentsByPost(int id)
    {
      IEnumerable<Comment> comments = _repo.GetCommentsByPost(id);
      if (comments == null)
      {
        throw new Exception("invalid id");
      }
      return comments;
    }
  }
}