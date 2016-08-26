function Solve(params) {
    'use strict';

    var i,
        data = {};

    function sum (array) {
        var i,
            sum = 0;

        for (i = 0; i < array.length; i += 1) {
            sum += array[i];
        }

        return sum;
    }

    function average (array) {
        var i,
            sum = 0;

        for (i = 0; i < array.length; i += 1) {
            sum += array[i];
        }

        return Math.floor(sum / array.length);
    }

    function calculateData(input, operation) {
        var index1 = input.indexOf('['),
            index2 = input.indexOf(']'),
            values = input.substring(index1 + 1, index2).replace(/\s/g, ''),
            arr = values.split(','),
            arr2 = '',
            i;

        for (i = 0; i < arr.length; i += 1) {
            if (isNaN(arr[i])) {
                arr2 += data[arr[i]] + ',';
            } else {
                arr2 += arr[i] + ',';
            }
        }

        arr = arr2.substr(0, arr2.length - 1).replace(/\s/g, '').split(',').map(Number);

        switch (operation) {
            case 'min':
                return Math.min.apply(Math, arr);
            case 'max':
                return Math.max.apply(Math, arr);
            case 'sum':
                return sum(arr);
            case 'avg':
                return average(arr);
            default:
                return "";
        }

    }

    function extractData(input) {
        var index1 = input.indexOf('['),
            index2 = input.indexOf(']'),
            values = input.substring(index1 + 1, index2).replace(/\s/g, ''),
            arr = values.split(','),
            arr2 = '',
            i;

        for (i = 0; i < arr.length; i += 1) {
            if (isNaN(arr[i])) {
                arr2 += data[arr[i]] + ',';
            } else {
                arr2 += arr[i] + ',';
            }
        }

        return arr2.substr(0, arr2.length - 1);
    }

    for (i = 0; i < params.length; i += 1) {
        params[i] = params[i].trim();
        params[i] =  params[i].replace( /\s\s+/g, ' ' );
    }

    for (i = 0; i < params.length; i += 1) {
        // if starts with def
        if (params[i].indexOf('def') === 0) {
            // check command type
            if (params[i].split(/\[| /)[2] === 'sum') {
                // def sum
                data[params[i].split(/\[| /)[1]] = calculateData(params[i], 'sum');
            } else if (params[i].split(/\[| /)[2] === 'min') {
                // def min
                data[params[i].split(/\[| /)[1]] = calculateData(params[i], 'min');
            } else if (params[i].split(/\[| /)[2] === 'max') {
                // def max
                data[params[i].split(/\[| /)[1]] = calculateData(params[i], 'max');
            } else if (params[i].split(/\[| /)[2] === 'avg') {
                // def avg
                data[params[i].split(/\[| /)[1]] = calculateData(params[i], 'avg');
            } else {
                // only def
                data[params[i].split(/\[| /)[1]] = extractData(params[i]);
            }
        } else {
            if (params[i].indexOf('sum') === 0 && i === params.length - 1) {
                return calculateData(params[i], 'sum');
            } else if (params[i].indexOf('min') === 0 && i === params.length - 1) {
                return calculateData(params[i], 'min');
            } else if (params[i].indexOf('max') === 0 && i === params.length - 1) {
                return calculateData(params[i], 'max');
            } else if (params[i].indexOf('avg') === 0 && i === params.length - 1) {
                return calculateData(params[i], 'avg');
            } else if (params[i].indexOf('[') === 0 && i === params.length - 1){
                return data[params[i].replace('[','').replace(']','').replace(' ','')];
            }
        }
    }

    return '';
}

(function test() {
    var res = [];
    res[0] = 'def maxy max[100]';
    res[1] = 'def summary [0]';
    res[2] = 'combo [maxy, maxy,maxy,maxy, 5,6]';
    res[3] = 'summary sum[combo, maxy, -18000]';
    res[4] = 'def pe6o avg[summary,maxy]';
    res[5] = 'sum[7, pe6o]';

    console.log(Solve(res));
})()/**
 * Created by Atanas on 5/24/2015.
 */
