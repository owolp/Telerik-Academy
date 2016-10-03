const loginController = (() => {

	const USERNAME_CHARS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_.",
		USERNAME_MIN_LENGTH = 6,
		USERNAME_MAX_LENGTH = 30;

	function login() {
		templates.load('login')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			})
			.then(() => {
				$('#btn-login').on('click', function () {
					let user = {
						username: $('#tb-username').val(),
						passHash: $('#tb-password').val()
					};

					login(user);
				});

				$('#btn-register').on('click', function () {
					let user = {
						username: $('#tb-username').val(),
						passHash: $('#tb-password').val()
					};

					var error = validator.validateString(user.username, USERNAME_MIN_LENGTH, USERNAME_MAX_LENGTH, USERNAME_CHARS);

					if (error) {
						return Promise.reject(error.message);
					}

					return userService.register(user)
						.then(() => {
							toastr.success(`${user.username} successfully registered.`);
						})
						.then(() => {
							login(user);
						})
						.catch((res) => {
							toastr.error(res.responseText);
						});
				});

				function login(user) {
					userService.login(user)
						.then(() => {
							toastr.success(`${user.username} successfully logged.`);
						})
						.then(() => {
							window.location = '#/home';
						})
						.catch((res) => {
							toastr.error(res.responseText);
						});
				}
			});
	}

	function logout() {
		return userService.logout()
			.then(() => {
				toastr.success('Successfully logged out.');
			})
			.then(() => {
				window.location = '#/home';
			})
			.catch((res) => {
				toastr.error(res.message);
			});
	}

	function like(cookie) {
		var status = cookie.type;
		return userService.like(cookie)
			.then((data) => {
				if (status === 'like') {
					toastr.success(`You have liked ${data.result.text}`);
				} else {
					toastr.success(`You have unliked ${data.result.text}`);
				}

			})
			.catch((error) => {
				toastr.error('Login first');
			});
	}

	return {
		login,
		logout,
		like
	};
})();