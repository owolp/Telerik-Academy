/* globals console*/
"use strict";

function MultiplicationSign(params) {
    var a = +params[0];
    var b = +params[1];
    var c = +params[2];

    var result;

    if ((a === 0) || (b === 0) || (c === 0))
    {
        result = "0";
    }
    else if ((a < 0) && (b > 0) && (c > 0))
    {
        result = "-";
    }
    else if ((a > 0) && (b < 0) && (c > 0))
    {
        result = "-";
    }
    else if ((a > 0) && (b > 0) && (c < 0))
    {
        result = "-";
    }
    else if ((a < 0) && (b < 0) && (c < 0))
    {
        result = "-";
    }
    else
    {
        result = "+";
    }

    console.log(result);
}