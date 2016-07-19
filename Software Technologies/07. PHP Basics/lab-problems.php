<!doctype html>
<html>
<head>
    <title>Lab Problems</title>
</head>
<body>

<?php

if (isset($_GET['text'])) {
    $text = $_GET['text'];
    $words = array_filter(preg_split('/\W+/', $text));

    $uppercaseWords = array_filter($words, 'isUppercaseWord');
    echo implode(', ', $uppercaseWords);
}

function isUppercaseWord($word)
{
    return strtoupper($word) == $word;
}

?>

<form>
    <textarea name="text" rows="10"></textarea><br>
    <input type="submit" value="Calculate Incomes">
    </div>
</form>

</body>
</html>