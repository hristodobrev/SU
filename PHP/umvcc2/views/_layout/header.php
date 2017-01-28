<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <script src="<?= APP_ROOT ?>/content/scripts/jquery-3.0.0.min.js"></script>
    <script src="<?= APP_ROOT ?>/content/scripts/main.js"></script>
    <link href="<?= APP_ROOT ?>/content/css/main.css" type="text/css" rel="stylesheet"/>
    <title><?php if (isset($this->title)) echo htmlspecialchars($this->title) ?></title>
</head>
<body>

<header>
    <nav>
        <ul>
            <li><a href="<?= APP_ROOT ?>">Home</a></li>
            <?php if ($this->isLogged) : ?>
                <li><a href="<?= APP_ROOT ?>/posts/create">Create Post</a></li>
            <?php endif; ?>
        </ul>
        <ul class="user-info-bar">
            <?php if ($this->isLogged) : ?>
                <li>Hello, <?= htmlspecialchars($_SESSION['username']) ?></li>
                <li><a href="<?= APP_ROOT ?>/users/logout">Logout</a></li>
            <?php else : ?>
                <li><a href="<?= APP_ROOT ?>/users/login">Login</a></li>
                <li><a href="<?= APP_ROOT ?>/users/register">Register</a></li>
            <?php endif; ?>
        </ul>
    </nav>
</header>

<?php include "views/_layout/show-messages.php" ?>