<?php

class PostsModel extends BaseModel
{
    public function getAll() : array
    {
        $statement = self::$db->query(
            "SELECT p.img_name, p.title, p.content, p.date, " .
            "IFNULL(u.full_name, u.username) AS author " .
            "FROM posts p LEFT JOIN users u ON p.author_id = u.id"
        );

        return $statement->fetch_all(MYSQLI_ASSOC);
    }

    public function create(string $imgPath, string $title, string $content, int $authorId) : bool
    {
        $statement = self::$db->prepare(
            "INSERT INTO posts(img_name, title, content, author_id) " .
            "VALUES(?, ?, ?, ?)"
        );
        $statement->bind_param("sssi", $imgPath, $title, $content, $authorId);
        $statement->execute();

        return $statement->affected_rows == 1;
    }
}

?>