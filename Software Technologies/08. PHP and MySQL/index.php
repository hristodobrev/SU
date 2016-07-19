<html>
<head>
    <title>PHP and MYSQL</title>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="styles/main.css">
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
    Order by:
    <select name="order-by">
        <option value="title">Title</option>
        <option value="date">Date</option>
    </select>
    Reverse:
    <input type="checkbox" name="reversed">
    <input type="submit" value="Apply">
</form>
<table>
    <tr>
        <th>Title</th>
        <th>Content</th>
        <th>Date</th>
    </tr>
    <?php

    $mysqli = new mysqli('localhost', 'root', '', 'blog');
    $mysqli->set_charset("utf8");
    if ($mysqli->connect_errno) {
        die('Cannot connect to the database.');
    }

    $orderBy = 'title';

    if (isset($_GET['order-by'])) {
        $orderBy = $_GET['order-by'];
    }

    $orderType = ' ASC';
    if (isset($_GET['reversed']) && $_GET['reversed']) {
        $orderType = ' DESC';
    }

    $result = $mysqli->query('SELECT * FROM posts ORDER BY ' . $orderBy . $orderType);
    while ($row = $result->fetch_assoc()) {
        $title = htmlspecialchars($row['title']);
        $content = htmlspecialchars($row['content']);
        $date = (new DateTime($row['date']))->format('d.m.Y'); ?>

        <tr>
            <td><?= $title ?></td>
            <td><?= $content ?></td>
            <td><?= $date ?></td>
        </tr>

        <?php
    }

    ?>
</table>
</body>
</html>