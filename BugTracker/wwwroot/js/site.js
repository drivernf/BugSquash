$(document).ready(function () {
	$('.empty-div').hide();
});

function getTicketBasket() {
	var container = $("#ticket-view-container");
	$.get("basket", function (data) { container.html(data); });
}

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
	$('#detailsmodal-' + ticketId).modal("show");
}

function editTicket(ticketId) {
	var description = document.getElementById("d-description-" + ticketId).value;
	var urgency = document.getElementById("d-urgency-" + ticketId).text;
	console.log("Urgency: " + urgency);
	$.get("edit-ticket", { ticketId: ticketId, urgency: urgency, description: description })
		.done(function (data) {
			$('#detailsmodal-' + ticketId).modal('hide');
			$('.modal-backdrop').hide();
			getTicketBasket();
		});
}

function deleteTicket(ticketId) {
	$.get("delete-ticket", { ticketId: ticketId })
		.done(function (data) {
			$('#detailsmodal-' + ticketId).modal('hide');
			$('.modal-backdrop').hide();
			getTicketBasket();
		});
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