function solve(params) {
    var nk = params[0].split(' ').map(Number),
        s = params[1].split(' ').map(Number),
        p = [],
        answer,
        result;

    Array.prototype.copy = function () {
        var copiedArray = [];

        for(var i = 0; i < this.length; i++) {
            copiedArray.push(this[i]);
        }

        return copiedArray;
    };

    for(var j = 0; j < nk[1]; j++) {
        for(var i = 0, len = nk[0]; i < len; i++) {
            var currentNumber = s[i],
                previousNumber = s[i - 1],
                nextNumber = s[i + 1];
            if(i === 0) {
                previousNumber = s[len - 1];
            } else if(i === len - 1) {
                nextNumber = s[0];
            }

            if(currentNumber === 0) {
                result = Math.abs(previousNumber -  nextNumber);
            } else if(currentNumber !== 0 && currentNumber % 2 === 0) {
                result = Math.max(previousNumber, nextNumber);
            } else if(currentNumber === 1) {
                result = previousNumber + nextNumber;
            } else if(currentNumber !== 1 && currentNumber % 2 === 1) {
                result = Math.min(previousNumber, nextNumber);
            }

            p.push(result);
        }

        s = p.copy();
        p = [];
    }

    answer = s.reduce(function (s, item) {
        return s + item;
    }, 0);

    return answer;
}
console.log(solve(
    ["5 1", "9 0 2 4 1"]
));

console.log('----------------------------');

console.log(solve(
    ["10 3", "1 9 1 9 1 9 1 9 1 9"]
));

console.log('----------------------------');

console.log(solve(
    ["10 10", "0 1 2 3 4 5 6 7 8 9"]
));