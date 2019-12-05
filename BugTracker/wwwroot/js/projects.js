function addProject() {
	let projectName = document.getElementById("add-text").value;
	console.log("Project: " + projectName);
	$.get("add-project", { projectName: projectName })
		.done(function (data) {
			console.log("Added Project: " + projectName);
		});
}