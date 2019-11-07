$(document).ready(function () {
	var container = $("#ticket-view-container");
	getTicketView();
	var intervalId = window.setInterval(getTicketView, 1000);
	var currTicketViewData = "";

	function getTicketView() {
		$.get("ticket-view", function (data) { if (data !== currTicketViewData) container.html(data); currTicketViewData = data; });
	}

	$(".dropdown-menu a").click(function () {
		var urgencyText = $(this).text();
		var urgencyInt = 0;
		var urgencyColor = "lightgrey";
		if (urgencyText === "none") { urgencyInt = 0; urgencyColor = "lightgrey" }
		else if (urgencyText === "vital") { urgencyInt = 3; urgencyColor = "darkred" }
		else if (urgencyText === "average") { urgencyInt = 2; urgencyColor = "yellow" }
		else if (urgencyText === "minor") { urgencyInt = 1; urgencyColor = "green" }
		document.getElementById("urgencyInput").value = urgencyInt; 
		$("#dropdownMenuLink").text(urgencyText);
		document.getElementById("dropdownMenuLink").style.color = urgencyColor;
		console.log("Urgency: " + urgencyInt);
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