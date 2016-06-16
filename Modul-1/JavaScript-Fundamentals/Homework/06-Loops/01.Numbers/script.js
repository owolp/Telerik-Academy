/* globals console*/
"use strict";

function NumbersFrom1ToN(params) {
    var number = parseInt(params);

    var result = "";
    for (var i = 1; i <= number; i += 1) {
        result += i + " ";
    }

    console.log(result.trim());
}