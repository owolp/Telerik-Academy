/* globals console*/
"use strict";

function ThirdDigit(number) {
    var thirdDigit = ((number / 100) % 10) | 0;

    if (thirdDigit === 7) {
        console.log("true");
    }
    else {
        console.log("false " + thirdDigit);
    }
}