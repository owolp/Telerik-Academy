function Solve(params) {
    var number, appereanceCount,
        numbers = [],
        input = (params + "").split("\n");

    number = input.pop() | 0;
    input = input.slice(1, 2);

    numbers = (input + "").split(" ").map(Number);

    appereanceCount = AppereanceCount(numbers, number);
    console.log(appereanceCount);

    function AppereanceCount(numbers, number) {
        var i, length,
            count = 0;

        for (i = 0, length = numbers.length; i < length; i += 1) {
            if (numbers[i] === number) {
                count += 1;
            }
        }

        return count;
    }
}

//Solve("8\n\"28 6 21 6 -7856 73 73 -56\"\n73");