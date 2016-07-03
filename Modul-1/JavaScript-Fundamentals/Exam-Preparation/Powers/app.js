'use strict';
var input1, input2, input3;

function solve(params) {
    var nk = params[0].split(' ').map(Number),
        s = params[1].split(' ').map(Number),
        n, k, i, currentNumber, j, length,
        newArray = [],
        tempNumber,
        result = 0;

    n = nk[0];
    k = nk[1];

    function getValue(s, j, currentNumber) {
        if (currentNumber === 0) {
            var a = s[j - 1];
            var b = s[j + 1];
            var r = Math.abs(s[j - 1] - s[j + 1]);
            return r;
        } else if (currentNumber === 1) {
            return s[j - 1] + s[j + 1];
        } else if (currentNumber % 2 === 0) {
            return Math.max(s[j - 1], s[j + 1]);
        } else if (!currentNumber % 2 === 0) {
            return Math.min(s[j - 1], s[j + 1]);
        }
    }

    length = s.length;
    for (i = 0; i < k; i += 1) {
        s[-1] = s[length - 1];
        s[length] = s[0];
        newArray = [];

        for (j = 0; j <= length; j += 1) {
            currentNumber = s[j];

            tempNumber = getValue(s, j, currentNumber);
            newArray.push(tempNumber);
        }

        s = newArray;
    }

    for (i = 0; i < length; i += 1) {
        result += s[i];
    }

    console.log(result);
}

input1 = [
    "5 1",
    "9 0 2 4 1"
];

input2 = [
    "10 3",
    "1 9 1 9 1 9 1 9 1 9"
];

input3 = [
    "10 10",
    "0 1 2 3 4 5 6 7 8 9"
];

solve(input1);
solve(input2);
solve(input3);