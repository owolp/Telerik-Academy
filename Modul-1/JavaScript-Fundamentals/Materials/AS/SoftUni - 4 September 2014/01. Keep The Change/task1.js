function task1(input) {
    'use strict';

    var bill = parseFloat(input[0]),
        mood = input[1],
        result,
        n;

    switch (mood) {
    case 'happy':
        result = (bill * 10 / 100).toFixed(2);
        break;
    case 'married':
        result = (bill * 5 / 10000).toFixed(2);
        break;
    case 'drunk':
        n = (bill * 15 / 100).toString()[0];
        result = Math.pow(bill * 15 / 100, n).toFixed(2);
        break;
    default:
        result = (bill * 5 / 100).toFixed(2);
        break;
    }

    console.log(result);
}

(function test1() {
    'use strict';
    task1([
        '716.00',
        'married'
    ]);
})();
