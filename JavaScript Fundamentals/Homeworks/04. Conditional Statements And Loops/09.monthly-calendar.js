function calendar([day, month, year]) {
    let date = new Date(year, month - 1, day);

    let html = '<table>\n  <tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n';
    html += '  <tr>';

    let startDate = new Date(date.getTime());
    startDate.setDate(0);
    let firstDayOfMonth = startDate.getDay();
    //console.log(firstDayOfMonth);
    if (firstDayOfMonth > 0 && firstDayOfMonth != 6) {
        let prevDate = new Date(date.getTime());
        prevDate.setDate(0);
        let lastDayOfPrevMonth = prevDate.getDate();
        //console.log(prevDate);
        //console.log(lastDayOfPrevMonth);
        for (let i = firstDayOfMonth; i >= 0; i--) {
            html += '<td class="prev-month">' + (lastDayOfPrevMonth - i) + '</td>';
        }
    }

    if (year == 1900) {
        html += '<td class="prev-month">31</td>';
    }

    let offset = firstDayOfMonth;
    //console.log(offset);
    let currentMonth = new Date(date);
    currentMonth.setDate(1);
    //console.log(currentMonth.getDate());
    do {
        if (currentMonth.getDate() == day) {
            html += '<td class="today">' + currentMonth.getDate() + '</td>';
        } else {
            html += '<td>' + currentMonth.getDate() + '</td>';
        }

        currentMonth.setDate(currentMonth.getDate() + 1);
        if (offset === 5) {
            html += '</tr>\n';
            if (currentMonth.getDate() != 1) {
                html += '  <tr>';
            }
        }

        offset++;
        offset = offset % 7;
    } while (currentMonth.getDate() != 1)

    if (offset < 6 && offset != 0) {
        for (let i = 1; i < 7 - offset; i++) {
            html += '<td class="next-month">' + i + '</td>';
        }
        html += '</tr>\n';
    }

    html += '</table>';
    //console.log(html);
    return html;
}