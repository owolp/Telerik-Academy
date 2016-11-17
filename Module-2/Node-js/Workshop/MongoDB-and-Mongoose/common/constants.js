/* globals module */

module.exports = {
    emailRegex: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
	phoneNumberRegex: /[0-9 ]/,
	upperAndLowerCaseRegex: /[a-zA-Z]+/,
	englishLettersRegex: /^[a-zA-Z]+$/,
	upperCaseRegex: /[A-Z]/,
	insuranceNumberRegex: /[a-zA-Z0-9_.-]*$/,
	connectionString: "mongodb://localhost/TelerikFriends"
};