function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]),
        knightMoves = [[-2, 1], [-1, 2], [1, 2], [2, 1],
            [2, -1], [1, -2], [-1, -2], [-2, -1]],
        i,
        move,
        board1 = params.slice(2, rows + 2);

        var board = [];

        board1.forEach(function(item) {
            board.push(item.split(''));
        });



    function convertRow(r) {
        return rows - r;
    }
    function convertCol(c) {
        return c.charCodeAt() - 97;
    }

    function checkQueenMove(cell1, cell2) {      
        var x1 = convertRow(cell1[1]),
            y1 = convertCol(cell1[0]),
            x2 = convertRow(cell2[1]),
            y2 = convertCol(cell2[0]),
            res = 'no';

        for (var m = 0; m < 100; m += 1) {

            if (x1 === x2 + m && y1 === y2 + m) {
                res = 'yes';
                break;
            } else if (x1 === x2 + m && y1 === y2 - m) {
                res = 'yes';
                break;
            } else if (x1 === x2 - m && y1 === y2 + m) {
                res = 'yes';
                break;
            } else if (x1 === x2 - m && y1 === y2 - m) {
                res = 'yes';
                break;
            } else if (x1 === x2 && y1 === y2 + m) {
                res = 'yes';
                break;
            } else if (x1 === x2 && y1 === y2 - m) {
                res = 'yes';
                break;
            } else if (y1 === y2 && x1 === x2 + m) {
                res = 'yes';
                break;
            } else if (y1 === y2 && x1 === x2 - m) {
                res = 'yes';
                break;
            }

        }

        // check path
        if (res === 'yes') {
            var deltax = x2 - x1;
            var deltay = y2 - y1;

            if (deltax > 0) {
                deltax = 1;
            } else if (deltax < 0) {
                deltax = -1;
            }

            if (deltay > 0) {
                deltay = 1;
            } else if (deltay < 0) {
                deltay = -1;
            }


            do {
                x1 += deltax;
                y1 += deltay;

                if (board[x1][y1] !== '-') {
                    res = 'no';
                    return res;
                }
            } while ((x1 !== x2 || y1 !== y2));

        }

        return res;
    }

    function checkKnightMove(cell1, cell2) {
        var x1 = convertRow(cell1[1]),
            y1 = convertCol(cell1[0]),
            x2 = convertRow(cell2[1]),
            y2 = convertCol(cell2[0]),
            res = 'no',
            temp = '';


        knightMoves.forEach(function(item) {
           if (x1 === (item[0] + x2) && y1 === (item[1] + y2)) {
                res = 'yes';
               temp = item;
           }
        });

        return res;
    }


    for (i = rows + 3; i < tests + rows + 3; i += 1) {
        var move1 = params[i].split(' ')[0];
        var move2 = params[i].split(' ')[1];
        var result = '';

        if (board[convertRow(move1[1])][convertCol(move1[0])] == '-') {
            result = 'no';
        } else if (board[convertRow(move2[1])][convertCol(move2[0])] != '-') {
            result = 'no';
        } else if (board[convertRow(move1[1])][convertCol(move1[0])] == 'K') {
            result = checkKnightMove(move1, move2);
        } else if (board[convertRow(move1[1])][convertCol(move1[0])] == 'Q') {
            result = checkQueenMove(move1, move2);
        }

        console.log(result);
    }
}

solve(
    [
        '5',
        '5',
        'Q---Q',
        '-----',
        '-K---',
        '--K--',
        'Q---Q',
        '10',
        'a1 a1',
        'a1 d4',
        'e1 b4',
        'a5 d2',
        'e5 b2',
        'b3 d4',
        'b3 c1',
        'b3 d1',
        'c2 a3',
        'c2 b4'
    ]
)

