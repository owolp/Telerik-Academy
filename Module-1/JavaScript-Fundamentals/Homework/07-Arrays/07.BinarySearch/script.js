function BinarySearch(params) {
    var i, middle,
        numbers = (params + "").split("\n").map(Number),
        length = numbers.length,
        element = numbers.splice(length - 1, 1),
        position = -1,
        start = 0,
        end = length - 2;

    numbers.shift();

    while (start <= end) {
        middle = ((start + end) / 2) | 0;

        if (element > numbers[middle]) {
            start = middle + 1;
        } else if (element < numbers[middle]) {
            end = middle - 1;
        } else // x = middle
        {
            position = middle;
            break;
        }
    }

    console.log(position);
}

BinarySearch("10\n1\n2\n4\n8\n16\n31\n32\n64\n77\n99\n32");