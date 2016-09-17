(function() {
	let redirectURL = 'https://telerikacademy.com',
		redirectTime = 2000;

	let wrapper = document.createElement('div');
	wrapper.className = ' redirect';
	wrapper.innerHTML = 'About to redirect in 2 seconds';
	document.body.appendChild(wrapper);

	function redirectToURL() {
		window.location = redirectURL;
	}

	let promise = new Promise(function(resolve) {
		setTimeout(function() {
			resolve();
		}, redirectTime);
	});

	promise
		.then(redirectToURL);
}());