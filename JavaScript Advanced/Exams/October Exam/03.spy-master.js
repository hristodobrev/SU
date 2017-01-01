function spyMaster(input) {
    let original = [];
    for (let i = 0; i < input.length; i++) {
        original[i] = input[i];
    }
    let specialKey = input[0];
    for (let i = 1; i < input.length; i++) {
        let regex = new RegExp(specialKey, 'gi');
        input[i] = input[i].replace(regex, specialKey);

        let reg = new RegExp('(\\s+|^)' + specialKey + '\\s+([A-Z\\!\\%\\#\\$]{8,})([\\,\\.\\s]+|$)', 'g');
        let match;
        while (match = reg.exec(input[i])) {
            // console.log(match);
            if (match !== null) {
                let repl = match[2];
                repl = repl.replace(/\!/g, '1').replace(/\%/g, '2').replace(/\#/g, '3').replace(/\$/g, '4').toLowerCase();
                original[i] = original[i].replace(match[2], repl);
            }
        }

        console.log(original[i]);
    }
}

spyMaster([
    'specialKey',
    'In this text the specialKey HELLOWORLD!,.   is correct, but',
    'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
    '  SpeCIaLkeY   SOM%%ETH$IN and  SPECIALKEY ##$$##$$ are!',
    'SpeCIaLkeY   SOM%%ETH$IN and| SPECIALKEY ##$$##$$',
    'speciALKEY   CORRECT!#$%MESSAGE followed by specialKEy',
    'ICCORECT$MESSAGE'
]);