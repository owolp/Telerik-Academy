function solve(params) {
    'use strict';
    var s = params[0],
        c1 = params[1],
        c2 = params[2],
        c3 = params[3],
        answer = 0;

    for (var count1 = 0; count1 <= (s / c1) + 1; count1++) {
        for (var count2 = 0; count2 <= (s / c2) + 1; count2++) {
            for (var count3 = 0; count3 <= (s / c3) + 1; count3++) {
                var all = (count1 * c1) + (count2 * c2) + (count3 * c3);

                if (all > answer && all <= s) {
                    answer = all;
                }
            }
        }
    }

    console.log(answer);
}

(function test() {
    'use strict';
    var res = solve([110,
        19,
        29,
        39
    ]);
})()
