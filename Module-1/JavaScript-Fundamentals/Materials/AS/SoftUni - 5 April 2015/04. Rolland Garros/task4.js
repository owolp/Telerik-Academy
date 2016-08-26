function Solve(params) {
    'use strict';

    var i,
        j,
        player1,
        player2,
        players = [],
        games,
        setsWin,
        setsLost;

    function Player(name, matchesWon, matchesLost, setsWon, setsLost, gamesWon, gamesLost) {
        'use strict';
        if (!this instanceof Player) {
            return new Player(name, matchesWon, matchesLost, setsWon, setsLost, gamesWon, gamesLost);
        }

        this.name = name;
        this.matchesWon = matchesWon;
        this.matchesLost = matchesLost;
        this.setsWon = setsWon;
        this.setsLost = setsLost;
        this.gamesWon = gamesWon;
        this.gamesLost = gamesLost;
    }

    function hasName(name1) {
        for (var cnt = 0; cnt < players.length; cnt +=1) {
            if (players[cnt].name === name1) {
                return true;
            }
        }
        return false;
    }

    function getIndex(name2) {
        for (var cnt = 0; cnt < players.length; cnt +=1) {
            if (players[cnt].name === name2) {
                return cnt;
            }
        }
        return -1;
    }

    function compare(b, a) {
        if (a.matchesWon > b.matchesWon ) {
            return 1;
        } else if (a.matchesWon < b.matchesWon ) {
            return -1;
        } else {
            if (a.setsWon > b.setsWon ) {
                return 1;
            } else if (a.setsWon < b.setsWon ) {
                return -1;
            } else {
                if (a.gamesWon  > b.gamesWon ) {
                    return 1;
                } else if (a.gamesWon < b.gamesWon ) {
                    return -1;
                } else {
                    return b.name.localeCompare(a.name);
                }
            }
        }

        return 0;
    }

    for (i = 0; i < params.length; i += 1) {
        player1 = params[i].split(':')[0].split('vs.')[0].replace(/\s\s+/g, ' ').trim();
        player2 = params[i].split(':')[0].split('vs.')[1].replace(/\s\s+/g, ' ').trim();

        if (!hasName(player1)) (players.push(new Player(player1, 0, 0, 0, 0, 0, 0)));
        if (!hasName(player2)) (players.push(new Player(player2, 0, 0, 0, 0, 0, 0)));
    }

    for (i = 0; i < params.length; i += 1) {
        player1 = params[i].split(':')[0].split('vs.')[0].replace(/\s\s+/g, ' ').trim();
        player2 = params[i].split(':')[0].split('vs.')[1].replace(/\s\s+/g, ' ').trim();
        games = params[i].split(':')[1].replace(/\s\s+/g, ' ').trim().split(' ');

        if (!hasName(player1)) (players.push(new Player(player1, 0, 0, 0, 0, 0, 0)));
        if (!hasName(player2)) (players.push(new Player(player2, 0, 0, 0, 0, 0, 0)));

        setsWin = 0;
        setsLost = 0;

        for (j = 0; j < games.length; j += 1) {
            players[getIndex(player1)].gamesWon += parseInt(games[j].split('-')[0]);
            players[getIndex(player1)].gamesLost += parseInt(games[j].split('-')[1]);
            players[getIndex(player2)].gamesWon += parseInt(games[j].split('-')[1]);
            players[getIndex(player2)].gamesLost += parseInt(games[j].split('-')[0]);

            if (parseInt(games[j].split('-')[0]) > parseInt(games[j].split('-')[1])) {
                players[getIndex(player1)].setsWon += 1;
                players[getIndex(player2)].setsLost += 1;
                setsWin += 1;
            } else {
                players[getIndex(player2)].setsWon += 1;
                players[getIndex(player1)].setsLost += 1;
                setsLost += 1;
            }
        }

        if (setsWin > setsLost) {
            players[getIndex(player1)].matchesWon += 1;
            players[getIndex(player2)].matchesLost += 1;
        } else {
            players[getIndex(player2)].matchesWon += 1;
            players[getIndex(player1)].matchesLost += 1;
        }
    }

    players.sort(compare);
    console.log(JSON.stringify(players));
}

(function test4() {
    'use strict';
    var res = Solve([
        'Novak Djokovic vs. Roger Federer : 6-3 6-3',
        'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
        'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
        'Andy Murray vs. David     Ferrer : 6-4 7-6',
        'Tomas   Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
        'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
        'Pete Sampras vs. Andre Agassi : 2-1',
        'Boris Beckervs.Andre        Agassi:2-1'
    ]);

})()
