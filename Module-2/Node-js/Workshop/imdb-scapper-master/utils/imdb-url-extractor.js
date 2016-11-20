/* globals require module */

"use strict";

const constants = require("./../config/constants");

//  /title/tt0067992/?ref_=adv_li_tt
function extractImdbIdFromUrl(url) {
	let index = url.indexOf(constants.stringAfterMovieId);
	return url.substring(constants.stringBeforeMovieId.length, index);
}

module.exports.extractImdbIdFromUrl = extractImdbIdFromUrl;