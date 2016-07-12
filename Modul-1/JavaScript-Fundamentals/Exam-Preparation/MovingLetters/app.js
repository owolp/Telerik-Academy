'use strict';

function solve(input) {
    var words = input.split(" ").map(String);

    var maxLength = GetMaxLength(words);
    var extractedLetters = ExtractLetters(words, maxLength);
    var movedLetters = MoveLetters(extractedLetters);
    return movedLetters;

    function GetMaxLength(words) {
        var longestLength = 0;
        for (var i = 0; i < words.length; i += 1) {
            if (words[i].length > longestLength) {
                longestLength = words[i].length;
            }
        }
        return longestLength;
    }

    // Implement MoveLetters
    // https://github.com/TelerikAcademy/JavaScript-Fundamentals/blob/master/Topics/13.%20Exam%20preparation/2016-Workshop/Magic%20Words/magic-words.js


    // function MoveLetters(extractedLetters) {
    //     for (var i = 0; i < extractedLetters.length; i += 1) {
    //         var currentDigit = extractedLetters[i];
    //         var moveIndex = ascii(currentDigit);

    //         if(moveIndex > extractedLetters.length) {
    //             moveIndex %= extractedLetters.length;
    //         }
    //         extractedLetters = extractedLetters.substr(0, i) + extractedLetters.substr(i + 1);
    //         extractedLetters = extractedLetters.substr(0, moveIndex) + currentDigit + extractedLetters.substr(moveIndex);
    //     }

        return extractedLetters;
    }

    function ascii (a) {
        return a.charCodeAt(0) - "a".charCodeAt(0) + 1;
    }

    function ExtractLetters(words, longestLength) {
        var text = "";
        for (var i = 0; i < longestLength; i += 1) {
            for (var j = 0; j < words.length; j += 1) {
                var currentWord = words[j];
                if (currentWord.length > i) {
                    var currentDigit = currentWord[currentWord.length - 1 - i];
                    text += currentDigit;
                }
            }
        }
        return text;
    }
}

var input1 = "Fun exam right";

var input2 = "Telerik Academy";

var input3 = "Hi exam";

console.log(solve(input1));
console.log(solve(input2) == "AymlTiedkaerec");
console.log(solve(input3) == "maiHex");