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

$query = 'SELECT * FROM users';
$result = $mysqli->query($query);

if (!$result) {
    die ('Error: Failed to proccess query.');
}

if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $id = $row['id'];
        $username = htmlspecialchars($row['username']);
        $fullname = htmlspecialchars($row['full_name']);

        echo "Id: $id <br>Username: $username<br>Fullname: $fullname<br><br>";
    }
} else {
    echo "0 results.";
}

?>