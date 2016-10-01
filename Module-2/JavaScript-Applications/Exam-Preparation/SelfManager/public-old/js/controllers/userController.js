var userController = function () {

	function register() {
		templates.get('register')
			.then((templateHtml) => {
				$('#container').html(templateHtml);

				// attach button events
				$('#btn-login').on('click', function () {
					let user = {
						username: $('#tb-username').val(),
						password: $('#tb-password').val()
					};
					data.login(user)
						.then(function () {
							toastr.success(`User ${user.username} logged in`);
							document.location = '#/';
						})
				});

				// attach button events
				$('#btn-register').on('click', function () {
					let user = {
						username: $('#tb-username').val(),
						password: $('#tb-password').val()
					};
					data.register(user)
						.then(function () {
							console.log('User registered');
						})
				});
			});
	}

	return {
		register: register,
	};
}();