<?php $this->title = "Create Post"; ?>

<main>
    <h1><?= htmlspecialchars($this->title) ?></h1>
    <form method="POST">
        <div class="form-row">
            <label for="image">Image:</label>
            <input type="file" id="image" name="image" />
        </div>
        <div class="form-row">
            <label for="title">Title:</label>
            <input type="text" id="title" name="title" autofocus />
        </div>
        <div class="form-row">
            <label for="content">Content:</label>
            <input type="text" id="content" name="content" />
        </div>
        <div class="form-row">
            <input type="submit" value="Create" />
        </div>
    </form>
</main>