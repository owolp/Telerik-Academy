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
		return new Promise((resolve) => {
			$.getJSON(`api/threads/${id}`, function(resource) {
				resolve(resource);
			});
		});
	}

	function threadsAdd(title) {
		return new Promise((resolve, reject) => {
			$.ajax({
				url: url + 'api/threads',
				method: 'POST',
				data: JSON.stringify({
					title
				}),
				contentType: 'application/json',
				success: function(title) {
					resolve(title);
				},
				error: function(err) {
					reject(err);
				}
			});
		});
	}

	function threadsAddMessage(threadId, content) {
		return new Promise((resolve, reject) => {
			userGetCurrent()
				.then((username) => {
					let body = {
						content,
						username
					};

					$.ajax({
							url: url + `api/threads/${threadId}/messages`,
							method: 'POST',
							data: JSON.stringify(
								body
							),
							contentType: 'application/json'
						})
						.done(resolve)
						.fail(reject);
				})
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