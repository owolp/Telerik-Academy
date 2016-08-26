function solve(params) {
    'use strict';

    var rowsAndCols, rows, cols, row, col, moves, nextMoves, result,
        currentPoints = 0,
        sum = 0,
        jumps = 0,
        horseMoves = [],
        usedCells = [];

    function getRowsAndCols(params) {
        return params[0].split(" ").map(Number);
    }

    rowsAndCols = getRowsAndCols(params);
    rows = rowsAndCols[0];
    cols = rowsAndCols[1];
    params = params.slice(1);
    // console.log(rows + " " + cols);

    function getPoints(row, col) {
        return Math.pow(2, row) - col;
    }
    // console.log(getPoints(2,4));

    function getMoves(params, row, col) {
        result = params[row][col];
        return result - 1;
    }
    // console.log(getMoves(params, 2, 1));

    horseMoves = [
        [-2, 1],
        [-1, 2],
        [1, 2],
        [2, 1],
        [2, -1],
        [1, -2],
        [-1, -2],
        [-2, -1]
    ];

    row = rows - 1;
    col = cols - 1;

    while (true) {
        if (row >= rows || row < 0 || col >= cols || col < 0) {
            console.log("Go go Horsy! Collected " + sum + " weeds");
            return;
        }

        if (usedCells[row + " " + col]) {
            console.log("Sadly the horse is doomed in " + jumps + " jumps");
            return;
        }

        currentPoints = getPoints(row, col);
        sum += currentPoints;

        usedCells[row + " " + col] = true;

        moves = getMoves(params, row, col);
        nextMoves = horseMoves[moves];
        row += nextMoves[0];
        col += nextMoves[1];

        jumps += 1;
    }
}

var input1 = [
    '3 5',
    '54561',
    '43328',
    '52388',
];

var input2 = [
    '3 5',
    '54361',
    '43326',
    '52188',
];

solve(input1);
solve(input2);
//console.log(solve(input1) == "Go go Horsy! Collected 1 weeds");
//console.log(solve(input2) == "Sadly the horse is doomed in 7 jumps");