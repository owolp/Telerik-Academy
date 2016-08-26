/* globals console*/
"use strict";

function ExchangeIfGreater(params) {
    var a = params[0];
    var b = params[1];

    if (a > b) {
        var c = a;
        a = b;
        b = c;
    }

    console.log(a + " " + b);
}