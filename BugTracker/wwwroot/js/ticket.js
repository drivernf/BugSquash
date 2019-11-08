function setUrgency(urgency) {
	let bColor = "lightgrey";
	if (urgency == 3) bColor = "darkred";
	else if (urgency == 2) bColor = "darkyellow";
	else if (urgency == 1) bColor = "darkgreen";
	document.getElementById('ticket-urgency').style.backgroundColor = bColor;
}