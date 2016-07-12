function task2(input) {
    'use strict';

    String.prototype.replaceAt = function (index, char) {
        var a = this.split("");
        a[index] = char;
        return a.join("");
    }

    var i,
        j,
        arr = [];

    for (i = 0; i < input.length; i += 1) {
        arr[i] = input[i];
    }

    for (i = 0; i < input.length; i += 1) {
        for (j = 0; j < input[i].length; j += 1) {
            if ((input[i - 1] !== undefined) &&
                (input[i + 1] !== undefined) &&
                (input[i - 1][j] !== undefined) &&
                (input[i + 1][j] !== undefined) &&
                (input[i][j - 1] !== undefined) &&
                (input[i][j + 1] !== undefined) &&
                (input[i][j] !== undefined) &&
                (input[i][j].toLowerCase() === input[i - 1][j].toLowerCase()) &&
                (input[i][j].toLowerCase() === input[i + 1][j].toLowerCase()) &&
                (input[i][j].toLowerCase() === input[i][j - 1].toLowerCase()) &&
                (input[i][j].toLowerCase() === input[i][j + 1].toLowerCase())) {
                arr[i] = arr[i].replaceAt(j, ' ');
                arr[i - 1] = arr[i - 1].replaceAt(j, ' ');
                arr[i + 1] = arr[i + 1].replaceAt(j, ' ');
                arr[i] = arr[i].replaceAt(j - 1, ' ');
                arr[i] = arr[i].replaceAt(j + 1, ' ');
            }
        }
    }

    for (i = 0; i < input.length; i += 1) {
        console.log(arr[i].split(' ').join(''));
    }
}

(function test() {
    'use strict';

    var input = [
        '@s@a@p@una',
        'p@@@@@@@@dna',
        '@6@t@*@*ego',
        'vdig*****ne6',
        'li??^*^*',
    ];

    task2(input);

})()
