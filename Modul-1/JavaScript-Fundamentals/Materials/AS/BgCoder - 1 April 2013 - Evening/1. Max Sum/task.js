function Solve(params) {
    'use strict';
    var i,
        j,
        k,
        sum = 0,
        maxsum = params[1],
        N = parseInt(params[0]);

    var numbers = [];
    for (i = 1; i <= N; i++) {
        numbers[i] = parseInt(params[i]);
    }

    for (i = 1; i < N + 1; i += 1) {
        for (j = i; j < N + 1; j += 1) {
            for (k = i; k <= j; k += 1) {
                sum += numbers[k];
            }

            maxsum = Math.max(sum, maxsum);
            sum = 0;
        }
    }

    return maxsum;
}

(function test() {
    var res = Solve([6,1,3,-5,8,7,-6]);
    console.log(res);
})()