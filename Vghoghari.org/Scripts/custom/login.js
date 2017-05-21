$(document).ready(function () {
	$('#btn-login').on('click', function (e) {
		e.preventDefault();

		login();
	});

	$('#btn-reset').on('click', function () {
		resetData();
	});

	//username
	$('#username').focusin(function () {
		if ($('#username').parent().hasClass('has-error')) {
			$('#username').parent().removeClass('has-error');
		}
		
		if ($('#username').parent().hasClass('has-success')) {
			$('#username').parent().removeClass('has-success');
		}
	});

	$('#username').focusout(function (e) {
		let username = $('#username').val();
		if (!validateUsername(username)) { // if not valid
			handleValidationError('username', 'This is a required field. It can contain alphabets (A to Z or a to z), digits (0 to 9), underscores (_) and periods (.). It can not start or end with a period and can not have more than one period (.) sequentially. Max length possible is 30 characters.');
		}
		else { // if valid
			$('#username').parent().addClass('has-success');
			$('#err-username').empty();
		}
	});

	// password
	$('#password').focusin(function () {
		if ($('#password').parent().hasClass('has-error')) {
			$('#password').parent().removeClass('has-error');
		}

		if ($('#password').parent().hasClass('has-success')) {
			$('#password').parent().removeClass('has-success');
		}
	});

	$('#password').focusout(function (e) {
		let password = $('#password').val();
		if (!validatePassword(password)) { // if not valid
			handleValidationError('password', 'This is a required field. It must contain atleast one upper level alphabet (A to Z), one lower level alphabet (a to z), one digit (0 to 9) and can have any special character. Minimum length required is 8 characteres.');
		}
		else { // if valid
			$('#password').parent().addClass('has-success');
			$('#err-password').empty();
		}
	});
});

function validateUsername(username) {
	if (!username || !username.match(REGEX_USERNAME)) { //if no username or not matching regex
		return false;
	}
	return true;
}

function validatePassword(password) {
	if (!password || !password.match(REGEX_PASSWORD)) { //if no password or not matching regex
		return false;
	}
	return true;
}

function login() {
	let isValid = true;
	
	let username = $('#username').val();
	let password = $('#password').val();
	let isPersistent = $('#persistent').is(':checked');
	console.log(isPersistent);
	
	if (!validateUsername(username)) {
		isValid = false;
		handleValidationError('username', 'This is a required field. It can contain alphabets (A to Z or a to z), digits (0 to 9), underscores (_) and periods (.). It can not start or end with a period and can not have more than one period (.) sequentially. Max length possible is 30 characters.');
	}

	if (!validatePassword(password)) {
		isValid = false;
		handleValidationError('password', 'This is a required field. It must contain atleast one upper level alphabet (A to Z), one lower level alphabet (a to z), one digit (0 to 9) and can have any special character. Minimum length required is 8 characteres.');
	}
	
	if (isValid) {
		let dataObject = new Object();
		dataObject.Username = username;
		dataObject.Password = password;
		dataObject.IsPersistent = isPersistent;
		
		let url = '../api/External/Login';

		$.ajax({
			method: 'POST'
			, url: url
			, contentType: 'application/json'
			, data: JSON.stringify(dataObject)
			, success: function (data, textStatus, jqXhr) {
				$(location).attr('href', '../Home/Index');
			}
			, error: function (jqXhr, textStatus, errorThrown) {
				console.log(jqXhr);
				if (jqXhr.status === 400) {
					$('#err-message').html(jqXhr.responseJSON.Message);
					$('#err-message').removeClass('hide');
				}
				else if (jqXhr.status === 403) {
					$('#err-message').html(jqXhr.responseJSON);
					$('#err-message').removeClass('hide');
				}
				else if (jqXhr.status === 401) {
					$('#err-message').html(jqXhr.responseJSON);
					$('#err-message').removeClass('hide');
				}
				else {
					//handleInternalServerError();
					console.log(jqXhr);
				}
			}
		});
	}
	else {
		$('#err-message').html('There are some data validation errors in the login credential sent. Please correct the errors and try again later. Thank you!');
		$('#err-message').removeClass('hide');
	}
}

function resetData() {
	$('.custom-error').empty();

	$('#fullname').parent().removeClass('has-error');
	$('#fullname').parent().removeClass('has-success');

	$('#mobile-number').parent().removeClass('has-error');
	$('#mobile-number').parent().removeClass('has-success');

	$('#email-id').parent().removeClass('has-error');
	$('#email-id').parent().removeClass('has-success');

	$('#username').parent().removeClass('has-error');
	$('#username').parent().removeClass('has-success');

	$('#password').parent().removeClass('has-error');
	$('#password').parent().removeClass('has-success');

	$('#confirm-password').parent().removeClass('has-error');
	$('#confirm-password').parent().removeClass('has-success');

	$('#err-message').empty();
	$('#err-message').addClass('hide');
}