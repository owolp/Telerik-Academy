function Solve(params) {
    var maxElement,
        orderedArray = [];
    var input = (params + "").split("\n");
    var numbers = input.slice(1, input.length);

    numbers = (numbers + "").split(" ").map(Number);

    while (numbers.length > 0) {
        maxElement = FindMaxElement(numbers);
        Sort();
    }

    console.log(orderedArray.join(" "));

    function Sort() {
        orderedArray.unshift(maxElement);
    }

    function FindMaxElement(numbers) {
        var i, length, maxIndex;
        var maxNumber = numbers[0];

        for (i = 1, length = numbers.length; i < length; i += 1) {
            if (numbers[i] > maxNumber) {
                maxNumber = numbers[i];
                maxIndex = i;
            }
        }

        numbers.splice(maxIndex, 1);
        return maxNumber;
    }
}

//Solve("6\n36 10 1 34 28 38 31 27 30 20");