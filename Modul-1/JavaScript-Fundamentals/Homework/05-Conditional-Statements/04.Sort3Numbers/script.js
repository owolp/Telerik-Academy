/* globals console*/
"use strict";

function SortThreeNumbers(params) {

    var a = +params[0];
    var b = +params[1];
    var c = +params[2];

    if (a > b) {
        if (a > c) {
            if (b > c) {
                console.log(a, b, c);
            } else // c > b
            {
                console.log(a, c, b);
            }
        } else // a < c
        {
            console.log(c, a, b);
        }
    } else // a < b
    {
        if (b > c) {
            if (a > c) {
                console.log(b, a, c);
            } else // c > a
            {
                console.log(b, c, a);
            }
        } else // c > b
        {
            console.log(c, b, a);
        }
    }
}