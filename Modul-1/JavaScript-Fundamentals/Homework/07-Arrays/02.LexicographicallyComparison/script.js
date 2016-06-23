function LexicoComparison(params) {
    var i, shorterlength, length,
        charArray = (params + "").split("\n"),
        firstArray = charArray[0].split(""),
        lengthFirstArray = firstArray.length;
    secondArray = charArray[1].split("");
    lengthSecondArray = secondArray.length;

    length = Math.min(lengthFirstArray, lengthSecondArray);

    if (lengthFirstArray > lengthSecondArray) {
        shorterlength = lengthSecondArray;
    } else {
        shorterlength = lengthFirstArray;
    }
    for (i = 0; i < shorterlength; i++) {
        if (firstArray[i] > secondArray[i]) {
            console.log(">");
            return;
        } else if (firstArray[i] < secondArray[i]) {
            console.log("<");
            return;
        }
    }
    if (lengthFirstArray > lengthSecondArray) {
        console.log(">");
    } else if (lengthFirstArray < lengthSecondArray) {
        console.log("<");
    } else {
        console.log("=");
    }
}

//LexicoComparison("\"hello\"\n\"halo\"");