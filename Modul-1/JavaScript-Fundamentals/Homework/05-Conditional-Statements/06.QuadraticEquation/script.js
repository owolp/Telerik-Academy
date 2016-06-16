/* globals console*/
"use strict";

function QuadraticEquation(params) {

    var a = +params[0];
    var b = +params[1];
    var c = +params[2];

    var discriminant = Math.pow(b, 2) - (4 * a * c);
    var x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
    var x2 = (-b - Math.sqrt(discriminant)) / (2 * a);

    if (discriminant > 0) {
        var smaller = Math.min(x1, x2);
        var greater = Math.max(x1, x2);
        console.log("x1=" + smaller.toFixed(2) + "; x2=" + greater.toFixed(2));
    } else if (discriminant === 0) {
        console.log("x1=x2=" + x1.toFixed(2));
    } else {
        console.log("no real roots");
    }
}