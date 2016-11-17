/* globals require module*/

"use strict";

const Fs = require("fs");

function jsonReader(fileName) {
	const content = Fs.readFileSync(`json/${fileName}`, "utf8");
	const object = JSON.parse(content);
	return object;
}

module.exports = jsonReader;