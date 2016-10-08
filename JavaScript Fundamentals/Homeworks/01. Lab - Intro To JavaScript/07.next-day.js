function nextDay([year, month, day]) {
    var date = new Date(year, month - 1, day);
    var newDate = new Date(date.getTime() + (24 * 60 * 60 * 1000));

    console.log(newDate.getFullYear() + '-' + (newDate.getMonth() + 1) + '-' + newDate.getDate());
}