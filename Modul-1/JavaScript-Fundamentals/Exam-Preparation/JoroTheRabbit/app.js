'use strict';

function solve(input) {
    var numbers = input.split(",").map(Number);
    var maxCount = 0;

    for (var startIndex = 0; startIndex < numbers.length; startIndex += 1) {
        for (var step = 1; step < numbers.length; step += 1) {
            var currentIndex = startIndex;
            var nextIndex = findIndex(currentIndex, step, numbers.length);
            var currentCount = 1;

            while (nextIndex != startIndex) {
                if (numbers[currentIndex] >= numbers[nextIndex]) {
                    break;
                }

                currentCount += 1;
                currentIndex = nextIndex;

                if (currentIndex + step >= numbers.length) {
                    nextIndex = findIndex(currentIndex, step, numbers.length);
                } else {
                    nextIndex = currentIndex + step;
                }
            }
            if (currentCount > maxCount) {
                maxCount = currentCount;
            }
        }
    }

    return maxCount;

    function findIndex(currentIndex, step, length) {
        return (currentIndex + step) % length;
    }
}

var input1 = "1, -2, -3, 4, -5, 6, -7, -8";

var input2 = "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0";

var input3 = "1, 1, 1";

console.log(solve(input1));
console.log(solve(input2));
console.log(solve(input3));