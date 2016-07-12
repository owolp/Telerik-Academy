function task3(input) {
    'use strict';

    var i,
        j,
        k,
        line,
        values,
        obj = {},
        pair1,
        pair2,
        output;

    for (i = 0; i < input.length; i += 1) {
        input[i] = input[i].split('+').join(' ');
        input[i] = input[i].split('%20').join(' ');
        input[i] = input[i].replace(/\s\s+/g, ' ');
        line = input[i].split('?');

        obj = {};

        for (k = 0; k < line.length; k += 1) {
            values = line[k].split('&');

            for (j = 0; j < values.length; j += 1) {
                if (values[j].split('=')[1] !== undefined) {
                    pair1 = values[j].split('=')[0].trim();
                    pair2 = values[j].split('=')[1].trim();
                    if (obj[pair1] === undefined) {
                        obj[pair1] = pair2;
                    } else {
                        obj[pair1] = obj[pair1] + ', ' + pair2;
                    }
                }
            }
        }

        output = '';

        for (pair1 in obj) {
            if (obj.hasOwnProperty(pair1)) {
                output += pair1 + '=[' + obj[pair1] + ']';
            }
        }
        console.log(output);
    }
}

(function test() {
    'use strict';

    var input = [
        'field=value1&field=value2&field=value3',
        'http://example.com/over/there?name=ferret'
    ];

    task3(input);

})()
