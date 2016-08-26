function MaximalSequence(params) {
    var length, i,
        currentSequence = 1,
        maxSequence = currentSequence,
        numbers = (params + "").split("\n");

    for (i = 1, length = numbers.length; i < length; i += 1) {
        if (numbers[i - 1] === numbers[i]) {
            currentSequence += 1;
            if (currentSequence > maxSequence) {
                maxSequence = currentSequence;
            }
        } else {
            currentSequence = 1;
        }
    }

    console.log(maxSequence);
}

//MaximalSequence('13\n4\n1\n1\n4\n2\n3\n4\n4\n4\n2\n4\n9\n3');