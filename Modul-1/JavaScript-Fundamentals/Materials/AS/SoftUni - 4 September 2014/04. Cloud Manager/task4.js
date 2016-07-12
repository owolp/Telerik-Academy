function task4(input) {
    'use strict';

    function sortObject(o) {
        var sorted = {},
            key,
            a = [];

        for (key in o) {
            if (o.hasOwnProperty(key)) {
                a.push(key);
            }
        }

        a.sort();

        for (key = 0; key < a.length; key++) {
            sorted[a[key]] = o[a[key]];
        }
        return sorted;
    }

    var i,
        line,
        obj = {};

    for (i = 0; i < input.length; i += 1) {
        line = input[i].split(/MB| /);
        if (obj[line[1]] === undefined) {
            obj[line[1]] = {};
            obj[line[1]].files = [];
            obj[line[1]].files.push(line[0]);
            obj[line[1]].memory = parseFloat(line[2]).toFixed(2).toString();
        } else {
            obj[line[1]].files.push(line[0]);
            obj[line[1]].files.sort();
            obj[line[1]].memory = (parseFloat(obj[line[1]].memory) + parseFloat(line[2])).toFixed(2).toString();
        }
    }

    console.log(JSON.stringify(sortObject(obj)));
}

(function test4() {
    'use strict';
    task4([
        'sentinel .exe 15MB',
        'zoomIt .msi 3MB',
        'skype .exe 45MB',
        'trojanStopper .bat 23MB',
        'kindleInstaller .exe 120MB',
        'setup .msi 33.4MB',
        'winBlock .bat 1MB'
    ]);
})();