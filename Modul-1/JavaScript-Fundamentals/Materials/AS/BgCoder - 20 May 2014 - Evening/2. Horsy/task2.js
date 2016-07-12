function solve(params) {
    'use strict';
    var size = params[0].split(' ').map(Number),
        pos = [size[0] - 1, size[1] - 1],
        visited = {},
        sum = Math.pow(2, pos[0]) - pos[1],
        jumps = 0;


    while (true) {
        jumps += 1;

        switch (params[pos[0] + 1][pos[1]]) {
        case '1':
            pos[0] -= 2;
            pos[1] += 1;
            break;
        case '2':
            pos[0] -= 1;
            pos[1] += 2;
            break;
        case '3':
            pos[0] += 1;
            pos[1] += 2;
            break;
        case '4':
            pos[0] += 2;
            pos[1] += 1;
            break;
        case '5':
            pos[0] += 2;
            pos[1] -= 1;
            break;
        case '6':
            pos[0] += 1;
            pos[1] -= 2;
            break;
        case '7':
            pos[0] -= 1;
            pos[1] -= 2;
            break;
        case '8':
            pos[0] -= 2;
            pos[1] -= 1;
            break;
        default:
            break;
        }

        if (pos[0] < 0 || pos[1] < 0 || pos[0] > size[0] - 1 || pos[1] > size[1] - 1) {
            console.log('Go go Horsy! Collected ' + sum + ' weeds');
            return;
        } else if (visited[pos[0] + ' ' + pos[1]] === true) {
            console.log('Sadly the horse is doomed in ' + jumps + ' jumps');
            return;
        } else {
            sum += Math.pow(2, pos[0]) - pos[1];
            visited[pos[0] + ' ' - pos[1]] = true;
        }
    }

    console.log(sum);
}

(function test() {
    'use strict';
    var args = [
        '3 5',
        '54561',
        '43328',
        '52388',
    ];

    solve(args);
})()
