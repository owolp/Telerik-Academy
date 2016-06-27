'use strict';

function solve(input) {
    var i, length, min, max, temp;
    var n = parseInt(input[0]),
        k = parseInt(input[1]),
        numbersAsString = input[2],
        index = 0;
    var result = [];
    var numbers = (numbersAsString + "").split(" ").map(Number);

    length = numbers.length;

    while(true) {
        if (index + k > length) {
            break;
        }
        min = numbers[index];
        max = numbers[index];

        for (i = index; i < index + k; i += 1) {
            if (min > numbers[i]) {
                min = numbers[i];
            }

            if (max < numbers[i]) {
                max = numbers[i];
            }
        }

        temp = min + max;

        result.push(temp);
        index += 1;
    }

    return result.join(",");
}

var input1 = [
    [4],
    [2],
    ["1 3 1 8"]
];

var input2 = [
    [5],
    [3],
    ["7 7 8 9 10"]

];

var input3 = [
    [8],
    [4],
    ["1 8 8 4 2 9 8 11"]
];

console.log(solve(input1) == "4,4,9");
console.log(solve(input2) == "15,16,18");
console.log(solve(input3) == "9,10,11,11,13");