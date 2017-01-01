function spyMaster(input) {
    let text = input.splice(1);
    let specialKey = input[0];

    let regex = new RegExp('(?: |^)(?:' + specialKey + ')[ ]*([a-z\\!\\%\\#\\$]{8,})(?: |\\,|\\.|\\n|$)', 'gi');
    //let specialKeyReg = /^[A-Za-z]+$/;

    for (let i = 0; i < text.length; i++) {
        let line = text[i];
        let match;
        while (match = regex.exec(line)){
            let word = match[1];
            if (word == word.toUpperCase() && word.toLowerCase() != specialKey.toLowerCase()){
                line = line.replace(word, word
                    .replace(/\!/g, 1)
                    .replace(/\%/g, 2)
                    .replace(/\#/g, 3)
                    .replace(/\$/g, 4)
                    .toLowerCase());
            }
        }
        console.log(line);
    }
}

// Special Key: preceed:

// spyMaster([
//     'specialKey SpecIALKey ANDMSG!!!',
//     'specialKey SpecIALKey ANDMSG!!! MADFAG$!#D% EGSF'
// ]);

spyMaster([
    'enCode_',
    'Some messages are just not encoded what can you do?',
    'RE - ENCODE_ THEMNOW! - he said.',
    'Damn encode, ITSALLHETHINKSABOUT., eNcoDe BULL$#!%.',
    'enCODE ENCODEING... encode GEAGESG$$$; encode THEENCODING by encodeINGDAWFWEGAG'
]);

// (?:\s+|^)(?i:specialkey)\s+([A-Z\!\%\#\$]+)(?:[,.\s]+|$)