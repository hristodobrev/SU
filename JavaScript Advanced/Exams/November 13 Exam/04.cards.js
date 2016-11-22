function cardDeckBuilder(selector) {
    function addCard(face, suit) {
        let suits = {
            'C': '\u2663',
            'D': '\u2666',
            'H': '\u2665',
            'S': '\u2660'
        };

        function reverseCards() {
            let cards = $(selector).children();
            $(selector).empty();
            for (let i = cards.length - 1; i >= 0; i--) {
                $(cards[i]).on('click', reverseCards);
                $(selector).append($(cards[i]));
            }
        }

        let cardText = face + ' ' + suits[suit];
        let card = $('<div class="card">').text(cardText).on('click', reverseCards);

        $(selector).append(card);
    }

    return {
        addCard
    };
}