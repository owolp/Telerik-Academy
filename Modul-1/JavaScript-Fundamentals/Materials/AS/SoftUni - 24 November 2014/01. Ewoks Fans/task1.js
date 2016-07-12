function task1(input) {
    'use strict';

    var i,
        date1,
        dates = [],
        pattern = /(\d{2})\.(\d{2})\.(\d{4})/,
        found = false;

    for (i = 0; i < input.length; i += 1) {
        date1 = new Date(input[i].replace(pattern, '$3-$2-$1'));
        if (date1 > new Date('1900-01-01') && date1 < new Date('2015-01-01')) {
            dates.push(date1);
        }
    }

    dates.sort(function (a, b) {
        return b - a;
    });

    if (dates[0] >= new Date('1973-05-25')) {
        console.log('The biggest fan of ewoks was born on ' + dates[0].toDateString());
        found = true;
    }

    if (dates[dates.length - 1] < new Date('1973-05-25')) {
        console.log('The biggest hater of ewoks was born on ' + dates[dates.length - 1].toDateString());
        found = true;
    }

    if (!found) {
        console.log('No result');
    }
}

(function test() {
    'use strict';

    var input = [
        '17.05.1933',
        '22.03.2014',
        '10.10.1954'
    ];

    task1(input);

})()
