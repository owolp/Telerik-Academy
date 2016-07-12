function Solve(params) {
    'use strict';

    var sizes = params[0].split(' ').map(Number),
        position = params[1].split(' ').map(Number),
        array = params.splice(2).map(String),
        visited = [],
        sum,
        steps = 1;

    sum = getCellValue(position[0], position[1]);

    function getCellValue(x, y) {
        'use strict';

        var value = (x * sizes[1]) + y + 1;
        visited[value] = true;

        return value;
    }


    while (true) {
        switch (array[position[0]][position[1]]) {
            case 'l':
                position[1] -= 1;
                break;
            case 'r':
                position[1] += 1;
                break;
            case 'u':
                position[0] -= 1;
                break;
            case 'd':
                position[0] += 1;
                break;
            default:
                break;
        }

        if (position[0] < 0 || position[1] < 0 || position[0] >= sizes[0] || position[1] >= sizes[1]) {
            return 'out ' + sum;
        } else if (visited[(position[0] * sizes[1]) + position[1] + 1] == true) {
            return 'lost ' + steps;
        } else {
            sum += getCellValue(position[0], position[1]);
            steps += 1;
        }
    }

}

(function test() {
    var res = Solve([ "5 8",
        "0 0",
        "rrrrrrrd",
        "rludulrd",
        "durlddud",
        "urrrldud",
        "ulllllll"]


    );
    console.log(res);
})()/**
 * Created by Atanas on 5/24/2015.
 */
