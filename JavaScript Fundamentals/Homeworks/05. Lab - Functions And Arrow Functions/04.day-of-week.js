function dayOfWeek([day]) {
    let days = [];
    days['Monday'] = 1;
    days['Tuesday'] = 2;
    days['Wednesday'] = 3;
    days['Thursday'] = 4;
    days['Friday'] = 5;
    days['Saturday'] = 6;
    days['Sunday'] = 7;

    let dayNum = days[day] || 'error';
    return dayNum;
}