/* globals console*/
"use strict";

function PrimeCheck(number) {
    var count = 0;

    if (0 <= number && number <= 100) {
        for (var i = 1; i <= 100; i += 1) {
            if (number % i === 0) {
                count += 1;
            }
        }
    }

    if (count === 2) {
        console.log("true");
    }
    else {
        console.log("false");
    }
}