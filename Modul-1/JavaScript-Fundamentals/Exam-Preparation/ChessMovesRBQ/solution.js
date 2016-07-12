function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        numberOfTests = parseInt(params[rows + 2]), i, move, board;

    board = [];

    for(var r = 0; r < rows; r++) {
        var currentRow = params[r + 2].split('');

        board.push([]);

        for(var c = 0; c < cols; c++) {
            var currentChar = currentRow[c];

            if(currentChar === '-') {
                board[r][c] = 0;
            } else if(currentChar === 'R') {
                board[r][c] = 1;
            } else if(currentChar === 'B'){
                board[r][c] = 2;
            } else {
                board[r][c] = 3;
            }
        }
    }

    function checkRook() {
        if(fromR === toR || fromC === toC) {
            //in between
            for(var x = Math.min(fromR, toR); x <= Math.max(fromR, toR); x++) {
                for(var y = Math.min(fromC, toC); y <= Math.max(toC, fromC); y++) {
                    if(board[x][y] !== 0 && !(x === fromR && y === fromC)) {
                        return 'no';
                    }
                }
            }

            return 'yes';
        }

        return 'no';
    }

    function checkBishop() {
        var diff1 = (toR - fromR) < 0 ? -1 : 1;
        var diff2 = (toC - fromC) < 0 ? -1 : 1, x = fromR ,y = fromC;

        if(Math.abs(fromR - toR) === Math.abs(fromC - toC)) {
            //in between
            do {
                if(board[x][y] !== 0 && !(x === fromR && y === fromC)) {
                    return 'no';
                }

                y += diff2;
                x += diff1;
            } while(x !== toR && y !== toC);

            return 'yes';
        }

        return 'no';
    }

    for(i = 0; i < numberOfTests; i++) {
        var currentTest = params[rows + 3 + i].split(' ');
        var from = currentTest[0].split('');
        var to = currentTest[1].split('');

        from[0] = from[0].charCodeAt(0) - 97; // col
        from[1] |= 0; // row
        from[1] -= 1;


        to[0] = to[0].charCodeAt(0) - 97;
        to[1] |= 0;
        to[1] -= 1;

        var fromR = rows - 1 - from[1];
        var fromC = from[0];

        var toR = rows - 1 - to[1];
        var toC = to[0];

        var fromCell = board[fromR][fromC];
        var toCell = board[toR][toC];

        if(fromCell === 0) {
            console.log('no');
            continue;
        } else {
            if(toCell !== 0) {
                console.log('no');
                continue;
            }
            //rook
            if(fromCell === 1) {
                console.log(checkRook());
            }

            // bishop
            else if(fromCell === 2) {
                console.log(checkBishop());
            }

            else {
                if(checkRook() === 'yes' || checkBishop() === 'yes') {
                    console.log('yes');
                } else {
                    console.log('no')
                }
            }
        }

    }
}

// 1 = rook
// 2 = bishop
// 3 = queen
// 0 = vacant

console.log(solve(
    [
"3",
"4",
"--R-",
"B--B",
"Q--Q",
"12",
"d1 b3",
"a1 a3",
"c3 b2",
"a1 c1",
"a1 b2",
"a1 c3",
"a2 b3",
"d2 c1",
"b1 b2",
"c3 b1",
"a2 a3",
"d1 d3"
    ]
));

console.log('----------------------------');

console.log(solve(
    [
        "5",
        "5",
        "Q---Q",
        "-----",
        "-B---",
        "--R--",
        "Q---Q",
        "10",
        "a1 a1",
        "a1 d4",
        "e1 b4",
        "a5 d2",
        "e5 b2",
        "b3 d5",
        "b3 a2",
        "b3 d1",
        "b3 a4",
        "c2 c5"
    ]
));