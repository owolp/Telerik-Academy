const validator = (() => {

	function validateString(str, min, max, chars) {
		if (typeof str !== 'string' || str.length < min || str.length > max) {
			return {
				message: `Invalid: Length must be between ${min} and ${max}`
			};
		}
		if (chars) {
			str = str.split('');
			if (str.some(function (char) {
					return chars.indexOf(char) < 0;
				})) {
				return {
					message: `Invalid: Chars can be ${chars}`
				};
			}
		}
	}

	function validateUrl(url) {
		if (!url || url.length === 0) {
			return;
		}

		var pattern = /((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)/;
		if (!pattern.test(url)) {
			return {
				message: 'Invalid url'
			};
		}
	}

	return {
		validateString: validateString,
		validateUrl: validateUrl
	};
})();