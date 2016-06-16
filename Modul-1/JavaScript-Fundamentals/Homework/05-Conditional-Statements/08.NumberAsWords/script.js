/* globals console*/
"use strict";

function NumberAsWords(numberToParse) {

    var hundreds = Math.floor(parseInt(numberToParse) / 100);
    var tens = Math.floor((parseInt(numberToParse) % 100) / 10);
    var ones = Math.floor(parseInt(numberToParse) % 10);

    var numberWithWords = "";

    var words0 = ["one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine "];
    var words1 = ["ten ", "eleven ", "twelve ", "thirteen ", "fourteen ", "fifteen ", "sixteen ", "seventeen ", "eighteen ", "nineteen "];
    var words2 = ["", "twenty ", "thirty ", "forty ", "fifty ", "sixty ", "seventy ", "eighty ", "ninety "];

    if (parseInt(numberToParse) === 0) {
        console.log("Zero");
        return;
    }
    if (hundreds > 0) {
        numberWithWords += words0[hundreds - 1] + "hundred ";
    }
    if (tens > 1) {
        if (hundreds > 0) {
            numberWithWords += "and ";
        }
        numberWithWords += words2[tens - 1];
        if (ones > 0) {
            numberWithWords += words0[ones - 1];
        }
    } else if (tens === 1) {
        if (hundreds > 0) {
            numberWithWords += "and ";
        }
        numberWithWords += words1[ones];
    } else {
        if (hundreds > 0) {
            if (ones > 0) {
                numberWithWords += "and " + words0[ones - 1];
            }
        } else {
            if (numberToParse === 0) {
                numberWithWords += "zero";
            } else {
                numberWithWords += words0[ones - 1];
            }
        }
    }

    function CapitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    console.log(CapitalizeFirstLetter(numberWithWords));
}

NumberAsWords("0");