function solve(input) {
    'use strict';

    function getLeadingZeros(value) {
        var cnt = 0;
        while (value[cnt] === ' ') cnt += 1;
        return cnt;
    }

    function addLeadingZeros(value, zeros) {
        'use strict';
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
                value = value.slice( 1 );;
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
        var res;
        return input.slice( 0, idx ).concat( arr ).concat( input.slice( idx ) );
    }

    // Extract defines
    for (i = 0; i < parseInt(input[0], 10); i += 1) {
        data[input[i + 1].split(':')[0]] = input[i + 1].split(':')[1];
    }

    start = 1 + parseInt(input[0], 10);

    // Extract @sections
    for (i = parseInt(input[0], 10); i < input.length; i += 1) {
        if (input[i].indexOf('@section ') >= 0) {
            section = input[i].split(' ')[1];
            data[section] = [];
            i += 1;
            while (input[i] !== '}' && (typeof input[i] !== 'number')) {
                data[section].push(input[i]);
                i += 1;
                start = i;
            }
        }
    }

    // Parse data
    for (i = start + 1; i < input.length; i += 1) {
        if (input[i].indexOf('@@if') >= 0 || input[i].indexOf('@@foreach') >= 0) {
            displayBracket = true;
        }

        // @@
        if (input[i].indexOf('@@') >= 0) {
            result.push(input[i].replace('@@', '@'));
        // section
        } else if (input[i].indexOf('@renderSection') >= 0 && input[i].indexOf('("') >= 0 && input[i].indexOf('")') >= 0) {
            zeros = getLeadingZeros(input[i]);
            result.push(addLeadingZeros(data[input[i].split('"')[1]], zeros).join('\n'));
        // if
        } else if (input[i].indexOf('@if') >= 0  && input[i].indexOf('(') >= 0 && input[i].indexOf(')') >= 0 && input[i].indexOf('{') >= 0) {
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
                while (input[i].indexOf('}') < 0) i += 1;
            }

            if (isTrue == true) {
                zeros = getLeadingZeros(input[i]);
                zeros2 = getLeadingZeros(input[i + 1]);
                j = i;
                while (input[j].indexOf('}') < 0) {
                    input[j] = addLeadingZeros(input[j], zeros - zeros2);
                    j += 1;
                }
            }

            // foreach
        } else if (input[i].indexOf('@foreach') >= 0 && input[i].indexOf('(') >= 0 && input[i].indexOf(')') >= 0 && input[i].indexOf('{') >= 0) {
            var arr,
                dd,
                found = false;

            for (var d in data) {
                if (input[i].indexOf(d) >= 0) {
                    arr = data[d].split(',');
                    found = true;
                    break;
                }
            }

            if (found) {
                dd = input[i].split('var ')[1].split(' ')[0];

                zeros = getLeadingZeros(input[i]);
                zeros2 = getLeadingZeros(input[i + 1]);
                fdata = [];

                for (var el in arr) {
                    j = i + 1;
                    while (input[j].indexOf('}') < 0) {
                        fdata.push(addLeadingZeros(input[j], zeros - zeros2).replace('@' + dd, arr[el]))
                        j += 1;
                    }
                }

                while (input[i].indexOf('}') < 0) i += 1;

                input = injectArray(i, fdata);
                i -= 1;
            }
        } else if (input[i].indexOf('@') >= 0) {
            var ddd = input[i];
            for (var d in data) {
                if (input[i].indexOf(d) >= 0) {
                    ddd = ddd.replace('@' + d, data[d]);
                }
            }
            result.push(ddd);
        } else if (input[i].indexOf('}') < 0) {
            result.push(input[i]);
        } else if (input[i].indexOf('}') >= 0 && displayBracket) {
            result.push(input[i]);
            displayBracket = false;
        }
    }

    for (i = 0; i < result.length; i += 1) {
        console.log(result[i]);
    }
}

(function test() {
    'use strict';

    var input = [
        '15',
        'text:RandomText',
        'anotherText:RandomTextAgain',
        'passTheIf:true',
        'doNotPassTheIf:false',
        'passTheIf:true',
        'doNotPassTheIf:false',
        'pesho:na peshlqka modela',
        'gosho:i gosho e tuka brato',
        'someNumbers:1,2,3,4,5',
        'someTechs:asp.net,mvc,angular,node,c-sharp',
        'someNumbersHere:1,2,3,4,5',
        'someTechsHere:asp.net,mvc,angular,node,c-sharp',
        'kolio:nikolay',
        'minkov:donchoviq',
        'unused:just unused model',
        '106',
        '@section first {',
        '<ul>',
        '    <li>',
        '        In section UL',
        '    </li>',
        '    <li>',
        '        Still in section UL',
        '    </li>',
        '</ul>',
        '}',
        '@section second {',
        '<div>',
        '    Second section :)',
        '</div>',
        '}',
        '<div>',
        '    <p>',
        '    @@if (pesho) {',
        '        @@escaped dude',
        '    }',
        '    </p>',
        '    <p>',
        '    @@renderSection("pesho")',
        '    </p>',
        '    <p>',
        '    @@foreach(var pesho in peshos) {',
        '        @@escaped in comment',
        '    }',
        '    </p>',
        '</div>',
        '<div>',
        '    @renderSection("first")',
        '    @renderSection("second")',
        '</div>',
        '<div>',
        '    <div>',
        '        @text',
        '    </div>',
        '    <ul>',
        '        <li>',
        '             <span>@anotherText</span>',
        '        </li>',
        '    </ul>',
        '</div>',
        '<div>',
        '    <p>Some bulsh*t text</p>',
        '    <br />',
        '    @if (passTheIf) {',
        '        <span>Passed</span>',
        '    }',
        '    <br />',
        '    <div>',
        '        <span>More bulsh*t text</span>',
        '        @if (doNotPassTheIf) {',
        '            <span>if this passes this is error</span>',
        '        }',
        '    <div>',
        '</div>',
        '<div>',
        '    <p>Some bulsh*t text + @pesho & @gosho</p>',
        '    <br />',
        '    @if (passTheIf) {',
        '        <span>Passed @pesho and @gosho</span>',
        '    }',
        '    <br />',
        '    <div>',
        '        <span>More bulsh*t text</span>',
        '        @if (doNotPassTheIf) {',
        '            <span>if this passes this is error @pesho and @gosho</span>',
        '        }',
        '    <div>',
        '</div>',
        '<div>',
        '    <span>Some bulsh*t text</span>',
        '    <br />',
        '    @foreach (var number in someNumbers) {',
        '        <span>@number da ima</span>',
        '        <span>only @number</span>',
        '    }',
        '    <br />',
        '    <div>',
        '        <span>More bulsh*t text</span>',
        '        @foreach (var tech in someTechs) {',
        '            <span>@tech is cool</span>',
        '            <span>and @tech is mama</span>',
        '        }',
        '    <div>',
        '</div>',
        '<div>',
        '    <span>Some bulsh*t text</span>',
        '    <br />',
        '    @foreach (var someNumber in someNumbersHere) {',
        '        <span>@someNumber da ima</span>',
        '        <span>only @someNumber</span>',
        '        <strong>@kolio</strong>',
        '    }',
        '    <br />',
        '    <div>',
        '        <span>More bulsh*t text</span>',
        '        @foreach (var someTech in someTechsHere) {',
        '            <span>@someTech is cool</span>',
        '            <span>and @someTech is mama</span>',
        '            <strong>@minkov</strong>',
        '        }',
        '    <div>',
        '</div>'
    ];
    solve(input);

})()
