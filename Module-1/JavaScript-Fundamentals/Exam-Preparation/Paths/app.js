'use strict';

function solve(params) {
    var input1, input2, input3, rowsAndCols, rows, cols, row, col,
        sum, points, moves, index, nextMoves,
        usedCells = [],
        pathMoves = [],
        matrix = [];

    function getRowsAndCols(params) {
        return params[0].split(" ").map(Number);
    }

    rowsAndCols = getRowsAndCols(params);
    rows = rowsAndCols[0];
    cols = rowsAndCols[1];
    params = params.slice(1);

    function getPoints(row, col) {
        return Math.pow(2, row) + col;
    }

    function getMoves(matrix, row, col) {
        return matrix[row][col];
    }

    pathMoves = [
        [1, 1], // dr
        [-1, 1], // ur
        [-1, -1], // ul
        [1, -1] // dl
    ];


    matrix = params.map(function(line) {
        return line.split(" ");
    });
    row = 0;
    col = 0;
    sum = 0;
    while (true) {
        if (row >= rows || row < 0 || col >= cols || col < 0) {
            console.log("successed with " + sum);
            return;
        }

        if (usedCells[row + " " + col]) {
            console.log("failed at (" + row + ", " + col + ")");
            return;
        }

        points = getPoints(row, col);
        sum += points;

        usedCells[row + " " + col] = true;

        moves = getMoves(matrix, row, col);

        switch (moves) {
            case "dr":
                index = 0;
                break;
            case "ur":
                index = 1;
                break;
            case "ul":
                index = 2;
                break;
            case "dl":
                index = 3;
                break;
        }

        nextMoves = pathMoves[index];
        row += nextMoves[0];
        col += nextMoves[1];
    }
}

var input1 = [
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
];

var input2 = [
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
];

solve(input1);
solve(input2);