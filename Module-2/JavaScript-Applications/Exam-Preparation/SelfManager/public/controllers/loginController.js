var loginController = function () {

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
					userservice.login(user)
						.then(function () {
							toastr.success(`User ${user.username} logged in`);
						})
				});

				// attach button events
				$('#btn-register').on('click', function () {
					let user = {
						username: $('#tb-username').val(),
						password: $('#tb-password').val()
					};
					userservice.register(user)
						.then(function () {
							console.log('User registered');
						})
				});
			});

		// attach button events

	}

	return {
		login
	};
}();