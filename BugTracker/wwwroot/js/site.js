$(document).ready(function () {
	var container = $("#ticket-view-container");
	getTicketView();
	var intervalId = window.setInterval(getTicketView, 1000);
	var currTicketViewData = "";
	var lastDropdownClicked;

	$('.empty-div').hide();

	// Updates ticket view upon changes
	function getTicketView() {
		$.get("ticket-view", function (data) { if (data !== currTicketViewData) container.html(data); currTicketViewData = data; });
	}

	// Urgency dropdown menu
	$(".dropdown-menu a").click(function () {
		// References
		var urgencyText = $(this).text();
		var urgencyInt = 0;
		var urgencyColor = "lightgrey";

		// Assign references
		if (urgencyText === "none") { urgencyInt = 0; urgencyColor = "lightgrey" }
		else if (urgencyText === "vital") { urgencyInt = 3; urgencyColor = "darkred" }
		else if (urgencyText === "average") { urgencyInt = 2; urgencyColor = "yellow" }
		else if (urgencyText === "minor") { urgencyInt = 1; urgencyColor = "green" }

		// Set value for urgency
		var urgInputs = document.getElementsByClassName("urgencyInput");
		var i;
		for (i = 0; i < urgInputs.length; i++) {
			console.log(`#${i} Urg: ${urgencyInt}`);
			urgInputs[i].value = urgencyInt;
		}

		// Set dropdown menu text and style
		if (lastDropdownClicked !== null) {
			lastDropdownClicked.text = urgencyText;
			lastDropdownClicked.style.color = urgencyColor;
		}
	});

	// Urgency button tracker
	$(".urgency-dropdown").click(function () {
		lastDropdownClicked = this;
	});
});

function onDragStart(event) {
	event
		.dataTransfer
		.setData('text/plain', event.target.id);

	event
		.currentTarget
		.style;
}

function onDragOver(event) {
	event.preventDefault();

	event
		.currentTarget
		.style
		.backgroundColor = 'lightgrey';
}

function onDragLeave(event) {
	event
		.currentTarget
		.style
		.backgroundColor = 'transparent';
}

function onDrop(event) {
	event
		.currentTarget
		.style
		.backgroundColor = 'transparent';
}