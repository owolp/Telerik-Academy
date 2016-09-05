function solve() {
	var id = 1;

	var Student = {
		init: function(firstName, lastName, id) {
			_validateString(firstName);
			_validateString(lastName);

			this._firstName = firstName;
			this._lastName = lastName;
			this._id = id;

			return this;
		}
	};

	var Presentation = {
		init: function(title, homework) {
			this._title = title;
			this._homework = homework;

			return this;
		}
	};

	var Course = {
		init: function(title, presentations) {
			_validateString(title);
			_validatePresentations(presentations);

			this._title = title;
			this._presentations = presentations;
			this._students = [];

			return this;
		},

		addStudent: function(name) {},
		getAllStudents: function() {},
		submitHomework: function(studentID, homeworkID) {},
		pushExamResults: function(results) {},
		getTopStudents: function() {}
	};

	function _validateString(titleToCheck) {
		if (titleToCheck.startsWith(' ')) {
			return new Error();
		}

		if (titleToCheck.endsWith(' ')) {
			return new Error();
		}

		if (titleToCheck === ' ') {
			return new Error();
		}

		if (/\s\s+/.test(titleToCheck)) {
			return new Error();
		}
	};

	function _validatePresentations(presentationsToCheck) {
		if (presentationsToCheck.length === 0) {
			throw new Error();
		}
	};

	return Course;
}

module.exports = solve;