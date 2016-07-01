<style>
    div {
        width: 25px;
        height: 25px;
        margin: 5px;
        display: inline-block;
    }
</style>
<?php

    for ($i = 0; $i < 255; $i += 51) {
        for ($j = 0; $j < 10; $j++) {
            $saturation = $i + $j * 5;
            $color = "rgb($saturation, $saturation, $saturation);";
            echo "<div style=\"background-color: $color\"></div>";
        }
        echo "<br>";
    }
?>