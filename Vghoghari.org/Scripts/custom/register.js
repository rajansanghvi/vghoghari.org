$(document).ready(function () {

	$('#userRegistrationForm').validator().on('submit', function (event) {

		if (event.isDefaultPrevented()) {
			//Invalid Form Field.
		}
		else {
			event.preventDefault();
			registerUser();
		}
	});

	$('#btn-reset').on('click', function () {
		resetData();
	});

	//user name validation for duplicate usernames
	$('#username').focusout(function (e) {
		e.preventDefault();
		let username = $('#username').val().trim();

		if (username.match(REGEX_USERNAME)) {
			$('#username').parent().addClass('has-warning');
			checkUsernameAvailability(username);
		}
	});
});

function checkUsernameAvailability(username) {
	let url = '../api/External/UsernameAvailable?username=' + username;

	$.ajax({
		method: 'GET'
		, url: url
		, contentType: 'application/json'
		, dataType: 'json'
		, success: function (data, textStatus, jqXhr) {
			$('#username').parent().removeClass('has-warning');
			$('#username').parent().removeClass('has-error');
			$('#username').parent().removeClass('has-success');
			$('#err-username').empty();
			if (data) {
				$('#username').parent().addClass('has-success');
			}
			else {
				$('#username').parent().addClass('has-error');
				$('#err-username').html('This username is already registered. Please try using a different username.');
			}

			return data;
		}
		, error: function (jqXhr, textStatus, errorThrown) {
			console.log(jqXhr);
			handleInternalServerError();
		}
	});
}

function registerUser() {

	let fullname = $('#fullname').val().trim();
	let mobileNumber = $('#mobile-number').val().trim();
	let emailId = $('#email-id').val().trim();
	let username = $('#username').val().trim();
	let password = $('#password').val().trim();
	let confirmPassword = $('#confirm-password').val().trim();

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