/* globals module, document, HTMLElement, console */

function solve() {
	function solution(selector, isCaseSensitive) {

		var c = document.getElementById('the-canvas');
		var c2 = c.getCon

		var textListItem;
		var listResults;
		var listItemTemplate;
		var element = selector;

		isCaseSensitive = !!isCaseSensitive;
		if (typeof element === 'string') {
			element = document.querySelector(element);
		}
		if (!element || !(element instanceof HTMLElement)) {
			throw new Error('Invalid HTML element or selector');
		}

		/*
		DocumentFragments are DOM Nodes.
		They are never part of the main DOM tree.
		The usual use case is to create the document fragment,
		append elements to the document fragment and then append the document fragment to the DOM tree.
		In the DOM tree, the document fragment is replaced by all its children.
		*/
		var docFragment = document.createDocumentFragment();

		/* Task 1: START */

		// Adding elements part must consist of an element with class add-controls, that contains:
		var addElements = document.createElement('div');
		addElements.className = 'add-controls';

		// Text "Enter text"
		var addLabel = document.createElement('label');
		addLabel.innerHTML = 'Enter text';

		// An input element
		var addInput = document.createElement('input');
		addLabel.appendChild(addInput);

		// An element with class button and content 'Add'
		var addButton = document.createElement('a');
		addButton.className = 'button';
		addButton.innerHTML = 'Add';
		addButton.addEventListener('click', onAddButtonClick, false);

		// Add the created elements to their parent div
		addElements.appendChild(addLabel);
		addElements.appendChild(addButton);

		/* Task 1: END */

		/* Task 2: START */

		// Search elements part must consist of an element with class search-controls, that contains:
		var searchElements = document.createElement('div');
		searchElements.className = 'search-controls';

		// Text "Search"
		var searchLabel = document.createElement('label');
		searchLabel.innerHTML = 'Search';

		// An input element
		var searchInput = document.createElement('input');

		searchInput.addEventListener('input', onSearchInput, false);

		// Add the created searchInput to the searchLabel
		searchLabel.appendChild(searchInput);

		// Add the created elements to their parent div
		searchElements.appendChild(searchLabel);

		/* Task 2: END */

		/* Task 3: START */

		// Result elements part must consists of an element with class result-controls, that contains:
		var resultElements = document.createElement('div');
		resultElements.className = 'result-controls';

		var resultList = document.createElement('ul');

		/* Task 3: END */

		// Add all items to the docFragment and import them in the master element
		docFragment.appendChild(addElements);
		docFragment.appendChild(searchElements);
		docFragment.appendChild(resultElements);


		element.appendChild(docFragment);
		

		/*
		By clicking the element with class button, a new item element with class list-item should be added to the element with class items-list (see 3. Result elements section_)
		An element with class list-item must be added to the element with class items-list
		*/
		function onAddButtonClick(ev) {
			var value = addButton.value;
			addInput.value = '';

			textListItem.innerHTML = value;

			listResults.appendChild(listItemTemplate.cloneNode(true));
		}

		/*
		Hides all the elements with class list-item that does not contain the value of the input
		The search can be either case-sensitive or case-insensitive, depending on the isCaseSensitive parameter
		Hide the elements with display: none, otherwise, it will not be evaluated as correct!
		*/
		function onSearchInput(ev) {

		}


	};

	return solution;
}

module.exports = solve;