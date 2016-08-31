'use strict'

function findPrimes(startNumber, endNumber) {
	let primeNumbers = [];

	if (isNaN(startNumber) || isNaN(endNumber)) {
		throw new Error();
	} else {}

	startNumber = +startNumber;
	endNumber = +endNumber;

	for (let number = startNumber; number <= endNumber; number += 1) {
		let isNumberPrime = isPrime(number);

		if (isNumberPrime) {
			primeNumbers.push(number);
		}
	}

	function isPrime(number) {
		for (let i = 2; i <= number; i += 1) {
			if (number % i === 0 && number != i) {
				return false;
			}
		}
		return number > 1;
	}

	return primeNumbers;
}

module.exports = findPrimes;