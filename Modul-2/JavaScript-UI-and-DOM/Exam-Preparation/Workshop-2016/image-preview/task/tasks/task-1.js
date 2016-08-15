/* globals module */
function solve() {
    return function(selector, items) {
        var element = selector;

        // validated selector if is an actual CSS attribute or HTML element

        // use querySelector(css element)
        if (typeof element === 'string') {
            element = document.querySelector(element);

            // !element - not a valid element
            // !(element instanceof HTMLElement) - not a valid HTML element
        } else if (!element || !(element instanceof HTMLElement)) {
            throw new Error();
        }


        var docFragment = document.createDocumentFragment();

        var imagePreviewer = document.createElement('div');
        imagePreviewer.style.display = 'inline-block';
        imagePreviewer.style.width = '75%';
        imagePreviewer.style.float = 'left';
        imagePreviewer.style.textAlign = 'center';

        var aside = document.createElement('div');
        aside.style.display = 'inline-block';
        aside.style.width = '25%';
        aside.style.textAlign = 'center';

        var selectedParent = document.createElement('div');
        selectedParent.classList.add('image-preview');

        var selectedImageHeader = document.createElement('h3');
        selectedImageHeader.innerHTML = items[0].title;

        var selectedImage = document.createElement('img');
        selectedImage.src = items[0].url;
        selectedImage.style.width = '50%';

        var inputHeader = document.createElement('h3');
        inputHeader.innerHTML = 'Filter';

        var inputText = document.createElement('input');
        inputText.style.textAlign = 'center';

        inputText.addEventListener('keyup', function (ev) {
            var text = ev.target.value;
            var liChildren = listOfItems.getElementsByTagName('li');
            for(var i = 0, len = liChildren.length; i < len; i += 1) {
                var currentLi = liChildren[i];
                var header = currentLi.firstElementChild.innerHTML;

                if (header.toLowerCase().indexOf(text.toLowerCase()) >= 0) {
                    currentLi.style.display = 'block';
                } else {
                    currentLi.style.display = 'none';
                }
            }
        }, false);

        var listOfItems = document.createElement('ul');
        listOfItems.style.listStyleType = 'none';
        listOfItems.style.height = '500px';
        listOfItems.style.overflowY = 'scroll';
        listOfItems.addEventListener('click', function(ev) {
            var target = ev.target;
            // check if the selected item is an image
            if (target.tagName === 'IMG') {
                // because we've selected the image, we need the previous element, which is the header
                // we are using previousElementSibling to take it's text
                var header = target.previousElementSibling.innerHTML;

                // target.src directly, because the image is selected
                var src = target.src;

                selectedImageHeader.innerHTML = header;
                selectedImage.src = src;
            }
        }, false);

        listOfItems.addEventListener('mouseover', function(ev) {
            var target = ev.target;
            if (target.tagName === 'IMG') {
                target.parentElement.style.backgroundColor = 'gray';
                target.parentElement.style.cursor = 'pointer';
            }
        }, false);

        listOfItems.addEventListener('mouseout', function(ev) {
            var target = ev.target;
            if (target.tagName === 'IMG') {
                target.parentElement.style.backgroundColor = '';
            }
        }, false);

        var li = document.createElement('li');
        li.classList.add('image-container');

        var imageHeader = document.createElement('h3');
        var image = document.createElement('img');
        image.style.width = '100%';

        for (var i = 0, len = items.length; i < len; i += 1) {
            var currentItem = items[i];

            var currentLi = li.cloneNode(true);

            var currentImageHeader = imageHeader.cloneNode(true);
            currentImageHeader.innerHTML = currentItem.title;

            var currentImage = image.cloneNode(true);
            currentImage.src = currentItem.url;

            currentLi.appendChild(currentImageHeader);
            currentLi.appendChild(currentImage);

            listOfItems.appendChild(currentLi);
        }

        selectedParent.appendChild(selectedImageHeader);
        selectedParent.appendChild(selectedImage);

        imagePreviewer.appendChild(selectedParent);

        aside.appendChild(inputHeader);
        aside.appendChild(inputText);
        aside.appendChild(listOfItems);


        docFragment.appendChild(imagePreviewer);
        docFragment.appendChild(aside);
        element.appendChild(docFragment);
    };
}

module.exports = solve;