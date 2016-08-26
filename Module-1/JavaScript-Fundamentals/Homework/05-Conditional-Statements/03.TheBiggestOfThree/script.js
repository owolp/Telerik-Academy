/* globals console*/
"use strict";

function BiggestOfThree(params) {
    var max = Math.max.apply(Math, params);
    console.log(max);
}