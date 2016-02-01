function findYoungestPerson(array) {
    var peopleWithSmartphones = array.filter(function (person) {
        return person.hasSmartphone;
    });

    var youngestPerson = peopleWithSmartphones[0];

    for (var index in peopleWithSmartphones) {
        var currentPerson = peopleWithSmartphones[index];
        if (currentPerson.age < youngestPerson.age) {
            youngestPerson = currentPerson;
        }
    }

    console.log('The youngest person is ' + youngestPerson.firstname + ' ' + youngestPerson.lastname);
}

var people = [
    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }];

findYoungestPerson(people);