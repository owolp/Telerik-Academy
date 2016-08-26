function solve(params) {
    'use strict';
    var input = params.toString().split(' ').map(Number),
        result = [],
        res = 0,
        j = 0,
        i;

    for (i = 0; i < input.length; i += 1) {
        if (i === 0) {
            if(input[i] > input[i+1]) {
                result[j] = i;
                j += 1;
            }
        } else if (i === input.length - 1) {
            if(input[i] > input[i-1]) {
                result[j] = i;
                j += 1;
            }
        } else {
            if (input[i] > input[i-1] && input[i] > input[i+1]) {
                result[j] = i;
                j += 1;
            }
        }
    }

    for (i = 1; i < result.length; i += 1) {
        res = Math.max(res, result[i] - result[i-1]);
    }

    console.log(res);
}

solve('5 1 7 4 8');
