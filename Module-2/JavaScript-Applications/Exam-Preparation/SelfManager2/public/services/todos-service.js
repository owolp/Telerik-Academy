const todosService = (() => {
	const URLS = {
			GET: '/api/todos',
			ADD: '/api/todos',
		},
		USER_HTTP_HEADER_KEY = "x-auth-key",
		USER_KEY_STORAGE_USERNAME = "username",
		USER_KEY_STORAGE_AUTH_KEY = "authKey";

	function all() {
		let headers = {};
		let loggedUser = userService.isLoggedIn();
		if (loggedUser) {
			headers = {
				[USER_HTTP_HEADER_KEY]: localStorage.getItem(USER_KEY_STORAGE_AUTH_KEY)
			};
		} else {
			toastr.warning(`You are not logged.`);
		}

		return requester.getJSON(URLS.GET, headers);
	}

	return {
		all,
	}
})();


// rateCookie(cookieId, type) {
// 		let options = {
// 			headers: {
// 				[HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
// 			}
// 		};

// 		return requester.putJSON("/api/cookies/" + cookieId, {
// 			type
// 		}, options);

// 	},