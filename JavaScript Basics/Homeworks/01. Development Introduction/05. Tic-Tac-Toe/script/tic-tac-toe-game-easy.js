var turn = 0;
var hasWon = false;
var winTeam;
var color = "#7fff00";

function cellClick(id) {
    if (checkCell(id)) {
        writeOnLog("Cell is already filled.");
        return;
    }

    cellFill(id);

    if (turn < 8) {
        calculateTurn();
    }
}

function calculateTurn() {
    var cellId = getIndex();

    if(turn <= 1 || cellId == -1) {
        cellId = randomNumberInInterval(0, 8);
        while (checkCell(cellId)) {
            cellId = randomNumberInInterval(0, 8);
        }
    }

    cellFill(cellId);
}

function getIndex() {
    var index = -1;

    var firstRow = getFilledCellsByRow(0);
    var secondRow = getFilledCellsByRow(1);
    var thirdRow = getFilledCellsByRow(2);
    var firstCol = getFilledCellsByCol(0);
    var secondCol = getFilledCellsByCol(1);
    var thirdCol = getFilledCellsByCol(2);

    if (firstRow > 1 && index == -1) {
        index = getEmptyCellsByRowId(0);
    }
    if (secondRow > 1 && index == -1) {
        index = getEmptyCellsByRowId(1);
    }
    if (thirdRow > 1 && index == -1) {
        index = getEmptyCellsByRowId(2);
    }
    if (firstCol > 1 && index == -1) {
        index = getEmptyCellsByColId(0);
    }
    if (secondCol > 1 && index == -1) {
        index = getEmptyCellsByColId(1);
    }
    if (thirdCol > 1 && index == -1) {
        index = getEmptyCellsByColId(2);
    }

    return index;
}

function getFilledCellsByRow(rowId) {
    var count = 0;

    for (var row = 0; row < 3; row++) {
        var cell = document.getElementById((rowId * 3) + row);
        if (cell.innerHTML == "X") {
            count++;
        }
    }

    return count;
}

function getEmptyCellsByRowId(rowId){
    var index = -1;

    for (var row = 0; row < 3; row++) {
        var cellId = (rowId * 3) + row;
        if(!checkCell(cellId)) {
            index = cellId;
        }
    }

    return index;
}

function getFilledCellsByCol(colId) {
    var count = 0;

    for (var col = 0;col < 3; col++) {
        var cell = document.getElementById((col * 3) + colId);
        if (cell.innerHTML == "X") {
            count++;
        }
    }

    return count;
}

function getEmptyCellsByColId(colId) {
    var index = -1;

    for (var col = 0; col < 3; col++) {
        var cellId = (col * 3) + colId;
        if(!checkCell(cellId)) {
            index = cellId;
        }
    }

    return index;
}

function checkCell(id) {
    var cell = document.getElementById(id);
    var isFilled = cell.innerHTML == "X" || cell.innerHTML == "O";
    return isFilled;
}

function randomNumberInInterval(min, max) {
    var randomNumber = Math.floor(Math.random() * (max - min + 1) + min);
    return randomNumber;
}

function cellFill(id) {
    var cell = document.getElementById(id);
    var log = document.getElementById("log");

    if (hasWon) {
        return;
    }

    if (turn % 2 == 0) {
        cell.innerHTML = "X";
        turn++;
    }
    else {
        cell.innerHTML = "O";
        turn++;
    }

    hasWon = checkSequence();

    if (hasWon) {
        log.innerHTML = winTeam + " wins!";
    } else if (turn == 9) {
        writeOnLog("Nobody wins!");
    }
}

function checkSequence() {
    var center = getElement(4);
    var topLeft = getElement(0);
    var bottomRight = getElement(8);

    var checkCenter = checkCell(4);
    var firstDiagonal = center == getElement(0) && center == getElement(8);
    var secondDiagonal = center == getElement(2) && center == getElement(6);
    var vertical = center == getElement(1) && center == getElement(7);
    var horizontal = center == getElement(3) && center == getElement(5);
    var centerSequence = firstDiagonal || secondDiagonal || vertical || horizontal;

    if (checkCenter && centerSequence) {
        winTeam = center;
        if (firstDiagonal) {
            paintCells(0, 4, 8);
        }
        else if (secondDiagonal){
            paintCells(2, 4, 6);
        }
        else if (vertical){
            paintCells(1, 4, 7);
        } else {
            paintCells(3, 4, 5);
        }
        return true;
    }

    var checkTopLeft = checkCell(0);
    horizontal = topLeft == getElement(1) && topLeft == getElement(2);
    vertical = topLeft == getElement(3) && topLeft == getElement(6);
    var topLeftSequence = horizontal || vertical;

    if (checkTopLeft && topLeftSequence) {
        winTeam = topLeft;
        if (horizontal) {
            paintCells(0, 1, 2);
        } else {
            paintCells(0, 3, 6);
        }
        return true;
    }

    var checkBottomRight = checkCell(8);
    vertical = bottomRight == getElement(2) && bottomRight == getElement(5);
    horizontal = bottomRight == getElement(6) && bottomRight == getElement(7);
    var bottomRightSequence = horizontal || vertical;

    if (checkBottomRight && bottomRightSequence) {
        winTeam = bottomRight;
        if (horizontal) {
            paintCells(6, 7, 8);
        } else {
            paintCells(2, 5, 8);
        }
        return true;
    }

    return false;
}

function paintCells(id1, id2, id3) {
    document.getElementById(id1).style.color = color;
    document.getElementById(id2).style.color = color;
    document.getElementById(id3).style.color = color;
}

function getElement(id) {
    var element = document.getElementById(id).innerHTML;
    return element;
}

function clearTable() {
    for (var row = 0; row < 3; row++) {
        for (var col = 0; col < 3; col++) {
            var id = row * 3 + col;
            var element = document.getElementById(id);
            element.style.color = "#000";
            element.innerHTML = "";
        }
    }
    writeOnLog("Cleared.");
    turn = 0;
    hasWon = false;
}

function writeOnLog(message) {
    var log = document.getElementById("log");
    log.innerHTML = message;
}