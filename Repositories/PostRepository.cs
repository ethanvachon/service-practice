using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using service_practice.Models;

namespace service_practice.Repositories
{
  public class PostRepository
  {
    public readonly IDbConnection _db;

    public PostRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Post> GetAll()
    {
      string sql = "SELECT * FROM posts;";
      return _db.Query<Post>(sql);
    }

    public Post GetById(int id)
    {
      string sql = "SELECT * FROM posts WHERE id = @id;";
      return _db.QueryFirstOrDefault<Post>(sql, new { id });
    }
    public Post Create(Post newPost)
    {
      string sql = @"
      INSERT INTO posts
      (title, body)
      VALUES
      (@Title, @Body);
      SELECT LAST_INSERT_ID()";
      int id = _db.ExecuteScalar<int>(sql, newPost);
      newPost.Id = id;
      return newPost;
    }

    public Post Edit(Post editPost)
    {
      throw new NotImplementedException();
    }

    public Post Delete(Post postToRemove)
    {
      throw new NotImplementedException();
    }

  }
}