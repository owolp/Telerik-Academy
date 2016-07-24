function eventHandler(ev) {
	button = ev.target;
	element = button.nextElementSibling;
	while (element.className.indexOf('content') < 0) {
		if (element.className.indexOf('button') >= 0) {
			break;
		}

		if (element.className.i) {
			
		}

		element = element.nextElementSibling;
	}

	if (element.className.indexOf('button') >= 0) {
		return;
	}
	if (element.style.display === 'none') {
		button.innerHTML = 'hide';
		element.style.display = '';
	} else {
		button.innerHTML = 'show';
		element.style.display = 'none';
	}
}