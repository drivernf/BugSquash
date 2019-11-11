$(document).ready(function () {
	var container = $("#ticket-view-container");
	var currTicketViewData = "";
	$('.empty-div').hide();

	// Updates ticket view upon changes
	function getTicketView() {
		$.get("ticket-view", function (data) { if (data !== currTicketViewData) container.html(data); currTicketViewData = data; });
	}

	// Urgency dropdown menu
	$(".dropdown-menu a").click(function () {
		setUrgency($(this).text());
	});
});

function setUrgency(urgText) {
	// Set value for urgency
	var urgInputs = document.getElementsByClassName("urgencyInput");
	for (i = 0; i < urgInputs.length; i++) {
		urgInputs[i].value = urgText;
	}

	// Set dropdown menu text and style
	var urgDropdowns = document.getElementsByClassName("urgency-dropdown");
	for (i = 0; i < urgDropdowns.length; i++) {
		urgDropdowns[i].text = urgText;
	}
}

function showDetailsModal(ticketId) {
	$('#detailsmodal-' + ticketId).modal('show');
}

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