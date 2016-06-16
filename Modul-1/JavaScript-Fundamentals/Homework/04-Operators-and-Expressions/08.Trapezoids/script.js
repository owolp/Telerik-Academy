/* globals console*/
"use strict";

function Trapezoids(params) {
    var a = +params[0];
    var b = +params[1];
    var h = +params[2];

    var area = h * ((a + b) / 2);

    console.log(area.toFixed(7));
}