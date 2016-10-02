const homeController = (() =>  {

	function main() {
		templates.load('home')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			});
	}

	return {
		main
	};
})();