function solve(input) {
    var length, i,
        answer = 1;

    input = input.map(Number);

    length = input.length;
    for (i = 2; i < length; i += 1) {
        if (input[i] < input[i - 1]) {
            answer += 1;
        }
    }

    console.log(answer);
}

input = [
    7,
    1,
    2,
    -3,
    4,
    4,
    0,
    1
];

input2 = [
    6,
    1,
    3,
    -5,
    8,
    7,
    -6
];

//solve(input);
//solve(input2);