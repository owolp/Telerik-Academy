function solve(input) {
    var totalMoney, firstCakePrice, secondCakePrice, thirdCakePrice, i, j, k, currentAmmount,
        iLength, jLenght, kLength,
        maxAmount = 0;

    input = input.map(Number);

    totalMoney = input[0];
    firstCakePrice = input[1];
    secondCakePrice = input[2];
    thirdCakePrice = input[3];

    iLength = (totalMoney / firstCakePrice);
    jLength = (totalMoney / secondCakePrice);
    kLength = (totalMoney / thirdCakePrice);

    // iLength = (totalMoney / firstCakePrice) + 1;
    // jLength = (totalMoney / secondCakePrice) + 1;
    // kLength = (totalMoney / thirdCakePrice) + 1;

    for (i = 0; i < iLength; i += 1) {
        for (j = 0; j < jLength; j += 1) {
            for (k = 0; k < kLength; k += 1) {
                currentAmmount = firstCakePrice * i + secondCakePrice * j + thirdCakePrice * k;

                if (currentAmmount > maxAmount && currentAmmount <= totalMoney) {
                    maxAmount = currentAmmount;
                }
            }
        }
    }

    return (maxAmount);
}

input1 = [
    110,
    13,
    15,
    17
];

input2 = [
    20,
    11,
    200,
    300
];

input3 = [
    110,
    19,
    29,
    39
];

console.log(solve(input1) == 110);
console.log(solve(input2) == 11);
console.log(solve(input3) == 107);