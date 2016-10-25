function increment(selector) {
    let textarea = $('<textarea class="counter" disabled>07. calendar</textarea>');
    let incrementBtn = $('<button class="btn" id="incrementBtn">Increment</button>');
    let addBtn = $('<button class="btn" id="addBtn">Add</button>');

    incrementBtn.on('click', function () {
        textarea.val(Number(textarea.val()) + 1);
    });

    addBtn.on('click', function () {
        ul.append($('<li>').text(textarea.val()));
    });

    let ul = $('<ul class="results">');
    $(selector)
        .append(textarea)
        .append(incrementBtn)
        .append(addBtn)
        .append(ul);
}