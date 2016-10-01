var loginController = function () {

	function login() {
		templates.load('login')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			});		
	}

	return {
		login
	};
}();