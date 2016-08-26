(function() {
	'use strict';
	
	let navigatorAppName = navigator.appName,
		addScroll = false,
		off = 0,
		txt = "",
		pX = 0,
		pY = 0,
		theLayer;

	if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
		(navigator.userAgent.indexOf('MSIE 6')) > 0) {
		addScroll = true;
	}

	document.onmousemove = mouseMove;

	if (navigatorAppName == "Netscape") {
		document.captureEvents(Event.MOUSEMOVE)
	};

	function mouseMove(ev) {
		if (navigatorAppName == "Netscape") {
			pX = ev.pageX - 5;
			pY = ev.pageY;
		} else {
			pX = event.x - 5;
			pY = event.y;
		}

		if (navigatorAppName == "Netscape" && document.layers['ToolTip'].visibility == 'show' ||
			document.all['ToolTip'].style.visibility == 'visible') {
			PopTip();
		}
	}

	function PopTip() {
		if (navigatorAppName == "Netscape") {
			theLayer = eval('document.layers[\'ToolTip\']');

			if ((pX + 120) > window.innerWidth) {
				pX = window.innerWidth - 150;
			}

			theLayer.left = pX + 10;
			theLayer.top = pY + 15;
			theLayer.visibility = 'show';
		} else {
			theLayer = eval('document.all[\'ToolTip\']');

			if (theLayer) {
				pX = event.x - 5;
				pY = event.y;

				if (addScroll) {
					pX = pX + document.body.scrollLeft;
					pY = pY + document.body.scrollTop;
				}

				if ((pX + 120) > document.body.clientWidth) {
					pX = pX - 150;
				}

				theLayer.style.pixelLeft = pX + 10;
				theLayer.style.pixelTop = pY + 15;
				theLayer.style.visibility = 'visible';
			}
		}
	}

	function HideTip() {
		args = HideTip.arguments;

		if (navigatorAppName == "Netscape") {
			document.layers['ToolTip'].visibility = 'hide';
		} else {
			document.all['ToolTip'].style.visibility = 'hidden';
		}
	}

	function HideFirstMenu() {
		if (navigatorAppName == "Netscape") {
			document.layers['menu1'].visibility = 'hide';
		} else {
			document.all['menu1'].style.visibility = 'hidden';
		}
	}

	function ShowFirstMenu() {
		if (navigatorAppName == "Netscape") {
			theLayer = eval('document.layers[\'menu1\']');
			theLayer.visibility = 'show';
		} else {
			theLayer = eval('document.all[\'menu1\']');
			theLayer.style.visibility = 'visible';
		}
	}

	function HideSecondMenu() {
		if (navigatorAppName == "Netscape") {
			document.layers['menu2'].visibility = 'hide';
		} else {
			document.all['menu2'].style.visibility = 'hidden';
		}
	}

	function ShowSecondMenu() {
		if (navigatorAppName == "Netscape") {
			theLayer = eval('document.layers[\'menu2\']');
			theLayer.visibility = 'show';
		} else {
			theLayer = eval('document.all[\'menu2\']');
			theLayer.style.visibility = 'visible';
		}
	}
})();