/* globals console*/
"use strict";

function MatrixOfNumbers(params) {
    var length = parseInt(params);

    for (var i = 0; i < length; i += 1) {
        var result = "";
        for (var j = i + 1; j <= i + length; j += 1) {
            result += j + " ";
        }
        console.log(result.trim());
    }
}