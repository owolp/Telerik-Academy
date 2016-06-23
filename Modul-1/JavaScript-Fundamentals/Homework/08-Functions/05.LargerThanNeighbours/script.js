function Solve(params) {
    var isTrue, i, length, previous, current, next,
        counter = 0;
    var input = (params + "").split("\n");
    var numbers = input.slice(1, input.length);

    numbers = (numbers + "").split(" ").map(Number);

    for (i = 1, length = numbers.length; i < length; i += 1) {
        previous = numbers[i - 1];
        current = numbers[i];
        next = numbers[i + 1];

        isTrue = LargerThanNeighbour(previous, current, next);
        
        if(isTrue) {
            counter += 1;
        }
    }

    console.log(counter);

    function LargerThanNeighbour(a, b, c) {
        if (a < b && b > c) {
            return true;
        }
    }
}

//Solve("6\n-26 -25 -28 31 2 27");