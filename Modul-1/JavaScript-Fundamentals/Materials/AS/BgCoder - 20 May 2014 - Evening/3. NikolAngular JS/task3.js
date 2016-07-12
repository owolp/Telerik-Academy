function solve(input) {
    'use strict';

    function getLeadingZeros(value) {
        var cnt = 0;
        while (value[cnt] === ' ') {
            cnt += 1;
        }
        return cnt;
    }

    function addLeadingZeros(value, zeros) {
        var cnt,
            z;

        if (zeros > 0) {
            for (cnt = 0; cnt < value.length; cnt += 1) {
                for (z = 0; z < zeros; z += 1) {
                    value[cnt] = ' ' + value[cnt];
                }
            }
        } else {
            for (z = zeros; z < 0; z += 1) {
                value = value.slice(1);
            }
        }

        //value[value.length - 1].remove('\n');
        return value;
    }

    var i,
        j,
        data = {},
        section,
        start,
        result = [],
        zeros,
        zeros2,
        isTrue,
        fdata = [],
        displayBracket = false;

    function injectArray( idx, arr ) {
        return input.slice( 0, idx ).concat( arr ).concat( input.slice( idx ) );
    }

    // Extract defines
    for (i = 0; i < parseInt(input[0], 10); i += 1) {
        data[input[i + 1].split('-')[0]] = input[i + 1].split('-')[1];
    }

    start = 1 + parseInt(input[0], 10);

    // Extract nk-template
    for (i = parseInt(input[0], 10); i < input.length; i += 1) {
        if (input[i].indexOf('<nk-template name') >= 0) {
            section = input[i].split('"')[1];
            data[section] = [];
            i += 1;
            while (input[i] !== '</nk-template>' && (typeof input[i] !== 'number')) {
                data[section].push(input[i]);
                i += 1;
                start = i;
            }
        }
    }

    // Parse data
    for (i = start + 1; i < input.length; i += 1) {
        // @@
        if (input[i].indexOf('{{') >= 0 && input[i].indexOf('}}') >= 0) {
            result.push(input[i].replace('{{', '').replace('}}', ''));
            // section
        } else if (input[i].indexOf('<nk-template render=') >= 0 && input[i].indexOf('"') >= 0 && input[i].indexOf('/>') >= 0) {
            //zeros = getLeadingZeros(input[i]);
            //result.push(addLeadingZeros(data[input[i].split('"')[1]], zeros).join('\n'));
            result.push((data[input[i].split('"')[1]]).join('\n'));
            // if
        } else if (input[i].indexOf('<nk-if condition="') >= 0  && input[i].indexOf('">') >= 0) {
            for (var d in data) {
                if (input[i].indexOf(d) >= 0 && data[d].indexOf('true') >= 0) {
                    isTrue = true;
                    break;
                }
                if (input[i].indexOf(d) >= 0 && data[d].indexOf('false') >= 0) {
                    isTrue = false;
                    break;
                }
            }

            if (isTrue == false) {
                while (input[i].indexOf('</nk-if>') < 0) i += 1;
            }

            if (isTrue == true) {
                zeros = getLeadingZeros(input[i]);
                zeros2 = getLeadingZeros(input[i + 1]);
                j = i;
                while (input[j].indexOf('</nk-if>') < 0) {
                    input[j] = addLeadingZeros(input[j], zeros - zeros2);
                    j += 1;
                }
            }

            // foreach
        } else if (input[i].indexOf('<nk-repeat for="') >= 0 && input[i].indexOf('">') >= 0) {
            var arr,
                dd,
                found = false;

            for (var d in data) {
                if (input[i].indexOf(d) >= 0) {
                    arr = data[d].split(';');
                    found = true;
                    break;
                }
            }

            if (found) {
                dd = input[i].split('for="')[1].split(' ')[0];

                zeros = getLeadingZeros(input[i]);
                zeros2 = getLeadingZeros(input[i + 1]);
                fdata = [];

                for (var el in arr) {
                    j = i + 1;
                    while (input[j].indexOf('</nk-repeat>') < 0) {
                        fdata.push(addLeadingZeros(input[j], zeros - zeros2).replace('<nk-model>' + dd + '</nk-model>', arr[el]))
                        j += 1;
                    }
                }

                while (input[i].indexOf('</nk-repeat>') < 0) i += 1;

                input = injectArray(i, fdata);
                i -= 1;
            }
        } else if (input[i].indexOf('<nk-model>') >= 0 && input[i].indexOf('</nk-model>') >= 0) {
            var ddd = input[i];
            for (var d in data) {
                if (input[i].indexOf(d) >= 0) {
                    ddd = ddd.replace('<nk-model>' + d, data[d]).replace('</nk-model>', '');
                }
            }
            result.push(ddd);
        } else if (input[i].indexOf('</nk-if>') < 0 && input[i].indexOf('</nk-repeat>') < 0) {
            result.push(input[i]);
        }
    }

    for (i = 0; i < result.length; i += 1) {
        console.log(result[i]);
    }
}

(function test() {
    'use strict';

    var input = [
        '6',
        'title-Telerik Academy',
        'showSubtitle-true',
        'subTitle-Free training',
        'showMarks-false',
        'marks-3;4;5;6',
        'students-Ivan;Gosho;Pesho',
        '42',
        '<nk-template name="menu">',
        '    <ul id="menu">',
        '        <li>Home</li>',
        '        <li>About us</li>',
        '    </ul>',
        '</nk-template>',
        '<nk-template name="footer">',
        '    <footer>',
        '        Copyright Telerik Academy 2014',
        '    </footer>',
        '</nk-template>',
        '<!DOCTYPE html>',
        '<html>',
        '<head>',
        '    <title>Telerik Academy</title>',
        '</head>',
        '<body>',
        '    <nk-template render="menu" />',
        '',
        '    <h1><nk-model>title</nk-model></h1>',
        '    <nk-if condition="showSubtitle">',
        '        <h2><nk-model>subTitle</nk-model></h2>',
        '        <div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
        '    </nk-if>',
        '',
        '    <ul>',
        '        <nk-repeat for="student in students">',
        '            <li>',
        '                <nk-model>student</nk-model>',
        '            </li>',
        '            <li>Multiline <nk-model>title</nk-model></li>',
        '        </nk-repeat>',
        '    </ul>',
        '    <nk-if condition="showMarks">',
        '        <div>',
        '            <nk-model>marks</nk-model> ',
        '        </div>',
        '    </nk-if>',
        '',
        '    <nk-template render="footer" />',
        '</body>',
        '</html>'
    ];
    solve(input);

})()
