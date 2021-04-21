using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using service_practice.Models;

namespace service_practice.Repositories
{
  public class CommentsRepository
  {

    private readonly IDbConnection _db;

    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Comment> GetCommentsByPost(int id)
    {
      string sql = @"
      SELECT
      c.*,
      p.*,
      pr.*
      FROM comments c
      JOIN posts p ON c.postId = p.id
      JOIN profiles pr ON c.creatorId = pr.id
      WHERE postId = @id;
      ";
      return _db.Query<Comment, Post, Profile, Comment>(sql, (comment, post, profile) =>
      {
        comment.Post = post;
        comment.Creator = profile;
        return comment;
      }, new { id }, splitOn: "id");
    }

    internal Comment Create(Comment newComment)
    {
      string sql = @"
      INSERT INTO comments
      (body, postId, creatorId)
      VALUES
      (@body, @postId, @creatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newComment);
      newComment.Id = id;
      return newComment;
    }

    internal Comment Edit(Comment editComment)
    {
      string sql = @"
      UPDATE comments
      SET
        body = @body
      WHERE id = @id;
      SELECT * FROM comments WHERE id = @id;";
      return _db.QueryFirstOrDefault<Comment>(sql, editComment);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM comments WHERE id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}