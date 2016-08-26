function solve(params) {
    var s = params[0];
    var count = 0;

	var c1 = 4, c2 = 10, c3 = 3;
    for (var count1 = 0; count1 <= (s / c1) + 1; count1++) {
        for (var count2 = 0; count2 <= (s / c2) + 1; count2++) {
            for (var count3 = 0; count3 <= (s / c3) + 1; count3++) {
                var all = (count1 * c1) + (count2 * c2) + (count3 * c3);
                if (all == s) {
					// console.log(count1, count2, count3);
                    count++;
                }
            }
        }
    }

    console.log(count);
}
