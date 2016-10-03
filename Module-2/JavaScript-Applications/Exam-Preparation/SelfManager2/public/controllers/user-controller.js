const userController = (() => {

	const USERNAME_CHARS = 'qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_.',
		USERNAME_MIN_LENGTH = 6,
		USERNAME_MAX_LENGTH = 30;

	function login() {
		userService.isLoggedIn()
			.then(isLoggedIn => {
				if (isLoggedIn) {
					window.location = '#/home';

					return;
				}

				templates.get('user-template')
					.then((templateHtml) => {
						$('#container').html(templateHtml);
					})
					.then(() => {
						$('#btn-login').on('click', function () {
							let user = {
								username: $('#tb-username').val(),
								passHash: $('#tb-password').val()
							};

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
						});

						$('#btn-register').on('click', function () {
							let user = {
								username: $('#tb-username').val(),
								passHash: $('#tb-password').val()
							};

							let error = validator.validateString(user.username, USERNAME_MIN_LENGTH, USERNAME_MAX_LENGTH, USERNAME_CHARS);

							if (error) {
								toastr.error(`Username must be between ${USERNAME_MIN_LENGTH} and ${USERNAME_MAX_LENGTH} symbols.`);
								return;
								// return Promise.reject(error.message);
							}

							userService.register(user)
								.then((respUser) => {
									return userService.login(user);
								})
								.then(() => {
									$(document.body).addClass("logged-in");
								})
								.then(() => {
									toastr.success(`${user.username} successfully registered.`);
								})
								.then(() => {
									window.location = '#/home';
								})
								.catch((res) => {
									toastr.error(res.responseText);
								});
						});
					});
			})
	};

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