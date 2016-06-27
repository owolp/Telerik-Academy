function solve(input) {
    var i, j, k, length, maxSum,
        currentSum = 0;

    input = input.slice(1).map(Number);

    maxSum = input[0];

    length = input.length;
    for (i = 0; i < length; i += 1) {
        for (j = i; j < length; j += 1) {
            for (k = i; k <= j; k += 1) {
                currentSum += input[k];
            }

            if (currentSum > maxSum) {
                maxSum = currentSum;
            }

            currentSum = 0;
        }
    }

    console.log(maxSum);
}

input = [
    8, 1, 6, -9, 4, 4, -2, 10, -1
];

input2 = [
    6, 1, 3, -5, 8, 7, -6
];

input3 = [
    9, -9, -8, -8, -7, -6, -5, -1, -7, -6
];

//solve(input);
//solve(input2);
//solve(input3);