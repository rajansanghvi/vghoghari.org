function getQueryStringValue(key) {
	return unescape(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + escape(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}

function handleInternalServerError() {
	$(location).attr('href', '../Error/Internal')
}

function handleValidationError(element, errorMsg) {
	$('#' + element).parent().addClass('has-error');
	$('#err-' + element).html(errorMsg);
}