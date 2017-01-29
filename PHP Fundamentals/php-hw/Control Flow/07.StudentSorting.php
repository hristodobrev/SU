<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Student Sorting</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>

    <style>
        th, td {
            padding: 0.3em;
        }

        input {
            padding: 0.2em;
        }

        table#input-table {
            border: 1px solid #333;
            border-collapse: collapse;
            margin: 1em;
        }

        table#input-table th {
            border-bottom: 1px solid #333;
            text-align: left;
        }

        table#input-table > tbody > tr:last-child > td {
            padding-bottom: 0.8em;
        }

        table#input-table > tbody > tr:first-child > td {
            padding-top: 0.8em;
        }

        table#input-table > tfoot td {
            border-top: 1px solid #333;
        }

        .remove, input[type=button], input[type=submit] {
            padding: 0.2em 0.6em;
            margin-left: 0.4em;
            background: #4d4fff;
            color: white;
        }

        select {
            padding: 0.2em;
        }

        table#result-table {
            border-collapse: collapse;
            margin: 1em;
        }

        table#result-table th, table#result-table td {
            border: 1px solid #333;
        }

        table#result-table thead th {
            background: #4d4fff;
            color: white;
        }

        table#result-table tr:nth-child(2n - 1) {
            background: #eee;
        }

        table#result-table tr > td:last-child,
        table#result-table tfoot tr > th:last-child {
            text-align: right;
        }

        table#result-table tfoot tr > th:first-child {
            text-align: left;
        }
    </style>
</head>
<body>
<form method="get">
    <table id="input-table">
        <thead>
        <tr>
            <th>First Name:</th>
            <th>Second Name:</th>
            <th>Email:</th>
            <th>Exam Score:</th>
        </tr>
        </thead>
        <tbody>

        </tbody>
        <tfoot>
        <tr>
            <td colspan="4">
                <input type="button" value="+" id="add">
                <label>
                    Sort By:
                    <select name="sort">
                        <option value="firstName">First Name</option>
                        <option value="secondName">Second Name</option>
                        <option value="email">Email</option>
                        <option value="examScore">Exam Score</option>
                    </select>
                </label>
                <label>
                    Order:
                    <select name="order">
                        <option value="asc">Ascending</option>
                        <option value="desc">Descending</option>
                    </select>
                </label>
                <input type="submit">
            </td>
        </tr>
        </tfoot>
    </table>
</form>

<script>
    $(function () {
        $('#add').click(function () {
            let tr = $('<tr>');
            tr.append('<td><input type="text" name="first-name[]" required></td>');
            tr.append('<td><input type="text" name="second-name[]" required></td>');
            tr.append('<td><input type="email" name="email[]" required></td>');
            let lastTd = $('<td>');
            lastTd.append('<input type="number" name="exam-score[]" required>');
            let removeBtn = $('<button class="remove">-</button>').click(function () {
                tr.remove();
            });
            lastTd.append(removeBtn);
            tr.append(lastTd);
            tr.hide();
            $('#input-table>tbody').append(tr);
            tr.fadeIn();
        });

        $('#add').click();
    });
</script>

<?php
if (isset($_GET['first-name']) && isset($_GET['second-name']) && isset($_GET['email']) && isset($_GET['exam-score'])) {
    $firstNames = $_GET['first-name'];
    $secondNames = $_GET['second-name'];
    $emails = $_GET['email'];
    $examScores = $_GET['exam-score'];

    $students = [];
    $scores = 0;
    for ($i = 0; $i < count($firstNames); $i++) {
        $students[] = [
            'firstName' => $firstNames[$i],
            'secondName' => $secondNames[$i],
            'email' => $emails[$i],
            'examScore' => $examScores[$i],
        ];

        $scores += intval($examScores[$i]);
    }

    $averageScore = round($scores / count($students));

    usort($students, 'sortStudents');

    if ($_GET['order'] == 'desc') {
        $students = array_reverse($students);
    }
    ?>
    <table id="result-table">
        <thead>
        <tr>
            <th>First Name</th>
            <th>Second Name</th>
            <th>Email</th>
            <th>Exam Score</th>
        </tr>
        </thead>
        <tbody>
        <?php foreach ($students as $student) : ?>
            <tr>
                <td><?= $student['firstName'] ?></td>
                <td><?= $student['secondName'] ?></td>
                <td><?= $student['email'] ?></td>
                <td><?= $student['examScore'] ?></td>
            </tr>
        <?php endforeach; ?>
        </tbody>
        <tfoot>
        <tr>
            <th colspan="3">Average Score:</th>
            <th colspan="3"><?= $averageScore ?></th>
        </tr>
        </tfoot>
    </table>
    <?php
}
?>

<?php
function sortStudents($a, $b)
{
    $sortKey = $_GET['sort'];
    return strcasecmp($a[$sortKey], $b[$sortKey]);
}

?>

</body>
</html>