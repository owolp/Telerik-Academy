var userController = function () {

	function register() {
		templates.get('register')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			});
	}

	return {
		register: register,
	};
}();