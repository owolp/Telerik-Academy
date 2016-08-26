'use strict';

function solve(params) {
    var path = params.split(" ").map(Number);
    var length = path.length;
    var indexMolly = 0;
    var indexDolly = length - 1;
    var totalMollyFlowers = 0;
    var totalDollyFlowers = 0;
    var currentFlowersMolly = 0;
    var currentFlowersDolly = 0;
    var positionsToMoveMolly, positionsToMoveDolly;
    var previousMollyPosition, previousDollyPosition;
    var result;

    [].
    

    while (true) {
        if (path[indexMolly] === 0 || path[indexDolly] === 0) {
            if (path[indexMolly] === 0 && path[indexDolly] === 0) {
                result = "Draw";
            } else if (path[indexMolly] === 0) {
                result = "Dolly";
            } else if (path[indexDolly] === 0) {
                result = "Molly";
            }

            totalMollyFlowers += path[indexMolly];
            totalDollyFlowers += path[indexDolly];
            break;
        }

        currentFlowersMolly = path[indexMolly];
        currentFlowersDolly = path[indexDolly];

        if (indexMolly === indexDolly) {
            totalMollyFlowers += Math.floor(path[indexMolly] / 2);
            totalDollyFlowers += Math.floor(path[indexDolly] / 2);
            path[indexMolly] = path[indexMolly] % 2;
        } else {
            totalMollyFlowers += currentFlowersMolly;
            totalDollyFlowers += currentFlowersDolly;

            path[indexMolly] = 0;
            path[indexDolly] = 0;
        }

        indexMolly = mollyPosition(indexMolly, currentFlowersMolly, length);
        indexDolly = dollyPosition(indexDolly, currentFlowersDolly, length);
    }

    console.log(result);
    console.log(totalMollyFlowers + " " + totalDollyFlowers);

    function mollyPosition(currentMollyPosition, currentFlowersMolly, length) {
        return (currentMollyPosition + currentFlowersMolly) % length;
    }

    function dollyPosition(currentDollyPosition, currentFlowersDolly, length) {
        var position = (currentDollyPosition - currentFlowersDolly) % length;
        if (position < 0) {
            position += length;
        } 

        return position;
    }
}

var input1 =
    "1 1 1 1 9000000000000000001 9000000000000000001 9000000000000000001 9000000000000000001";

solve(input1);