function solve() {
	return function(selector, isCaseSensitive) {
		var element = selector;

		// isCaseSensitive - cast from string to bool
		isCaseSensitive = !!isCaseSensitive;

		// validated selector if is an actual CSS attribute or HTML element

		// use querySelector(css element)
		if (typeof element === 'string') {
			element = document.querySelector(element);

			// !element - not a valid element
			// !(element instanceof HTMLElement) - not a valid HTML element
		} else if (!element || !(element instanceof HTMLElement)) {
			throw new Error();
		}

		element.className += ' items-control';

		/*
		DocumentFragments are DOM Nodes.
		They are never part of the main DOM tree.
		The usual use case is to create the document fragment,
		append elements to the document fragment and then append the document fragment to the DOM tree.
		In the DOM tree, the document fragment is replaced by all its children.
		*/
		var docFragment = document.createDocumentFragment();

		/* Task 1: START */
		var addControls = document.createElement('div');
		addControls.className = 'add-controls';

		var addLabel = document.createElement('label');
		addLabel.innerHTML = 'Enter text';

		var addInput = document.createElement('input');
		addLabel.appendChild(addInput);

		var addButton = document.createElement('a');
		addButton.className = 'button';
		addButton.innerHTML = 'Add';
		addButton.style.display = 'inline-block';
		addButton.addEventListener('click', onAddButtonClick, false);

		addControls.appendChild(addLabel);
		addControls.appendChild(addButton);

		// By clicking the element with class button, a new item element with class list-item should be added to the element with class items-list (see 3. Result elements section_)
		// An element with class list-item must be added to the element with class items-list

		function onAddButtonClick(ev) {
			var value = addInput.value;
			addInput.value = '';

			textListItem.innerHTML = value;

			itemsList.appendChild(listItem.cloneNode(true));
		}
		/* Task 1: END */

		/* Task 2: START */
		var searchControls = document.createElement('div');
		searchControls.className = 'search-controls';

		var inputLabel = document.createElement('label');
		inputLabel.innerHTML = 'Search:';

		var inputAdd = document.createElement('input');

		inputAdd.addEventListener('input', onSearchInput, false);

		inputLabel.appendChild(inputAdd);

		searchControls.appendChild(inputLabel);

		var listItems = element.getElementsByClassName('list-item');

		function onSearchInput(ev) {
			var i;
			var searchInput = inputAdd.value;
			var length = itemsList.length;

			if (!isCaseSensitive) {
				searchInput = searchInput.toLowerCase();
			}

			for (i = 0; i < length; i += 1) {
				var itemToCheck = inputAdd[i].getElementByTagName('strong').innerHTML;
				if (!isCaseSensitive) {
					itemToCheck = itemToCheck.toLowerCase();
				}

				if (itemToCheck.indexOf(searchInput) < 0) {
					listItems[i].style.display = 'none';
				} else {
					listItems[i].style.display = '';
				}
			}

		}
		/* Task 2: END */

		/* Task 3: START */
		var resultElement = document.createElement('div');
		resultElement.className = 'result-controls';

		var itemsList = document.createElement('ul');
		itemsList.className = 'items-list';

		var listItem = document.createElement('li');
		listItem.className = 'list-item';

		var deleteButton = document.createElement('a');
		deleteButton.className = 'button';
		deleteButton.innerHTML = 'X';

		var textListItem = document.createElement('strong');

		listItem.appendChild(deleteButton);
		listItem.appendChild(textListItem);

		itemsList.addEventListener('click', onItemsButtonClick, false);


		resultElement.appendChild(itemsList);

		function onItemsButtonClick(ev) {
			// TODO:
		}

		/* Task 3: END */

		// Add all items to the docFragment and import them in the master element
		docFragment.appendChild(addControls);
		docFragment.appendChild(searchControls);
		docFragment.appendChild(resultElement);

		element.appendChild(docFragment);
	};
}

module.exports = solve;