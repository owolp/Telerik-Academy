function Solve(params) {
    'use strict';

    var data = params[0].split(' ').map(Number),
        N = data[0],
        M = data[1],
        J = data[2],
        position = params[1].split(' ').map(Number),
        j = 0,
        visited = [],
        jumps = 0,
        sum = 0;

    sum += position[0] * M + position[1] + 1;
    jumps += 1;
    visited[position[0] * M + position[1] + 1] = true;

    while (true) {
        position[0] += parseInt(params[2 + j].split(' ')[0], 10);
        position[1] += parseInt(params[2 + j].split(' ')[1], 10);
        jumps += 1;

        if (position[0] < 0 || position[1] < 0 || position[0] >= N || position[1] >= M) {
            return ('escaped ' + sum);
        }

        if (visited[position[0] * M + position[1] + 1] === true) {
            return ('caught ' + jumps);
        }

        sum += position[0] * M + position[1] + 1;
        visited[position[0] * M + position[1] + 1] = true;

        if (j < J - 1) {
            j += 1;
        } else {
            j = 0;
        }
    }
}