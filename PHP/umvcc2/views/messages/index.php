<?php $this->title = "Select Friend ID"; ?>

<main>
    <h1><?= htmlspecialchars($this->title) ?></h1>
    <form method="POST">
        <div class="form-row">
            <label for="friend-id">Friend ID:</label>
            <input type="number" id="friend-id" name="friend-id" autofocus />
        </div>
        <div class="form-row">
            <input type="submit" value="Select Friend" />
        </div>
    </form>
</main>
