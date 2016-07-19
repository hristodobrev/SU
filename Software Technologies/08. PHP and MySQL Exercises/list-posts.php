<?php

$hostname = 'localhost';
$username = 'root';
$password = '';
$dbname = 'blog';

$mysqli = new mysqli($hostname, $username, $password, $dbname);

if ($mysqli->connect_errno) {
    die ('Error: Failed to connect to MySQL.');
}

$mysqli->set_charset('utf8');

$query = 'SELECT * FROM posts';
$result = $mysqli->query($query);

if (!$result) {
    die ('Error: Failed to proccess query.');
}

if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $id = $row['id'];
        $title = htmlspecialchars($row['title']);
        $content = $row['content'];
        $date = $row['date'];

        echo "Id: $id <br>Title: $title<br>Content: $content<br>Date: $date<hr>";
    }
} else {
    echo "0 results.";
}

?>