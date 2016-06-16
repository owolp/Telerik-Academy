/* globals console*/
"use strict";

function PointIntCircle(params) {
    var xCoordinate = +params[0];
    var yCoordinate = +params[1];
    var xCenter = 0;
    var yCenter = 0;
    var radius = 2;

    var distance = Math.sqrt(Math.pow(xCoordinate - xCenter, 2) + Math.pow(yCoordinate - yCenter, 2)).toFixed(2);

    if (distance <= radius) {
        console.log("yes " + distance);
    }
    else {
        console.log("no " + distance);
    }
}