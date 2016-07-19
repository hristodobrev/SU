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

$query = $mysqli->prepare("INSERT INTO users(username, password_hash, full_name) VALUES (?, ?, ?)");

$username = 'Bai Ivan';
$password_hash = md5('parolaa');
$fullname = 'Ivan Nedev';

$query->bind_param('sss', $username, $password_hash, $fullname);

$query->execute();

if ($query->affected_rows == 1) {
    echo 'User successfully created.';
} else {
    die ('Error: Creating user failed.');
}

?>