'use strict'

function sumOfNumbers(numbers) {
	let i, length, currentNumber,
		sum = 0;

	if (!numbers.length) {
		return null;
	} else {}

	for (i = 0, length = numbers.length; i < length; i += 1) {
		currentNumber = +numbers[i];

		if (currentNumber) {
			sum += currentNumber;
		} else {
			throw new Error();
		}
	}

	return sum;
}

module.exports = sumOfNumbers;