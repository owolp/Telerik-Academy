'use strict';

function solve(params) {
    var s = params[0],
        c1 = params[1],
        c2 = params[2],
        c3 = params[3];
    var maxAmount = 0;
    var currentAmmount = 0;
    var iLength = (s / c1) + 1;
    var jLength = (s / c2) + 1;
    var kLength = (s / c3) + 1;

    for (var i = 0; i < iLength; i += 1) {
        for (var j = 0; j < jLength; j += 1) {
            for (var k = 0; k < kLength; k += 1) {
                currentAmmount = i * c1 + j * c2 + k * c3;
                if (currentAmmount <= s && currentAmmount > maxAmount ) {
                    maxAmount = currentAmmount;
                }
            }
        }
    }

    return maxAmount;
}


var input1 = [110, 13, 15, 17];

var input2 = [20, 11, 200, 300];

var input3 = [110, 19, 29, 39];

console.log(solve(input1) == 110);
console.log(solve(input2) == 11);
console.log(solve(input3) == 107);