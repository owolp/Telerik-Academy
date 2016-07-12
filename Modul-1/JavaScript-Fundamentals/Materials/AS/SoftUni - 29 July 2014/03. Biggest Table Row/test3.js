function task3(input) {
    'use strict';

    var i,
        j,
        values = [],
        outValues = [],
        data,
        maxSum = Number.MIN_VALUE,
        maxIndex = -1,
        sum;

    for (i = 2; i < input.length - 1; i += 1) {
        values.push(input[i].split(/<td>|<\/td>/g));
    }

    for (i = 0; i < values.length; i += 1) {
        data = [];
        if (values[i][3] !== '-' || values[i][5] !== '-' || values[i][7] !== '-') {
            if (values[i][3] !== '-') {
                data.push(values[i][3]);
            }
            if (values[i][5] !== '-') {
                data.push(values[i][5]);
            }
            if (values[i][7] !== '-') {
                data.push(values[i][7]);
            }
            outValues.push(data);
        }
    }

    if (outValues.length === 0) {
        console.log('no data');
    } else {
        for (i = 0; i < outValues.length; i += 1) {
            sum = 0;
            for (j = 0; j < outValues[i].length; j += 1) {
                sum += parseFloat(outValues[i][j], 10);
            }

            if (sum > maxSum) {
                maxSum = sum;
                maxIndex = i;
            }
        }

        console.log(maxSum + ' = ' + outValues[maxIndex].join(' + '));
    }
}

(function test() {
    'use strict';

    var input = [
        '<table>',
        '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
        '<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
        '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
        '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
        '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
        '</table>'
    ];

    task3(input);

})()

