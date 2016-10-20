function initializeTable() {
    $('#createLink').click(function () {
        let countryName = $('#newCountryText').val();
        let capital = $('#newCapitalText').val();
        appendCountryToTable(countryName, capital);
    });

    appendCountryToTable('Bulgaria', 'Sofia');
    appendCountryToTable('Germany', 'Berlin');
    appendCountryToTable('Russia', 'Moscow');
    fixRowActions();

    function appendCountryToTable(countryName, capital) {
        let tr = $('<tr>')
            .append($('<td>').text(countryName))
            .append($('<td>').text(capital));

        let upLink = $('<a href="#">[Up]</a>')
            .click(moveUp);
        let downLink = $('<a href="#">[Down]</a>')
            .click(moveDown);
        let delLink = $('<a href="#">[Delete]</a>')
            .click(deleteItem);

        tr.append($('<td>')
            .append(upLink)
            .append(' ')
            .append(downLink)
            .append(' ')
            .append(delLink));

        $('#countriesTable').append(tr);
    }

    function fixRowActions() {
        $('#countriesTable a').css('display', 'inline');
        let rows = $('#countriesTable tr');
        $(rows[2]).find("a:contains('Up')").css('display', 'none');
        $(rows[rows.length - 1]).find("a:contains('Down')").css('display', 'none');
    }

    function deleteItem() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.remove();
            fixRowActions();
        });
    }

    function moveUp() {
        let row = $(this).parent().parent();
        row.fadeOut(function() {
            row.prev().insertAfter(row);
            row.fadeIn();
            fixRowActions();
        });
    }

    function moveDown() {
        let row = $(this).parent().parent();
        row.fadeOut(function() {
            row.next().insertBefore(row);
            row.fadeIn();
            fixRowActions();
        });
    }
}