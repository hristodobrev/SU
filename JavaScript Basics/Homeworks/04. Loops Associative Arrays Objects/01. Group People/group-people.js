function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}

var people = [
    new Person("Scott", "Guthrie", 38),
    new Person("Scott", "Johns", 36),
    new Person("Scott", "Hanselman", 39),
    new Person("Jesse", "Liberty", 57),
    new Person("Jon", "Skeet", 38)
];

function groupBy(criteria) {
    var groupedPeople = {};
    for(var index in people) {
        var key = people[index][criteria];
        if(groupedPeople[key] == undefined){
            groupedPeople[key] = [];
        }
        groupedPeople[key].unshift(people[index]);
    }
    return groupedPeople;
}

function printPeople(groupedPeople) {
    for(var group in groupedPeople) {
        var curGroup = [];
        for(var index in groupedPeople[group]) {
            var curPerson = groupedPeople[group][index];
            curGroup.unshift(curPerson.firstName + ' ' + curPerson.lastName + '(age ' + curPerson.age + ')');
        }
        console.log("Group " + group + " : [" + curGroup.join(', ') + ']');
    }
}