function solve(args) {
    var arrayLength = +args[0],
        array = args[1].split(' ').map(Number);

    var sortedArray = array.sort(calculate);

    function calculate(a, b) {
        return a - b;
    }

    return sortedArray.join(' ');
}

//solve("6\n36 10 1 34 28 38 31 27 30 20");