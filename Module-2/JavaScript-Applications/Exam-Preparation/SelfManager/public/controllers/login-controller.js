const loginController = (() => {

	function login() {
		templates.load('login')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			})
			.then(() => {
				$('#btn-login').on('click', function () {
					let user = {
						username: $('#tb-username').val(),
						password: $('#tb-password').val()
					};

					login(user);
				});

				$('#btn-register').on('click', function () {
					let user = {
						username: $('#tb-username').val(),
						password: $('#tb-password').val()
					};
					console.log('User registered');
					const usernameLength = user.username.length;
					if (!(6 <= usernameLength && usernameLength <= 30)) {
						toastr.error('Incorrect username length.', 'Username should be between 6 and 30 characters long.');
						return new Promise((resolve, reject) => {
							resolve();
						});
					}

					return userService.register(user)
						.then(() => {
							toastr.success('registered');
						})
						.then(() => {
							login(user);
						})
						.catch(() => {
							toastr.error('error');
						});
				});

				function login(user) {
					userService.login(user)
						.then(() => {
							toastr.success('logged in');
						})
						.then(() => {
							window.location = '#/';
						})
						.catch(() => {
							toastr.error('error');
						});
				}
			});
	}

	function logout() {
		return userService.logout()
			.then(() => {
				toastr.success('logged out');
			})
			.then(() => {
				window.location = '#/home';
			})
			.catch(() => {
				toastr.error('error');
			});
	}

	return {
		login,
		logout
	};
})();