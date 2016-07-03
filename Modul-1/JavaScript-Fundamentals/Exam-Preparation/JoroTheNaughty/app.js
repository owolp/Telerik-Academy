// 80/100

function solve(params) {
    var input1, rows, cols, currentJumps, nmj, position, row, col, currentPoints, nextPosition, jumps,
        i, temp,
        sum = 0,
        totalJumps = 0,
        usedCells = [],
        matrix = [];

    function getArguments(params) {
        return params[0].split(" ").map(Number);
    }

    function getPoints(row, col, cols) {
        return row * cols + 1 + col;
    }

    function inRange(position, range) {
        return 0 <= position && position < range;
    }

    nmj = getArguments(params);
    rows = nmj[0];
    cols = nmj[1];
    jumps = nmj[2];
    currentJumps = 0;
    params = params.slice(1);

    position = getArguments(params);
    row = position[0];
    col = position[1];
    params = params.slice(1);

    for (i = 0; i < jumps; i += 1) {
        temp = params[i].split(" ").map(Number);
        matrix.push(temp);
    }

    while (true) {
        if (!(inRange(row, rows)) || !(inRange(col, cols))) {
            console.log("escaped " + sum);
            return;
        }

        if (usedCells[row + " " + col]) {
            console.log("caught " + totalJumps);
            return;
        }

        currentPoints = getPoints(row, col, cols);
        sum += currentPoints;

        usedCells[row + " " + col] = true;

        // if (currentJumps === jumps) {
        //     currentJumps = 0;
        // }
        nextPosition = matrix[currentJumps];
        row += nextPosition[0];
        col += nextPosition[1];

        totalJumps += 1;
        currentJumps += 1;
        currentJumps %= jumps;
    }
}