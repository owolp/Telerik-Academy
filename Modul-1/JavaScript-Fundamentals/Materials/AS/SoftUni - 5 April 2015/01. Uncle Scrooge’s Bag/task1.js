function Solve(params) {
    'use strict';

    function isInt(n) {
        return (n % 1 === 0) && n > 0;
    }

    var i,
        result = 0,
        value;

    for (i = 0; i < params.length; i += 1) {
        value = params[i].split(' ');

        if (value[0].toLowerCase() === 'coin' && isInt(value[1])) {
            result += parseInt(value[1], 10);
        }
    }

    console.log('gold : ' + Math.floor(result / 100));
    console.log('silver : ' + Math.floor(result / 10) % 10);
    console.log('bronze : ' + Math.floor(result % 10));
}

(function test1() {
    'use strict';
    var res = Solve(['coin 1', 'COIN 1001', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100', 'coin 200', 'coin 500', 'cigars 1']);

})()
