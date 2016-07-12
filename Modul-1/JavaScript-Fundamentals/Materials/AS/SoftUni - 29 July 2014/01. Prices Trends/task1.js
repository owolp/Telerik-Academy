function task1(input) {
    'use strict';

    var numbers = input.map(Number),
        i,
        result = '';

    for (i = 0; i < numbers.length; i += 1) {
        numbers[i] = numbers[i].toFixed(2);
    }

    numbers[-1] = numbers[0];

    result += '<table>' + '\n';
    result += '<tr><th>Price</th><th>Trend</th></tr>' + '\n';

    for (i = 0; i < numbers.length; i += 1) {
        if (numbers[i] < numbers[i - 1]) {
            result += '<tr><td>' + numbers[i] + '</td><td><img src="down.png"/></td></tr>\n';
        } else if (numbers[i] > numbers[i - 1]) {
            result += '<tr><td>' + numbers[i] + '</td><td><img src="up.png"/></td></tr>\n';
        } else {
            result += '<tr><td>' + numbers[i] + '</td><td><img src="fixed.png"/></td></tr>\n';
        }
    }

    result += '</table>';

    console.log(result);
}

(function test() {
    'use strict';

    var input = [
        '36.333',
        '36.5',
        '37.019',
        '35.4',
        '35',
        '35.001',
        '36.225'

    ];

    task1(input);

})()
