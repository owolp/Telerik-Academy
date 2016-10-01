var data = (function() {
	const USERNAME_STORAGE_KEY = 'username-key';

	// start users
	function userLogin(user) {
		localStorage.setItem(USERNAME_STORAGE_KEY, user);
		return Promise.resolve(user);
	}

	function userLogout() {
		localStorage.removeItem(USERNAME_STORAGE_KEY)
		return Promise.resolve();
	}

	function userGetCurrent() {
		return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
	}
	// end users

	var url = 'http://localhost:1509/';

	// start threads
	function threadsGet() {
		return new Promise((resolve, reject) => {
			$.getJSON('api/threads')
				.done(resolve)
				.fail(reject);
		})
	}

	function threadById(id) {
		return new Promise((resolve, reject) => {
			$.getJSON(`api/threads/${id}`)
				.done(resolve)
				.fail(reject);
		});
	}

	function threadsAdd(title) {
		let body = {
			title: title,
			username: 'anonymous'
		}

		return new Promise((resolve, reject) => {
			$.ajax({
					url: url + 'api/threads',
					method: 'POST',
					data: JSON.stringify(body),
					contentType: 'application/json'
				})
				.done(resolve)
				.fail(reject);
		});
	}

	function threadsAddMessage(threadId, content) {
		return new Promise((resolve, reject) => {
			let body = {
				content: content,
				username: 'anonymous'
			};

			$.ajax({
					url: url + `api/threads/${threadId}/messages`,
					method: 'POST',
					data: JSON.stringify(body),
					contentType: 'application/json'
				})
				.done(resolve)
				.fail(reject);
		});
	}
	// end threads

	// start gallery
	function galleryGet() {
		const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;

		return new Promise((resolve, reject) => {
			// $.getJSON('https://www.reddit.com/r/aww.json', function(resource) {
			// 	resolve(resource);
			// });
			$.ajax({
					url: REDDIT_URL,
					dataType: 'jsonp'
				})
				.done(resolve)
				.fail(reject);
		})
	}
	// end gallery

	return {
		users: {
			login: userLogin,
			logout: userLogout,
			current: userGetCurrent
		},
		threads: {
			get: threadsGet,
			add: threadsAdd,
			getById: threadById,
			addMessage: threadsAddMessage
		},
		gallery: {
			get: galleryGet,
		}
	}
})();

export {
	data
};