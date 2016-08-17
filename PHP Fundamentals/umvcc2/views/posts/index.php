<?php $this->title = "Index"; ?>

<main>
    <h1><?= htmlspecialchars($this->title) ?></h1>
    <?php foreach ($this->posts as $post) : ?>
        <article>
            <img src="<?= APP_ROOT ?>/content/images/subi2.jpg"/>
            <h3><?= htmlspecialchars($post['title']) ?></h3>
            <p id="body"><?= $post['content'] ?></p>
            <p id="info">Created at <span><?= (new DateTime($post['date']))->format('d-m-Y') ?></span>
                    <span> by <?= $post['author'] ?></span>
            </p>
        </article>
    <?php endforeach; ?>
</main>

