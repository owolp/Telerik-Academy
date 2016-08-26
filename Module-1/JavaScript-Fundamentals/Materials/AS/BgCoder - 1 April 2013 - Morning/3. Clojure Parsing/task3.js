function solve(params) {
    'use strict';

    var i,
        data = {},
        d,
        d2;

    function xIndexOf(Val, Str, x) {
        if (x <= (Str.split(Val).length - 1)) {
            Ot = Str.indexOf(Val);
            if (x > 1) { for (var m = 1; m < x; m++) { var Ot = Str.indexOf(Val, Ot + 1) } }
            return Ot;
        } else { alert(Val + " Occurs less than " + x + " times"); return 0 }
    }

    function calculateExpression(exp) {
        var values = exp.split(' '),
            result;

        for (d = 1; d < values.length; d += 1) {
            for (d2 in data) {
                if (values[d] === d2) {
                    values[d] = data[d2];
                }
            }
        }

        switch (values[0]) {
            case '+':
                result = parseInt(values[1]);
                for (d = 2; d < values.length; d += 1) result += parseInt(values[d]);
                break;
            case '-':
                result = parseInt(values[1]);
                for (d = 2; d < values.length; d += 1) result -= values[d];
                break;
            case '*':
                result = parseInt(values[1]);
                for (d = 2; d < values.length; d += 1) result *= values[d];
                break;
            case '/':
                result = parseInt(values[1]);
                for (d = 2; d < values.length; d += 1) {
                    if (values[d] === '0') {
                        return undefined;
                    }
                    Math.floor(result /= values[d]);
                }
                break;
            default:
                break;
        }

        return Math.floor(result);
    }
    // Normalize input
    for (i = 0; i < params.length; i += 1) {
        params[i] = params[i].trim();
        params[i] = params[i].replace(/\s\s+/g, ' ');
        params[i] = params[i].replace(/\(\s/g, '(');
        params[i] = params[i].replace(/\)\s/g, ')');
        params[i] = params[i].replace(/\s\(/g, '(');
        params[i] = params[i].replace(/\s\)/g, ')');
    }

    for (i = 0; i < params.length; i += 1) {
        // if starts with def
        if (params[i].indexOf('(def') === 0) {
            // only definition
            if ((params[i].indexOf('+') <= 0) &&
                (params[i].indexOf('-') <= 0) &&
                (params[i].indexOf('*') <= 0) &&
                (params[i].indexOf('/') <= 0)) {
                if (isNaN(params[i].split(/\(|\)| /)[3])) {
                    data[params[i].split(/\(|\)| /)[2]] = data[params[i].split(/\(|\)| /)[3]];
                } else {
                    data[params[i].split(/\(|\)| /)[2]] = params[i].split(/\(|\)| /)[3];
                }
            } else {
                data[params[i].split(/\(|\)| /)[2]] =
                    calculateExpression(params[i].substring(xIndexOf('(', params[i], 2) + 1, xIndexOf(')', params[i], 1)));
                if (data[params[i].split(/\(|\)| /)[2]] === undefined) {
                    return 'Division by zero! At Line:' + (i + 1);
                }
            }
        } else {
            var res = calculateExpression(params[i].substring(1, params[i].length - 1));
            if (typeof res === 'undefined') {
                return 'Division by zero! At Line:' + (i + 1);
            } else {
                return res;
            }
        }
    }

    return '';
}

(function test() {
    console.log(solve([
        '(def     go6o    (/ -7 1 1 1 1) )',
        '(def asd (/ 0 5))',
        '(def func2 asd  )',
        '(           +        4          2      func2)'
    ]));
})()