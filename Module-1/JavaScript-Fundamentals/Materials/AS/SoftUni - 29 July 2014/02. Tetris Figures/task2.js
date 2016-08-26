function task2(input) {
    'use strict';

    var output = {
            I: 0,
            L: 0,
            J: 0,
            O: 0,
            Z: 0,
            S: 0,
            T: 0
        },
        x,
        y;

    for (x = 0; x < input.length; x += 1) {
        for (y = 0; y < input[0].length; y += 1) {
            // I
            if (input[x] !== undefined &&
                    input[x + 1] !== undefined &&
                    input[x + 2] !== undefined &&
                    input[x + 3] !== undefined &&
                    input[x][y] === 'o' &&
                    input[x + 1][y] === 'o' &&
                    input[x + 2][y] === 'o' &&
                    input[x + 3][y] === 'o') {
                output.I += 1;
            }
            // L
            if (input[x] !== undefined &&
                input[x + 1] !== undefined &&
                input[x + 2] !== undefined &&
                input[x][y + 1] !== undefined &&
                input[x][y] === 'o' &&
                input[x + 1][y] === 'o' &&
                input[x + 2][y] === 'o' &&
                input[x + 2][y + 1] === 'o') {
                output.L += 1;
            }
            // J
            if (input[x] !== undefined &&
                input[x + 1] !== undefined &&
                input[x + 2] !== undefined &&
                input[x][y - 1] !== undefined &&
                input[x][y] === 'o' &&
                input[x + 1][y] === 'o' &&
                input[x + 2][y] === 'o' &&
                input[x + 2][y - 1] === 'o') {
                output.J += 1;
            }
            // O
            if (input[x] !== undefined &&
                input[x + 1] !== undefined &&
                input[x][y + 1] !== undefined &&
                input[x][y] === 'o' &&
                input[x + 1][y] === 'o' &&
                input[x][y + 1] === 'o' &&
                input[x + 1][y + 1] === 'o') {
                output.O += 1;
            }
            // Z
            if (input[x] !== undefined &&
                input[x + 1] !== undefined &&
                input[x][y + 1] !== undefined &&
                input[x][y + 2] !== undefined &&
                input[x][y] === 'o' &&
                input[x][y + 1] === 'o' &&
                input[x + 1][y + 1] === 'o' &&
                input[x + 1][y + 2] === 'o') {
                output.Z += 1;
            }
            // S
            if (input[x] !== undefined &&
                input[x - 1] !== undefined &&
                input[x][y + 1] !== undefined &&
                input[x][y + 2] !== undefined &&
                input[x][y] === 'o' &&
                input[x][y + 1] === 'o' &&
                input[x - 1][y + 1] === 'o' &&
                input[x - 1][y + 2] === 'o') {
                output.S += 1;
            }
            // T
            if (input[x] !== undefined &&
                input[x + 1] !== undefined &&
                input[x][y + 1] !== undefined &&
                input[x][y + 2] !== undefined &&
                input[x][y] === 'o' &&
                input[x][y + 1] === 'o' &&
                input[x][y + 2] === 'o' &&
                input[x + 1][y + 1] === 'o') {
                output.T += 1;
            }
        }
    }

    console.log(JSON.stringify(output));
}

(function test() {
    'use strict';

    var input = [
        '--o--o-',
        '--oo-oo',
        'ooo-oo-',
        '-ooooo-',
        '---oo--'
    ];

    task2(input);

})()
