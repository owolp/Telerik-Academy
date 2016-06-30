function solve(args) {
    var input = args.map(Number),
        step = 4,
        array = [],
        length = input.length;

    function distance(index) {
        var arr = input;

        var a = Math.abs(arr[index] - arr[index + 2]);
        var b = Math.abs(arr[index + 1] - arr[index + 3]);

        return Math.sqrt((a * a) + (b * b));
    }

    for (var i = 0; i < length; i += step) {
        array.push(+distance(i));
    }

    var output;
    if (array[0] + array[1] > array[2] && array[1] + array[2] > array[0] && array[0] + array[2] > array[1]) {
        output = 'Triangle can be built';
    } else {
        output = 'Triangle can not be built';
    }

    console.log(array.map(Number).map(
            function(a) {
                return a.toFixed(2)
            })
        .join('\n'));
    console.log(output);
}