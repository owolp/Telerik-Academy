const userService = (() => {
	const URLS = {
			REGISTER: '/api/users',
			LOGIN: '/api/users/auth',
		},
		USER_HTTP_HEADER_KEY = "x-auth-key",
		USER_KEY_STORAGE_USERNAME = "username",
		USER_KEY_STORAGE_AUTH_KEY = "authKey";

	function login(user) {
		return requester.putJSON(URLS.LOGIN, user)
			.then((respUser) => {
				localStorage.setItem(USER_KEY_STORAGE_USERNAME, respUser.result.username);
				localStorage.setItem(USER_KEY_STORAGE_AUTH_KEY, respUser.result.authKey);
			});
	}

	function register(user) {
		return requester.postJSON(URLS.REGISTER, user);
	}

	function logout() {
		return Promise.resolve()
			.then(() => {
				localStorage.removeItem(USER_KEY_STORAGE_USERNAME);
				localStorage.removeItem(USER_KEY_STORAGE_AUTH_KEY);
			});
	}

	function isLoggedIn() {
		return Promise.resolve()
			.then(() => {
				return !!localStorage.getItem(USER_KEY_STORAGE_USERNAME);
			});
	}

	return {
		login,
		register,
		logout,
		isLoggedIn,
	}
})();