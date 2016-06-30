function solve(args) {
    var i,
        n = +args[0],
        numbers = args[1].split(' '),
        x = +args[2],
        count = 0,
        length = numbers.length;

    for (i = 0; i < length; i += 1) {
        if (+numbers[i] === x) {
            count += 1;
        }
    }

    console.log(count);
}

//solve("8\n\"28 6 21 6 -7856 73 73 -56\"\n73");