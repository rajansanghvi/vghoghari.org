$(document).ready(function () {
	$('#btn-login').on('click', function (e) {
		e.preventDefault();

		login();
	});

	$('#btn-reset').on('click', function () {
		resetData();
	});
});

function login() {

	let username = $('#username').val();
	let password = $('#password').val();
	let isPersistent = $('#persistent').is(':checked');

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
				console.log(jqXhr);
				handleInternalServerError();
			}
		}
	});
}

function resetData() {
	$('.custom-error').empty();
	
	$('#username').parent().removeClass('has-error');
	$('#username').parent().removeClass('has-success');

	$('#password').parent().removeClass('has-error');
	$('#password').parent().removeClass('has-success');
	
	$('#err-message').empty();
	$('#err-message').addClass('hide');
}