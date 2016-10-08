function filterByAge(args) {
    var minAge = Number(args[0]);
    var fName = args[1];
    var fAge = Number(args[2]);
    var sName = args[3];
    var sAge = Number(args[4]);

    var firstPerson = { name: fName, age: Number(fAge)};
    var secondPerson = { name: sName, age: Number(sAge)};

    if (firstPerson.age >= minAge) {
        console.log(firstPerson);
    }

    if (secondPerson.age >= minAge) {
        console.log(secondPerson);
    }
}