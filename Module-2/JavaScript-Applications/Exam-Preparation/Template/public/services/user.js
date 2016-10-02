const userService = (() => {
	const URLS = {
		REGISTER: 'api/users',
		LOGIN: 'api/auth'
	};

	function login(user) {
		return requester.putJSON(URLS.LOGIN, user)
			.then(respUser => {
				let user = respUser.result
				let stringifiedUser = JSON.stringify(user);
				localStorage.setItem('loggedUser', stringifiedUser);
				localStorage.setItem('isLogged', 'loggedUser');

				let username = user.username;

				return username;
			});
	}

	function register(user) {
		return requester.postJSON(URLS.REGISTER, user);
	}

	function logout() {
		return Promise.resolve()
			.then(() => {
				localStorage.removeItem("username");
				localStorage.removeItem("authKey");
				localStorage.removeItem("loggedUser");
				localStorage.removeItem("isLogged");
			});
	}

	function isLogged() {
		const isLogged = localStorage.isLogged ? true : false;

		return isLogged;
	}

	function load() {
		if (!isLogged) {
			return;
		}

		const stringifiedUser = localStorage.getItem('loggedUser');
		const user = JSON.parse(stringifiedUser);

		return user;
	}

	return {
		login,
		register,
		logout,
		isLogged,
		load
	}
})();