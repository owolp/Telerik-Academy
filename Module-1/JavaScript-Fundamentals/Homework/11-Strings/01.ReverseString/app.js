function solve(args) {
    let text = args[0],
        reversedAsArray = [];

    for (var i = text.length - 1; i >= 0; i -= 1) {
        reversedAsArray.push(text[i]);
    }

    console.log(reversedAsArray.join(''));
}