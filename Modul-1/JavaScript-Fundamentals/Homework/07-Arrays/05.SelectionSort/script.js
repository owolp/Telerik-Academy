function SelectionSort(params) {
    var i, j, length, temp,
        numbers = (params + "").split("\n").map(Number);
        numbers.splice(0, 1);

    for (i = 0, length = numbers.length; i < length; i += 1) {
        for (j = i + 1; j < length; j += 1) {
            if (numbers[j] < numbers[i]) {
                temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
        }
    }

    console.log(numbers.join("\n"));
}

//SelectionSort("6\n3\n4\n1\n5\n2\n6");