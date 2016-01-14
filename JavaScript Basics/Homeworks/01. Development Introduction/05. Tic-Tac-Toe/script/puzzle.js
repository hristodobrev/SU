var index = 0;

function initialize() {
    document.getElementById(index).style.backgroundColor = "#fff";
    document.getElementById(index).style.boxShadow = "none";
    index = 0;
    var numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
    var randomizedNumbers = shuffle(numbers);

    for (cellIndex = 0; cellIndex <= 15; cellIndex++) {
        var element = getElement(cellIndex);
        element.innerHTML = numbers[cellIndex - 1];
    }

    var element = getElement(index);
    element.innerHTML = "";

    exchangeCells(index, index);
}

function shuffle(array) {
    var tmp, current, top = array.length;
    if(top) while(--top) {
        current = Math.floor(Math.random() * (top + 1));
        tmp = array[current];
        array[current] = array[top];
        array[top] = tmp;
    }
    return array;
}

function cellClick(id) {
    var oldIndex = id;
    if ((id - 1) == index || (id + 1) == index || (id - 4) == index || (id + 4) == index) {
        exchangeCells(index, oldIndex);
        index = id;
    }
    if (checkWin()) {
        alert("Congratulations, you have won!");
    }
}

function checkWin() {
    var hasWon = true;
    for(var index = 0; index < 15; index++) {
        if(document.getElementById(index).innerHTML != index + 1) {
            hasWon = false;
        }
    }
    return hasWon;
}

function exchangeCells(firstIndex, secondIndex) {
    var firstElement = document.getElementById(firstIndex).innerHTML;
    var secondElement = document.getElementById(secondIndex).innerHTML;

    document.getElementById(firstIndex).innerHTML = secondElement;
    document.getElementById(secondIndex).innerHTML = firstElement;
    document.getElementById(firstIndex).style.backgroundColor = "#fff";
    document.getElementById(firstIndex).style.boxShadow = "none";
    document.getElementById(secondIndex).style.backgroundColor = "#f7f7f7";
    document.getElementById(secondIndex).style.boxShadow = "inset 0 0 8px 0 #444";
}

function getElement(id) {
    var element = document.getElementById(id);
    return element;
}