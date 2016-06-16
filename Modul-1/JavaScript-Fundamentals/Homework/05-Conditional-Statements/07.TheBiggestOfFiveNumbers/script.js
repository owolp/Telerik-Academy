/* globals console*/
"use strict";

function TheBiggestOfFiveNumbers(params) {

    var firstNumber = +params[0];
    var secondNumber = +params[1];
    var thirdNumber = +params[2];
    var fourthNumber = +params[3];
    var fifthNumber = +params[4];

    var biggestNumber;

    if ((firstNumber > secondNumber) && (firstNumber > thirdNumber) && (firstNumber > fourthNumber) && (firstNumber > fifthNumber)) {
        biggestNumber = firstNumber;
    } else if ((secondNumber > firstNumber) && (secondNumber > thirdNumber) && (secondNumber > fourthNumber) && (secondNumber > fifthNumber)) {
        biggestNumber = secondNumber;
    } else if ((thirdNumber > firstNumber) && (thirdNumber > secondNumber) && (thirdNumber > fourthNumber) && (thirdNumber > fifthNumber)) {
        biggestNumber = thirdNumber;
    } else if ((fourthNumber > firstNumber) && (fourthNumber > secondNumber) && (fourthNumber > thirdNumber) && (fourthNumber > fifthNumber)) {
        biggestNumber = fourthNumber;
    } else {
        biggestNumber = fifthNumber;
    }

    console.log(biggestNumber);
}