function Solve(params) {
    'use strict';
    var i,
        result = 1,
        N = parseInt(params[0], 10),
        numbers = [];

    for (i = 1; i <= N; i += 1) {
        numbers[i] = parseInt(params[i], 10);
    }

    for (i = 1; i < N; i += 1) {
        if (numbers[i + 1] < numbers[i]) {
            result += 1;
        }
    }

    return result;
}

(function test() {
    'use strict';
    var res = Solve([9, 1, 8, 8, 7, 6, 5, 7, 7, 6]);

    console.log(res);
})()
