var check = 0;

function appendDiv(index){
    var paragraph = document.getElementsByTagName("p")[index];
    if (check == 0) {
        paragraph.style.maxHeight = "400px";
        paragraph.style.borderBottom = "1px solid #d3d3d3";
        paragraph.style.paddingBottom = "5px";
        check = 1;
        return;
    }
    if (check == 1) {
        paragraph.style.maxHeight = "150px";
        paragraph.style.borderBottom = "none";
        paragraph.style.paddingBottom = "0";
        check = 0;
    }
}