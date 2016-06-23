function MaximalIncreasingSequence(params) {
    var i, length, currentNumber,
        currentSequence = 1,
        maxSequence = 0,
        numbers = (params + "").split("\n").map(Number),
        previousNumber = numbers[0];

    for (i = 1, length = numbers.length; i < length; i += 1) {
        currentNumber = numbers[i];
        if (previousNumber < currentNumber) {
            currentSequence += 1;
        } else {
            if (currentSequence > maxSequence) {
                maxSequence = currentSequence;
            }
            currentSequence = 1;
        }
        previousNumber = currentNumber;
    }

    if (currentSequence > 1) {
        if (currentSequence > maxSequence) {
            maxSequence = currentSequence;
        }
    }

    console.log(maxSequence);
}

MaximalIncreasingSequence('8\n7\n3\n2\n3\n4\n2\n2\n4');