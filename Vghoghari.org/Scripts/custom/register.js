$(document).ready(function () {
	$('#btn-regiter').on('click', function (e) {
		e.preventDefault();

		registerUser();
	});

	$('#btn-reset').on('click', function () {
		resetData();
	});

	// Fullname
	$('#fullname').focusin(function () {
		if ($('#fullname').parent().hasClass('has-error')) {
			$('#fullname').parent().removeClass('has-error');
		}

		if ($('#fullname').parent().hasClass('has-success')) {
			$('#fullname').parent().removeClass('has-success');
		}		
	});

	$('#fullname').focusout(function (e) {
		let fullname = $('#fullname').val();
		if (!validateFullname(fullname)) { // if not valid
			handleValidationError('fullname', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
		}
		else { // if valid
			$('#fullname').parent().addClass('has-success');
			$('#err-fullname').empty();
		}
	});

	// Mobile Number
	$('#mobile-number').focusin(function () {
		if ($('#mobile-number').parent().hasClass('has-error')) {
			$('#mobile-number').parent().removeClass('has-error');
		}

		if ($('#mobile-number').parent().hasClass('has-success')) {
			$('#mobile-number').parent().removeClass('has-success');
		}
	});

	$('#mobile-number').focusout(function (e) {
		let mobileNumber = $('#mobile-number').val();
		if (!validateMobileNumber(mobileNumber)) { // if not valid
			handleValidationError('mobile-number', 'This is a required field. It can start only with 7, 8 or 9 and can have exactly 10 digtis.');
		}
		else { // if valid
			$('#mobile-number').parent().addClass('has-success');
			$('#err-mobile-number').empty();
		}
	});

	// Email Id
	$('#email-id').focusin(function () {
		if ($('#email-id').parent().hasClass('has-error')) {
			$('#email-id').parent().removeClass('has-error');
		}

		if ($('#email-id').parent().hasClass('has-success')) {
			$('#email-id').parent().removeClass('has-success');
		}
	});

	$('#email-id').focusout(function (e) {
		let emailId = $('#email-id').val();
		if (!validateEmailId(emailId)) { // if not valid
			handleValidationError('email-id', 'This is an optional field. You can leave it blank or enter a valid email id.');
		}
		else { // if valid
			$('#email-id').parent().addClass('has-success');
			$('#err-email-id').empty();
		}
	});

	//username
	$('#username').focusin(function () {
		if ($('#username').parent().hasClass('has-error')) {
			$('#username').parent().removeClass('has-error');
		}

		if ($('#username').parent().hasClass('has-warning')) {
			$('#username').parent().removeClass('has-warning');
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
			$('#username').parent().addClass('has-warning');
			checkUsernameAvailability(username);
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

	//confirm password
	$('#confirm-password').focusin(function () {
		if ($('#confirm-password').parent().hasClass('has-error')) {
			$('#confirm-password').parent().removeClass('has-error');
		}

		if ($('#confirm-password').parent().hasClass('has-success')) {
			$('#confirm-password').parent().removeClass('has-success');
		}
	});

	$('#confirm-password').focusout(function (e) {
		let password = $('#password').val();
		let confirmPassword = $('#confirm-password').val();
		if (!validateConfirmedPassword(password, confirmPassword)) { // if not valid			
			handleValidationError('confirm-password', 'This is a required field. It should match exactly the value entered in the password field');
		}
		else { // if valid
			$('#confirm-password').parent().addClass('has-success');
			$('#err-confirm-password').empty();
		}
	});
});

function validateFullname(fullname) {
	if (!fullname || !fullname.match(REGEX_FULLNAME)) { //if no fullname or not matching regex
		return false;
	}
	return true;
}

function validateMobileNumber(mobileNumber) {
	if (!mobileNumber || !mobileNumber.match(REGEX_MOBILE_NUMBER)) { //if no mobile number or not matching regex
		return false;
	}
	return true;
}

function validateEmailId(emailId) {
	if (emailId && !emailId.match(REGEX_EMAIL_ID)) { //if emailid present and not matching regex
		return false;
	}
	return true;
}

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

function validateConfirmedPassword(password, confirmedPassword) {
	if (!confirmedPassword || password !== confirmedPassword) { //if password does not match confirmed password
		return false;
	}
	return true;
}

function checkUsernameAvailability(username) {
	let url = '../api/External/UsernameAvailable?username=' + username;

	$.ajax({
		method: 'POST'
		, url: url
		, contentType: 'application/json'
		, dataType: 'json'
		, success: function (data, textStatus, jqXhr) {
			if ($('#username').parent().hasClass('has-warning')) {
				$('#username').parent().removeClass('has-warning');
			}
			$('#err-username').empty();
			if (data) {
				$('#username').parent().addClass('has-success');
			}
			else {
				$('#username').parent().addClass('has-error');
				$('#err-username').html('This username is already registered. Please try using a different username.');
			}
		}
		, error: function (jqXhr, textStatus, errorThrown) {
			console.log(jqXhr);
			handleInternalServerError();
		}
	});
}

function registerUser() {
	let isValid = true;
	let fullname = $('#fullname').val();
	let mobileNumber = $('#mobile-number').val();
	let emailId = $('#email-id').val();
	let username = $('#username').val();
	let password = $('#password').val();
	let confirmPassword = $('#confirm-password').val();

	if (!validateFullname(fullname)) {
		isValid = false;
		handleValidationError('fullname', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
	}

	if (!validateMobileNumber(mobileNumber)) {
		isValid = false;
		handleValidationError('mobile-number', 'This is a required field. It can start only with 7, 8 or 9 and can have exactly 10 digtis.');
	}

	if (!validateEmailId(emailId)) {
		isValid = false;
		handleValidationError('email-id', 'This is an optional field. You can leave it blank or enter a valid email id.');
	}

	if (!validateUsername(username)) {
		isValid = false;
		handleValidationError('username', 'This is a required field. It can contain alphabets (A to Z or a to z), digits (0 to 9), underscores (_) and periods (.). It can not start or end with a period and can not have more than one period (.) sequentially. Max length possible is 30 characters.');
	}

	if (!validatePassword(password)) {
		isValid = false;
		handleValidationError('password', 'This is a required field. It must contain atleast one upper level alphabet (A to Z), one lower level alphabet (a to z), one digit (0 to 9) and can have any special character. Minimum length required is 8 characteres.');
	}

	if (!validateConfirmedPassword(password, confirmPassword)) {
		isValid = false;
		handleValidationError('confirm-password', 'This is a required field. It should match exactly the value entered in the password field');
	}

	if (isValid) {
		let dataObject = new Object();
		dataObject.FullName = fullname;
		dataObject.Username = username;
		dataObject.Password = password;
		dataObject.ConfirmedPassword = confirmPassword;
		dataObject.MobileNumber = mobileNumber;
		dataObject.EmailId = emailId;

		let url = '../api/External/Register';

		$.ajax({
			method: 'POST'
			, url: url
			, contentType: 'application/json'
			, dataType: 'json'
			, data: JSON.stringify(dataObject)
			, success: function (data, textStatus, jqXhr) {
				$(location).attr('href', '../User/Login');
			}
			, error: function (jqXhr, textStatus, errorThrown) {
				console.log(jqXhr);
				if (jqXhr.status === 400) {
					$('#err-message').html(jqXhr.responseJSON.Message);
					$('#err-message').removeClass('hide');
				}
				else if (jqXhr.status === 409) {
					$('#err-message').html(jqXhr.responseJSON);
					$('#err-message').removeClass('hide');
				}
				else {
					handleInternalServerError();
				}
			}
		});
	}
	else {

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