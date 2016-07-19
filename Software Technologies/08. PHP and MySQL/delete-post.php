<html>
<head>
    <title>Delete Post</title>
    <link rel="stylesheet" href="styles/main.css">
    <meta charset="utf-8">
    <style>
        p {
            margin-bottom: 10px;
        }

        a {
            text-decoration: none;
            color: #666;
        }

        a:hover {
            color: #f66;
        }
    </style>
</head>
<body>
<header>
    <nav>
        <ul>
            <li><a href="index.php">Posts</a></li>
            <li><a href="create-post.php">Create new post</a></li>
            <li><a href="delete-post.php">Delete post</a></li>
        </ul>
    </nav>
</header>

<?php

$mysqli = new mysqli('localhost', 'root', '', 'blog');
$mysqli->set_charset("utf8");
if (isset($_GET['id'])) {
    $stmt = $mysqli->prepare("DELETE FROM posts WHERE id = ?");
    $stmt->bind_param("i", $_GET['id']);
    $stmt->execute();
    if ($stmt->affected_rows == 1) {
        echo "Post deleted.";
    }
}

$result = $mysqli->query('SELECT title, id FROM posts');

while ($row = $result->fetch_assoc()) {
    $title = htmlspecialchars($row['title']);
    $id = $row['id'];
    $delLink = 'delete-post.php?id=' . $row['id'];
    echo "<p><a href=$delLink'>Delete '$title'.</a></p>";
}

?>

</body>
</html>