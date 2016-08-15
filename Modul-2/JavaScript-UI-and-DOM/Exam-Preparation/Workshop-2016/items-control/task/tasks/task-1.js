function solve() {
	return function(selector, isCaseSensitive) {
		var element = selector;

		isCaseSensitive = !!isCaseSensitive;

		if (typeof element === 'string') {
			element = document.querySelector(element);
		} else if (!element || !(element instanceof HTMLElement)) {
			throw new Error();
		}

		element.className += ' items-control';

		var docFragment = document.createDocumentFragment();

		// TASK 1 START
		var addControls = document.createElement('div');
		addControls.className = 'add-controls';
		var addLabel = document.createElement('label');
		addLabel.innerHTML = 'Enter text: ';
		var addInput = document.createElement('input');
		var addButton = document.createElement('button');
		addButton.className = 'button';
		addButton.innerHTML = 'Add';
		addButton.addEventListener('click', function(ev) {
			var value = addInput.value;
			addInput.value = '';
			listText.innerHTML = value;
			var listItem = listItemTemplate.cloneNode(true);
			itemsList.appendChild(listItem);
		}, false);

		addControls.appendChild(addLabel);
		addControls.appendChild(addInput);
		addControls.appendChild(addButton);
		// TASK 1 END

		// TASK 2 START
		var searchControls = document.createElement('div');
		searchControls.className = 'search-controls';
		var searchLabel = document.createElement('label');
		searchLabel.innerHTML = 'Search: ';
		var searchInput = document.createElement('input');
		searchInput.addEventListener('keyup', function(ev) {
			var text = ev.target.value;
			var liChildren = itemsList.getElementsByTagName('li');

			if (!isCaseSensitive) {
				text = text.toLowerCase();
			}

			for(var i = 0, len = itemsList.length; i < len; i += 1) {
				var currentLi = liChildren[i];
				var currentHeader = currentLi.getElementsByTagName('h3');
				var header = currentHeader.innerHTML;

				if(!isCaseSensitive) {
					header = header.toLowerCase();
				}

				if(header.indexOf(text) >= 0) {
					currentLi.style.display = 'block';
				} else {
					currentLi.style.display = 'none';
				}
			}
		}, false);

		searchControls.appendChild(searchLabel);
		searchControls.appendChild(searchInput);
		// TASK 2 END

		// TASK 3 START
		var resultControls = document.createElement('div');
		resultControls.className = 'result-controls';
		var itemsList = document.createElement('ul');
		itemsList.className = 'items-list';
		var listItemTemplate = document.createElement('li');
		listItemTemplate.clasName = 'list-item';
		var listButton = document.createElement('button');
		listButton.className = 'button';
		listButton.innerHTML = 'X';
		var listText = document.createElement('h3');

		listItemTemplate.appendChild(listButton);
		listItemTemplate.appendChild(listText);

		resultControls.appendChild(itemsList);
		// TASK 3 END

		docFragment.appendChild(addControls);
		docFragment.appendChild(searchControls);
		docFragment.appendChild(resultControls);

		element.appendChild(docFragment);
	};
}

module.exports = solve;