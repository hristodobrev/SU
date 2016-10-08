function lastMonth([day, month, year]) {
    let date = new Date(year, month - 1, day);
    date.setDate(1);
    date.setDate(date.getDate() - 1);
    return date.getDate();
}