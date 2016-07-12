function solve(params) {
    'use strict';

    var directions = params[0].split(', '),
        i,
        matrix = [],
        steps = [],
        x = 0,
        y = 0,
        hits = 0,
        carrots = 0,
        cabbage = 0,
        lettuce = 0,
        turnip = 0,
        tempStr,
        visitedCells = [];

    for (i = 0; i < params.length - 1; i += 1) {
        matrix[i] = params[i + 1].split(', ');
    }

    for (i = 0; i < directions.length; i += 1) {
        switch (directions[i]) {
        case 'up':
            x -= 1;
            break;
        case 'down':
            x += 1;
            break;
        case 'left':
            y -= 1;
            break;
        case 'right':
            y += 1;
            break;
        default:
            break;
        }

        if (x < 0) {
            x = 0;
            hits += 1;
        } else if (y < 0) {
            y = 0;
            hits += 1;
        } else if (x >= matrix.length - 1) {
            x = matrix.length - 1;
            hits += 1;
        } else if (y >= matrix[0].length - 1) {
            y = matrix[0].length - 1;
            hits += 1;
        } else {
            var tempStr = matrix[x][y];

            if (tempStr.indexOf('{!}') > -1) carrots += 1;
            if (tempStr.indexOf('{*}') > -1) cabbage += 1;
            if (tempStr.indexOf('{&}') > -1) lettuce += 1;
            if (tempStr.indexOf('{#}') > -1) turnip += 1;

            tempStr = tempStr.replace('{!}', '@');
            tempStr = tempStr.replace('{*}', '@');
            tempStr = tempStr.replace('{&}', '@');
            tempStr = tempStr.replace('{#}', '@');

            if (steps.indexOf(tempStr) <= -1) {
                steps.push(tempStr);
            }
        }
    }

    console.log('{"&":' + lettuce + ',"*":' + cabbage + ',"#":' + turnip + ',"!":' + carrots + ',"wall hits":' + hits + '}');
    if (steps.length === 0) {
        console.log('no');
    } else {
        console.log(steps.join('|'));
    }
}

(function test1() {
    'use strict';
    var res = solve(['right, up, up, down',
        'asdf, as{#}aj{g}dasd, kjldk{}fdffd, jdflk{#}jdfj',
        'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip',
        'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne']);

    //console.log('gold : ' + Math.floor(res / 100) % 10);
    //console.log('silver : ' + Math.floor(res / 10) % 10);
    //console.log('bronze : ' + res % 10);

})()

