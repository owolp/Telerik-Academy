var homeController = function () {

	function load() {
		templates.get('home-template')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			});		
	}

	return {
		load
	};
}();