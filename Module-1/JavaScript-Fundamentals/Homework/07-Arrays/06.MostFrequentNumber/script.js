function MostFrequentNumber(params) {
    var i, length, currentNumber, previousNumber, maxNumber,
        currentLength = 1,
        maxLength = currentLength,
        numbers = (params + "").split("\n");

    numbers.sort();

    previousNumber = numbers[0];
    for (i = 0, length = numbers.length; i < length; i += 1) {
        currentNumber = numbers[i + 1];

        if (currentNumber === previousNumber) {
            currentLength += 1;
        }
        else {
            currentLength = 1;
        }

        if (currentLength > maxLength) {
            maxLength = currentLength;
            maxNumber = numbers[i];
        }

        previousNumber = currentNumber;
    }

    console.log(maxNumber + " (" + maxLength + " times)");
}

//MostFrequentNumber("13\n4\n1\n1\n4\n2\n3\n4\n4\n1\n2\n4\n9\n3");