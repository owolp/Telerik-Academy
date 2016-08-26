/* globals console*/
"use strict";

function MMSA(params) {
    var length = params.length;
    var min = parseFloat(params[0]);
    var max = parseFloat(params[0]);
    var sum = parseFloat(params[0]);
    var average = 0;

    for (var i = 1; i < length; i += 1) {
        var element = parseFloat(params[i]);
        if (element < min) {
            min = element;
        } else if (element > max) {
            max = element;
        }

        sum += element;
    }

    average = sum / length;

    console.log("min=" + min.toFixed(2));
    console.log("max=" + max.toFixed(2));
    console.log("sum=" + sum.toFixed(2));
    console.log("avg=" + average.toFixed(2));
}