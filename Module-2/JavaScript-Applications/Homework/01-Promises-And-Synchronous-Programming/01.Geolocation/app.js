(function() {
	var promise = new Promise((resolve) => {
		navigator.geolocation.getCurrentPosition((pos) => {
			resolve(pos);
		})
	});

	function displayMap(pos) {
		var map = new google.maps.Map(document.getElementById('map'), {
			center: {
				lat: pos.coors.latitude,
				lng: pos.coors.longitude
			},
			zoom: 10
		});
	}

	promise
		.then(displayMap);
}());