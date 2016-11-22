function printDeckOfCards(cards) {
    class Card {
        constructor(suit, face) {
            this.suit = suit;
            this.face = face;
        }

        get suit() {
            return this._suit;
        }

        set suit(value) {
            let suits = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'A', 'J', 'K', 'Q'];
            if (!suits.includes(value)) {
                throw new Error('Invalid suit.');
            }

            this._suit = value;
        }

        get face() {
            return this._face;
        }

        set face(value) {
            let faces = ['S', 'H', 'D', 'C'];
            if (!faces.includes(value)) {
                throw new Error('Invalid face.');
            }

            this._face = value;
        }

        toString() {
            let face = '';
            switch (this.face) {
                case 'S':
                    face = '\u2660';
                    break;
                case 'H':
                    face = '\u2665';
                    break;
                case 'D':
                    face = '\u2666';
                    break;
                case 'C':
                    face = '\u2663';
                    break;
            }

            return `${this.suit}${face}`;
        }
    }

    let cardsArr = [];
    for (let card of cards) {
        let face = card.slice(-1);
        let suit = card.slice(0, card.length - 1);
        try {
            cardsArr.push(new Card(suit, face));
        } catch (e) {
            console.log(`Invalid card: ${card}`);
            return;
        }
    }

    console.log(cardsArr.join(' '));
}