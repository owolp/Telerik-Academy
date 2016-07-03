'use strict';

function solve(params) {
    var input1, input2, input3, rowsAndCols, rows, cols, row, col, currentPoints,
        position, nextPositionCoordinates,
        usedCells = [],
        sum = 0,
        jumps = 0;

    function getArguments(params) {
        return params[0].split(" ").map(Number);
    }

    function getPoints(row, col, cols) {
        return row * (cols + 1) + col + 1;
    }

    function getMovePosition(params, row, col) {
        return params[row][col];
    }

    rowsAndCols = getArguments(params);
    rows = rowsAndCols[0] - 1;
    cols = rowsAndCols[1] - 1;
    params = params.slice(1);

    position = getArguments(params);
    row = position[0];
    col = position[1];
    params = params.slice(1);

    while (true) {
        if (row > rows || row < 0 || col > cols || col < 0) {
            console.log("out " + sum);
            return;
        }

        if (usedCells[row + " " + col]) {
            console.log("lost " + jumps);
            return;
        }

        currentPoints = getPoints(row, col, cols);
        sum += currentPoints;

        usedCells[row + " " + col] = true;

        nextPositionCoordinates = getMovePosition(params, row, col);

        switch (nextPositionCoordinates) {
            case "l":
                col -= 1;
                break;
            case "r":
                col += 1;
                break;
            case "u":
                row -= 1;
                break;
            case "d":
                row += 1;
                break;
        }

        jumps += 1;
    }
}

var input1 = [
    "3 4",
    "1 3",
    "lrrd",
    "dlll",
    "rddd"
];


var input2 = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"
];

var input3 = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "lurlddud",
    "urrrldud",
    "ulllllll"
];

//console.log(solve(input1) == UPDATEANSWER);
//console.log(solve(input2) == UPDATEANSWER);
//console.log(solve(input3) == UPDATEANSWER);
//solve(input1);
solve(input2);
solve(input3);