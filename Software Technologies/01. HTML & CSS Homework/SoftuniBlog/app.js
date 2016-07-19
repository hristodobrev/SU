"use strict";

function stringifyObjects(arr){
    let obj = {};

    for(let line of arr){
        let args = line.split(' -> ');
        let key = args[0];
        let value = args[1];
        if(Number(value)) {
            value = Number(value);
        }
        obj[key] = value;
    }

    console.log(JSON.stringify(obj));
}

stringifyObjects(['name -> Angel',
        'surname -> Georgiev',
        'age -> 20',
        'grade -> 6.00',
        'date -> 23/05/1995',
        'town -> Sofia'
    ]);