<html>
<head>
    <title>Create Post</title>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="styles/main.css">
    <link rel="stylesheet" href="styles/form.css">
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
<form>
    <p>Title: </p>
    <input type="text" name="title"><br>
    <p>Content: </p>
    <textarea type="text" name="content"></textarea><br>
    <input type="submit" value="Post">

<?php

if (isset($_GET['title'])) {
    $mysqli = new mysqli('localhost', 'root', '', 'blog');
    $mysqli->set_charset("utf8");
    $stmt = $mysqli->prepare(
        "INSERT INTO posts(title, content, author_id) VALUES (?, ?, 4)");
    $stmt->bind_param("ss",
        $_GET['title'], $_GET['content']);
    $stmt->execute();
    if ($stmt->affected_rows == 1)
        echo "<p>Post created.</p>";
    else die("Insert post failed.");
}

?>

</form>
</body>
</html>