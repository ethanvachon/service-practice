USE firstdatabase123;



-- CREATE TABLE posts (
--   id int AUTO_INCREMENT NOT NULL,
--   title VARCHAR(255) NOT NULL,
--   body VARCHAR(255) NOT NULL,
--   creatorId VARCHAR(255),

--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- );


-- CREATE TABLE comments (
--   id int AUTO_INCREMENT NOT NULL,
--   body VARCHAR(255) NOT NULL,
--   postId int NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id),

--   FOREIGN KEY (postId)
--     REFERENCES posts (id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- );