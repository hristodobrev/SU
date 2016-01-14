function replaceATag(str) {
    var regex = /(<a).+?(>).+?(<\/a>)/g;
    var match;
    while(match = regex.exec(str)) {
        firstGroup = match[1];
        secondGroup = match[2];
        thirdGroup = match[3];
        console.log(str.replace(firstGroup, '[URL').replace(secondGroup, ']').replace(thirdGroup, '[/URL]'));
    }
}