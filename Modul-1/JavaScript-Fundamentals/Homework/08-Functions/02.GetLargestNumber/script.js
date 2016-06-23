function Solve(params) {
    var max,
        numbers = (params + "").split(" ").map(Number),
        a = numbers[0],
        b = numbers[1],
        c = numbers[2];

    max = GetMax(a, GetMax(b, c));

    console.log(max);

    function GetMax(firstDigit, secondDigit) {
        var a = firstDigit | 0,
            b = secondDigit | 0;

        if (a > b) {
            return a;
        } else {
            return b;
        }
    }
}

//Solve("7 19 19");