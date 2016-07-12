function solve(params) {
    'use strict';

    var jumps = parseInt(params[0], 10),
        len = parseInt(params[1], 10),
        i,
        j,
        players = {},
        player,
        winner,
        str1 = '',
        str2 = '',
        playerStr = '',
        end = false;

    for (i = 2; i < params.length; i += 1) {
        players[params[i].split(',')[0].trim()] = [parseInt(params[i].split(',')[1].trim()), 0];
        winner = params[i].split(',')[0].trim();
    }

    for (i = 0; i < jumps && end === false; i += 1) {
        for (player in players) {
            if (players.hasOwnProperty(player)) {
                if (players[player][1] + players[player][0] < len - 1) {
                    players[player][1] += players[player][0];
                } else {
                    players[player][1] = len - 1;
                    winner = player;
                    end = true;
                    break;
                }
            }
        }
        winner = player;
    }

    for (i = 0; i < len; i += 1) {
        str1 += '#';
        str2 += '.';
    }

    for (i = 0; i < 2; i += 1) {
        console.log(str1);
    }

    for (player in players) {
        if (players.hasOwnProperty(player)) {
            playerStr = str2;
            playerStr = str2.substr(0, players[player][1]) + player[0].toUpperCase() + str2.substr(players[player][1] + 1);
            console.log(playerStr);
        }
    }

    for (i = 0; i < 2; i += 1) {
        console.log(str1);
    }

    console.log('Winner: ' + winner);
}

(function test2() {
    'use strict';
    var res = solve([3,
        5,
        'cura, 1',
        'Pepi, 1',
        'UlTraFlea, 1',
        'BOIKO, 1',

    ]);

    //console.log('gold : ' + Math.floor(res / 100) % 10);
    //console.log('silver : ' + Math.floor(res / 10) % 10);
    //console.log('bronze : ' + res % 10);

})()
