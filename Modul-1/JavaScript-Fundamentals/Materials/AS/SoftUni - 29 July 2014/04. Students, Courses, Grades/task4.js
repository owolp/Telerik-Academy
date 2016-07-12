function task4(input) {
    'use strict';

    function sortObject(o) {
        var sorted = {},
            key,
            a = [];

        for (key in o) {
            if (o.hasOwnProperty(key)) {
                a.push(key);
            }
        }

        a.sort();

        for (key = 0; key < a.length; key++) {
            sorted[a[key]] = o[a[key]];
        }
        return sorted;
    }

    var data = [],
        data1 = {},
        i,
        j,
        result = '';

    for (i = 0; i < input.length; i += 1) {
        data.push(input[i].split('|'));
    }

    for (i = 0; i < data.length; i += 1) {
        for (j = 0; j < data[i].length; j += 1) {
            data[i][j] = data[i][j].trim();
        }
    }

    for (i = 0; i < data.length; i += 1) {
        if (!data1.hasOwnProperty(data[i][1])) {
            data1[data[i][1]] = {};
            data1[data[i][1]].avgGrade = [];
            data1[data[i][1]].avgVisits = []
            data1[data[i][1]].students = [];
        }

        data1[data[i][1]].avgGrade.push(data[i][2]);
        data1[data[i][1]].avgVisits.push(data[i][3])
        data1[data[i][1]].students.push(data[i][0]);
    }

    for (i = 0; i < data1.length; i += 1) {
        console.log(data1[i].avgGrade);
        data1[i].avgGrade = Math.average(data1[i].avgGrade.map(Number));
    }
    console.log(JSON.stringify(sortObject(data1)));
}

(function test() {
    'use strict';

    var input = [
        'Peter Nikolov | PHP  | 5.50 | 8',
        'Maria Ivanova | Java | 5.83 | 7',
        'Ivan Petrov   | PHP  | 3.00 | 2',
        'Ivan Petrov   | C#   | 3.00 | 2',
        'Peter Nikolov | C#   | 5.50 | 8',
        'Maria Ivanova | C#   | 5.83 | 7',
        'Ivan Petrov   | C#   | 4.12 | 5',
        'Ivan Petrov   | PHP  | 3.10 | 2',
        'Peter Nikolov | Java | 6.00 | 9'
    ];
    task4(input);

})()
