/* globals $ */

/* 
Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

function solve() {

  // element - id or DOM element
  // content - array of contents
  function solution (element, contents) {

    if (!contents || isNaN(contents.length)) {
      throw new Error('Contents is not a valid object');
    }

    var contentsLength, i, content, currentDiv,
      frag = document.createDocumentFragment(),
      div = document.createElement('div');

    contents = [].slice.call(contents); // as contents is not an actual array the function [].slice.call(contents) turn is into an actual array;

    if (typeof(element) === 'string') {
      element = document.getElementById(element);
      if (!element) {
        throw new Error('No element with the provided id!');
      }
    } else if (!(element instanceof HTMLElement)) {
      throw new Error('Not a valid HTML element!');
    }

    for (i = 0, contentsLength = contents.length; i < contentsLength; i += 1) {
      content = contents[i],
        currentDiv = div.cloneNode(true);
      if (typeof(content) !== 'string' && typeof(content) !== 'number') {
        throw new Error('Invalid content!');
      }

      currentDiv.innerHTML = content;
      frag.appendChild(currentDiv);
    };

    element.innerHTML = '';
    element.appendChild(frag);

  };

  return solution;
};