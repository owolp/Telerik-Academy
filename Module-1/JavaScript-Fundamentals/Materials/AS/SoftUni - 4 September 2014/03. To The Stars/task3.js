function task3(input) {
    'use strict';

    var i,
        j,
        line,
        x = input[3].split(' ').map(Number)[0],
        y = input[3].split(' ').map(Number)[1],
        data = [],
        found;

    for (i = 0; i < 3; i += 1) {
        line = input[i].split(' ');
        data[i] = {
            name: line[0],
            x: line[1] - 0,
            y: line[2] - 0
        };
    }

    for (i = -1; i < input[4]; i += 1) {
        found = false;
        for (j = 0; j < data.length; j += 1) {
            if (x >= data[j].x - 1 && x <= data[j].x + 1 && y >= data[j].y - 1 && y <= data[j].y + 1) {
                console.log(data[j].name.toLowerCase());
                found = true;
                break;
            }
        }

        if (!found) {
            console.log('space');
        }
        y += 1;
    }
}

(function test2() {
    'use strict';
    task3([
        'Terra-Nova 16 2',
        'Perseus 2.6 4.8',
        'Virgo 1.6 7',
        '2 5',
        '4'

    ]);
})();
