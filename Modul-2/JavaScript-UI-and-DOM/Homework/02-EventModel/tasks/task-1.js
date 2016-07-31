/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  

*/

function solve() {
  function solution(selector) {

    var button, element, i, length;

    if (typeof(selector) === 'string') {
      element = document.getElementById(selector);
      if (!element) {
        throw new Error('No element with such id!');
      }
    } else if (!(selector instanceof HTMLElement)) {
      throw new Error('No such element found in document!');
    } else {
      element = selector;
    }

    element.addEventListener('click', eventHandler);

    var buttonElements = document.getElementsByClassName('button');

    for (i = 0, length = buttonElements.length; i < length; i++) {
      buttonElements[i].innerHTML = 'hide';
    }

    function eventHandler(ev) {
      button = ev.target;
      element = button.nextElementSibling;

      while (element.className.indexOf('content') < 0) {
        if (element.className.indexOf('button') >= 0) {
          break;
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
  };
  return solution;
};

module.exports = solve;