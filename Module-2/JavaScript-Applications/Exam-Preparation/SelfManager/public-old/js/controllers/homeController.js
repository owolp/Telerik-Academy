var homeController = function () {

	function all() {
		templates.get('home')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			});		
	}

	return {
		all: all
	};
}();