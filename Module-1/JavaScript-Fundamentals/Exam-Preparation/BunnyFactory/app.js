'use strict';

function solve(input) {
    var params = input[0].split(" ").map(Number);
    var cages = params;
    var i;

    var length = params.length;
    for (var index = 1; index <= length; index += 1) {

        var cycleLength = 0;
        for (var cycle = 0; cycle < index; cycle += 1) {
            cycleLength += cages[cycle];
        }

        if (cycleLength > cages.length) {
            return cages.join(" ");
        }

        var sum = 0;
        var product = 1;
        for (var cage = index; cage < index + cycleLength; cage += 1) {
            sum += cages[cage];
            product *= cages[cage];
        }

        var sumAsString = sum.toString();
        var productAsString = product.toString();

        var temp = sumAsString + productAsString;
        for (i = index + cycleLength; i < cages.length; i += 1) {
            temp += cages[i];
        }

        cages = temp.split("").map(Number);
        for (i = cages.length - 1; i >= 0; i -= 1) {
            if (cages[i] === 0 || cages[i] === 1) {
                cages.splice(i, 1);
            }
        }
    }
}

var input1 = [
    "3 2 5 5 4 8 4 9 5 6 3 4"
];

var input2 = [
    "3 2 3 3 4 5"
];

console.log(solve(input1) == "3 9 3 6 8 4");
console.log(solve(input2) == "8 8 4 5");