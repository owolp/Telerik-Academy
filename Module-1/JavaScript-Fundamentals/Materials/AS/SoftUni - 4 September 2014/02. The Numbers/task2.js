function task2(input) {
    'use strict';

    function decimalToHex(d, padding) {
        var hex = Number(d).toString(16);
        padding = typeof (padding) === "undefined" || padding === null ? padding = 2 : padding;

        while (hex.length < padding) {
            hex = "0" + hex;
        }

        return hex;
    }

    var numbers = input[0].match(/(\d+)/g).map(Number),
        i,
        result = [];

    for (i = 0; i < numbers.length; i += 1) {
        result.push('0x' + decimalToHex(numbers[i], 4).toUpperCase());
    }

    console.log(result.join('-'));

}

(function test2() {
    'use strict';
    task2([
        '5tffwj(//*7837xzc2---34rlxXP%$”.'
    ]);
})();
