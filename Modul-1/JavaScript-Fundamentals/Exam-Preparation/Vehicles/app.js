'use strict';

function solve(input) {
    var carWheels, truckWheels, trikeWheels, i , j, k, iLength, kLength, jLength;
    var count = 0;
    var totalAmountOfWheels = parseInt(input);

    carWheels = 4;
    truckWheels = 10;
    trikeWheels = 3;

    iLength = (totalAmountOfWheels / truckWheels) + 1;
    jLength = (totalAmountOfWheels / carWheels) + 1;
    kLength = (totalAmountOfWheels / trikeWheels) + 1;

    for (i = 0; i < iLength; i += 1) {
        for (j = 0; j < jLength; j += 1) {
            for (k = 0; k < kLength; k += 1) {
                var temp = i * truckWheels + j * carWheels + k * trikeWheels;

                if (temp === totalAmountOfWheels) {
                    count += 1;
                }
            }
        }
    }

    return count;
}

var input1 = 7;

var input2 = 10;

var input3 = 40;

console.log(solve(input1) == 1);
console.log(solve(input2) == 2);
console.log(solve(input3) == 11);