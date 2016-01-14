function scaleGrades(students) {

    students.map(function (st) {
        st.score *= 1.1;
        st['hasPassed'] = st.score > 100;
    });

    var filtered = students.filter(function(st) {
        return st.hasPassed;
    }).sort(function (st1, st2) {
        return st1.name > st2.name;
    });

    console.log(filtered.join(','));

    for(var index in filtered) {
        console.log(filtered[index]);
    }
}