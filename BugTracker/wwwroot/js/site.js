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
	if ($('#item-' + ticketId).hasClass('noclick')) {
		$('#item-' + ticketId).removeClass('noclick');
	}
	else {
		$('#detailsmodal-' + ticketId).modal("show");
	}
}

function editTicket(ticketId) {
	var description = document.getElementById("d-description-" + ticketId).value;
	var urgency = document.getElementById("d-urgency-" + ticketId).text;
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

function statusTicket(ticket, container) {
	var ticketId = ticket.attr('id').replace('item-', '');
	var ticketClasses = ticket.attr('class').split(/\s+/);
	var containerId = container.attr('id');
	for (var i = 0; i < ticketClasses.length; i++) {
		if (ticketClasses[i] === containerId) { return; }
	}
	ticket.draggable("option", "revertDuration", 0);
	ticket.appendTo(container.children());
	$.get("status-ticket", { ticketId: ticketId, status: containerId.replace('status-', '') })
		.done(function (data) {
			getTicketBasket();
		});
}