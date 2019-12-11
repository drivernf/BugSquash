function addProject() {
	let projectName = document.getElementById("add-text").value;
	$.get("add-project", { projectName: projectName })
		.done(function (data) {
			window.location.reload(true); 
		});
}