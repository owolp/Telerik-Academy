/* globals console*/
"use strict";

function PointInCircleAndOutsideRectangle(params) {
    var x = params[0];
    var y = params[1];
    // Checks for given point(x, y) if it is within the circle K({ 1, 1}, 1.5)
    var xCenter = 1;
    var yCenter = 1;
    var radius = 1.5;

    var distanceCircle = Math.sqrt(Math.pow(x - xCenter, 2) + Math.pow(y - yCenter, 2));
    var insideCircle = Math.abs(distanceCircle) <= radius;

    var pointCircle = "outside circle";
    if (insideCircle)
    {
        pointCircle = "inside circle";
    }

    // checks for given point(x, y) if it is out of the rectangle R(top= 1, left= -1, width= 6, height= 2)
    var xMin = -1;
    var xMax = 5;
    var yMin = -1;
    var yMax = 1;

    var xInside = (xMin <= x) & (x <= xMax);
    var yInside = (yMin <= y) & (y <= yMax);

    var pointRectangle = "outside rectangle";
    if (xInside & yInside)
    {
        pointRectangle = "inside rectangle";
    }

    console.log(pointCircle + " " + pointRectangle);
}