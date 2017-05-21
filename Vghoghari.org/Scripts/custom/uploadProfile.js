$(document).ready(function () {

	$.uploadPreview({
		input_field: "#image-upload",   // Default: .image-upload
		preview_box: "#image-preview",  // Default: .image-preview
		label_field: "#image-label",    // Default: .image-label
		label_default: "Choose File",   // Default: Choose File
		label_selected: "Change File",  // Default: Change File
		no_label: false                 // Default: false
	});
	
	$('#btn-upload-image').on('click', function () {
		fetchImage();
	});
});

function fetchImage() {
	let isValid = false;
	let imageData = '';

	let file = $('#image-upload').get(0).files[0];

	if (file !== undefined || file != null) {
		let type = file.type;
		if ($.inArray(type, IMAGE_TYPE) > -1) {

			let reader = new FileReader();
			reader.onload = function () {
				imageData = reader.result;
				uploadImage(imageData);
			};

			reader.onerror = function () {
				$('#err-message').html('Sorry there was some error processing your file. Please refresh this page and try again. Thank you!');
				$('#err-message').removeClass('hide');
			};

			reader.readAsDataURL(file);
		}
		else {
			$('#err-message').html('Incorrect file format. Please select an image file and try again. Thank you!');
			$('#err-message').removeClass('hide');
		}
	}
	else {
		$('#err-message').html('Please select a profile image for your biodata. Biodata without a profile image are treated as incomplete biodata and hence will not be considered for approvals.');
		$('#err-message').removeClass('hide');
	}
}

function uploadImage(imageData) {
	let code = getQueryStringValue('code');

	let url = '../api/MatrimonialApi/Upload';

	let dataObject = new Object();
	dataObject.Code = code;
	dataObject.ImageData = imageData;

	$.ajax({
		method: 'POST'
		, url: url
		, contentType: 'application/json'
		, dataType: 'json'
		, data: JSON.stringify(dataObject)
		, success: function (data, textStatus, jqXhr) {
			$(location).attr('href', '../Matrimonial/MyBiodata?code=' + data);
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
				$(location).attr('href', '../Matrimonial/Manage');
			}
			else if (jqXhr.status === 401) {
				$(location).attr('href', '../User/Login');
			}
			else {
				handleInternalServerError();
			}
		}
	});
}
