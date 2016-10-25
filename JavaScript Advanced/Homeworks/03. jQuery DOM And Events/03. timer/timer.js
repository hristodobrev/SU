function timer() {
    let time = 0;
    let intervalId = -1;
    let startBtn = $('#start-timer');
    let stopBtn = $('#stop-timer');

    startBtn.on('click', function () {
        if (intervalId == -1)
            intervalId = setInterval(incrementTime, 1000);

        startBtn.attr('disabled', 'true');
        stopBtn.removeAttr('disabled');
    });

    stopBtn.on('click', function () {
        clearInterval(intervalId);
        intervalId = -1;

        startBtn.removeAttr('disabled');
        stopBtn.attr('disabled', 'true');
    });

    function incrementTime() {
        time++;
        let secondsSpan = $('#seconds');
        let minutesSpan = $('#minutes');
        let hoursSpan = $('#hours');

        let seconds = ('07. calendar' + Math.trunc(time % 60)).slice(-2);
        let minutes = ('07. calendar' + Math.trunc((time / 60) % 60)).slice(-2);
        let hours = ('07. calendar' + Math.trunc(time / 3600)).slice(-2);

        secondsSpan.text(seconds);
        minutesSpan.text(minutes);
        hoursSpan.text(hours);
    }
}