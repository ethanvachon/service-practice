using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
      string sql = @"
      SELECT
      p.*,
      pr.*
      FROM posts p
      JOIN profiles pr On p.creatorId = pr.id
      WHERE id = @id";
      return _db.Query<Post, Profile, Post>(sql, (post, profile) =>
      {
        post.Creator = profile;
        return post;
      }, new { id }, splitOn: "id").FirstOrDefault();
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