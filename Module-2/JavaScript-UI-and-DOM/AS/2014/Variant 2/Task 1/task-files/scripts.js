function createImagesPreviewer(selector, items) {
	var currentSelector = document.querySelector(selector),
		leftDiv = document.createElement('div'),
		rightDiv = document.createElement('div'),
		elements = document.createElement('div'),
		listElement = document.createElement('div'),
		searchDiv = document.createElement('div'),
		searchField = document.createElement('input');
		paragraph = document.createElement('p');

	divStyle(leftDiv, 29, 300, animals[0].title, animals[0].url, 'mainDiv', 'left', 30, 30, 30, 20, null);
	divStyle(rightDiv, 13, 370, null, null, 'listDiv', 'left', 30, 30 ,30, 20, 'overflow-y: hidden');

	styleSearchDiv();
	rightDiv.appendChild(searchDiv);

	for (var i = 0, len = animals.length; i < len; i++) {
		var currentElement = listElement.cloneNode(true);

		currentElement.addEventListener('mouseover', onMouseOver, false);
		currentElement.addEventListener('mouseout', onMouseOut, false);
		currentElement.addEventListener('click', onMouseClick, false);

		divStyle(currentElement, 90, 120, animals[i].title, animals[i].url, 'listElement', 'left', 14, 0, 0, 10, null);

		elements.appendChild(currentElement);
	}

	rightDiv.appendChild(elements);
	currentSelector.appendChild(leftDiv);
	currentSelector.appendChild(rightDiv);

	function divStyle(selector, width, height, text, url, classs, float, fontSize, marginTop, marginBottom, radius, overflow){
		selector.style.width = width + '%';
		selector.style.height = height + 'px';
		selector.style.float = float;
		selector.style.display = 'inline-block';
		selector.classList.add(classs);
		if (overflow !==null) {
			selector.style.overflowY='scroll';
		}
		
	
		if (url !== null) {
			selector.appendChild(createStrong(text, fontSize, marginTop, marginBottom));
			selector.appendChild(createImage(url, radius));
		}
	}

	function createStrong(text, fontSize, marginTop, marginBottom) {
		var strong = document.createElement('strong');
		
		strong.innerText = text;
		strong.style.display = 'block';
		strong.style.textAlign = 'center';
		strong.style.width = '95%';
		strong.style.fontSize = fontSize + 'px';
		strong.style.marginTop = marginTop + 'px';
		strong.style.marginBottom = marginBottom + 'px';

		return strong;
	}

	function createImage(url, radius) {
		var image = document.createElement('img');

		image.src = url;
		image.style.width = '95%';
		image.style.display = 'block';
		image.style.borderRadius = radius + 'px';
		image.style.marginBottom = '0px';
		image.style.marginTop = '0px';

		return image;
	}

	function styleSearchDiv() {
		paragraph.innerText = 'Filter';
		paragraph.style.textAlign = 'center';
		paragraph.style.margin = '0px';
		paragraph.style.width = '87%';

		searchDiv.appendChild(paragraph);

		searchField.type = 'text';
		searchField.style.width = '87%';
		searchField.addEventListener('change', onSearch, false);

		searchDiv.appendChild(searchField);
	}

	function onMouseClick () {
		leftDiv.innerHTML = '';
		divStyle(leftDiv,29, 300, this.childNodes[0].innerText, this.childNodes[1].src, 'mainDiv', 'left', 30, 30, 30, 20, null);
	}

	function onMouseOver () {
		if (this.id !== 'selected') {
			this.style.backgroundColor = '#CACACA';
		}
	}

	function onMouseOut () {
		if (this.id !== 'selected') {
			this.style.backgroundColor = '#fff';
		}
	}

	function onSearch () {

		elements.innerHTML = '';
		for (var i = 0, len = animals.length; i < len; i++) {
			var currentElement = listElement.cloneNode(true),
				title = animals[i].title.toLowerCase();


			if (this.value ==='' || title.contains(this.value)) {
				currentElement.addEventListener('mouseover', onMouseOver, false);
				currentElement.addEventListener('mouseout', onMouseOut, false);
				currentElement.addEventListener('click', onMouseClick, false);

				divStyle(currentElement, 90, 120, animals[i].title, animals[i].url, 'listElement', 'left', 14, 0, 0, 10, null);

				elements.appendChild(currentElement);
			}
		}
	}

	if ( !String.prototype.contains ) {
		String.prototype.contains = function() {
			return String.prototype.indexOf.apply( this, arguments ) !== -1;
		};
	}
}