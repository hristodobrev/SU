function scrollText() {
    var scrollingLabel = document.getElementById('scrolling-text');

    var labelWidth = scrollingLabel.offsetWidth;

    var currentPosition = scrollingLabel.offsetLeft - 1;

    if(labelWidth + currentPosition == 0) {
        currentPosition = window.innerWidth - 1;
    }

    if(currentPosition > 0) {
        var wdth = window.innerWidth - currentPosition;
    }

    scrollingLabel.style.left = currentPosition + 'px';
    scrollingLabel.style.width = wdth + 'px';
}

//scrolling-text

window.onload = setInterval(scrollText, 1);