'use strict';

function solve(input) {
    var numbers = input[0]
        .split(",")
        .map(Number);
    var m = parseInt(input[1]);
    var maxCollectedCoints = 0;
    var length = numbers.length;

    for (var i = 2; i < m + 2; i += 1) {

        var patterns = input[i]
            .split(",")
            .map(Number);
        var copiedArray = numbers.slice(0);

        var currentPosition = 0;
        var currentNumber = patterns[currentPosition];
        var currentCoints = 0;
        var pattern = 0;

        while (true) {
            if (currentNumber === 0 || currentPosition + patterns.length > copiedArray.length) {
                if (currentCoints > maxCollectedCoints) {
                    maxCollectedCoints = currentCoints;
                }
                break;
            }

            currentCoints += copiedArray[currentPosition];
            copiedArray[currentPosition] = 0;

            var nextPosition = 0;

            if (pattern >= patterns.length) {
                pattern = 0;
            }

            var positionsToMove = patterns[pattern];
            nextPosition = currentPosition + positionsToMove;

            if (copiedArray[nextPosition] === 0) {
                if (currentCoints > maxCollectedCoints) {
                    maxCollectedCoints = currentCoints;
                }
                break;
            }

            currentCoints += copiedArray[nextPosition];
            copiedArray[nextPosition] = 0;
            currentPosition = nextPosition;

            pattern += 1;
        }
    }
    return maxCollectedCoints;
}

var input1 = [
    "1, 3, -6, 7, 4 ,1, 12",
    "3",
    "1, 2, -3",
    "1, 3, -2",
    "1, -1"
];

console.log(solve(input1) == 21);