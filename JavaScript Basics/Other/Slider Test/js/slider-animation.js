function changeId() {
    var images = document.getElementsByTagName("img");
    var imagesList = Array.prototype.slice.call(images);
    
	for(var ind in imagesList) {
		imagesList[ind].onclick = function (img) {
			document.getElementById('largeImg').src = img.src;
			showLargeImagePanel();
			unselectAll();
			setTimeout(function() {
				document.getElementById('largeImg').src = img.src;
			}, 1)
		};
	}
	
}

function showImage(img) {
	document.getElementById('largeImg').src = img.src;
	showLargeImagePanel();
	unselectAll();
	setTimeout(function() {
		document.getElementById('largeImg').src = img.src;
	}, 1)
}

function showLargeImagePanel() {
	document.getElementById('largeImgPanel').style.display = 'block';
}

function unselectAll() {
	if(document.selection)
		document.selection.empty();
	if(window.getSelection)
		window.getSelection().removeAllRanges();
}



