'use strict';

function solve(params) {
    var n = parseInt(params[0]),
        k = parseInt(params[1]),
        numbersAsString = params[2],
        result = [];

    var numbers = numbersAsString.split(" ").map(Number);
    var index = 0;
    while (true) {
        if (index + k > numbers.length) {
            break;
        }
        
        var minEl = numbers[index];
        var maxEl = numbers[index];
        for (var i = index + 1; i < index + k; i += 1) {
            if (numbers[i] < minEl) {
                minEl = numbers[i];
            }
            
            if (numbers[i] > maxEl) {
                maxEl = numbers[i];
            }
        }
        var sum = minEl + maxEl;
        result.push(sum);
        index += 1;
    }

    return result.join(",");
}


var input1 = [
    4, 2, "1 3 1 8"
];

var input2 = [
    5, 3, "7 7 8 9 10"
];

var input3 = [
    8, 4, "1 8 8 4 2 9 8 11"
];

console.log(solve(input1) == "4,4,9");
console.log(solve(input2) == "15,16,18");
console.log(solve(input3) == "9,10,11,11,13");