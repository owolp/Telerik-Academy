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
							$(document.body).addClass("logged-in");
						})
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
				$(document.body).removeClass("logged-in");
			})
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

	return {
		login,
		logout
	};
})();