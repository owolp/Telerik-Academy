/* globals require module console */

"use strict";

const Fs = require("fs");

function jsonWriter(fileName, object) {
	const directoryExists = Fs.existsSync("json");
	if (!directoryExists) {
		Fs.mkdirSync("json", (err) => {
			if (err) {
				console.log(err.message);
			}
		});
	}

	if (object) {
		Fs.writeFileSync(`json/${fileName}.json`, JSON.stringify(object, null, 2));
	}
}

module.exports = jsonWriter;