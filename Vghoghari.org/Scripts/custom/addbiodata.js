$(document).ready(function () {

	$('#dob').datetimepicker({
		format: 'YYYY-MM-DD',
		useCurrent: false,
		maxDate: moment().subtract(18, 'years'),
		icons: {
			time: 'fa fa-clock-o',
			date: 'fa fa-calendar',
			up: 'fa fa-chevron-up',
			down: 'fa fa-chevron-down',
			previous: 'fa fa-chevron-left',
			next: 'fa fa-chevron-right',
			today: 'fa fa-home',
			clear: 'fa fa-trash',
			close: 'fa fa-trash'
		}
	});

	$('#birthtime').datetimepicker({
		format: 'HH:mm',
		useCurrent: false,
		icons: {
			time: 'fa fa-clock-o',
			date: 'fa fa-calendar',
			up: 'fa fa-chevron-up',
			down: 'fa fa-chevron-down',
			previous: 'fa fa-chevron-left',
			next: 'fa fa-chevron-right',
			today: 'fa fa-home',
			clear: 'fa fa-trash',
			close: 'fa fa-trash'
		}
	});

	fetchCities(function (data) {
		$.each(data, function (index, value) {
			$('#city').append($('<option>', {
				text: value.Key,
				value: value.Value
			}));
		});

		$('#city').selectpicker('refresh');
	});

	// gender
	$('#gender').on('hidden.bs.select', function (e) {
		e.preventDefault();

		let gender = $('#gender').val().trim();
		if (!validateDropdown(gender)) {
			handleDropdownValidationError('gender', 'This is a required field. Please select from the available options.');
		}
		else {
			$('#err-gender').empty();
		}
	});

	// Fullname
	$('#fullname').focusin(function (e) {
		e.preventDefault();

		if ($('#fullname').parent().hasClass('has-error')) {
			$('#fullname').parent().removeClass('has-error');
		}

		if ($('#fullname').parent().hasClass('has-success')) {
			$('#fullname').parent().removeClass('has-success');
		}
	});

	$('#fullname').focusout(function (e) {
		e.preventDefault();

		let fullname = $('#fullname').val().trim();
		if (!validateFullname(fullname)) { // if not valid
			handleValidationError('fullname', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
		}
		else { // if valid
			$('#fullname').parent().addClass('has-success');
			$('#err-fullname').empty();
		}
	});

	$('#dob').focusin(function (e) {
		e.preventDefault();

		if ($('#dob').parent().hasClass('has-error')) {
			$('#dob').parent().removeClass('has-error');
		}

		if ($('#dob').parent().hasClass('has-success')) {
			$('#dob').parent().removeClass('has-success');
		}
	});

	$('#dob').focusout(function (e) {
		e.preventDefault();
		
		let dob = $('#dob').val();
		if (!validateDob(dob)) { // if not valid
			handleValidationError('dob', 'This is a required field. Please select candidate\'s date of birth. Candidate should be above 18 years of age.');
		}
		else { // if valid
			$('#dob').parent().addClass('has-success');
			$('#err-dob').empty();
		}
	});

	$('#birthtime').focusin(function (e) {
		e.preventDefault();

		if ($('#birthtime').parent().hasClass('has-error')) {
			$('#birthtime').parent().removeClass('has-error');
		}

		if ($('#birthtime').parent().hasClass('has-success')) {
			$('#birthtime').parent().removeClass('has-success');
		}
	});

	$('#birthtime').focusout(function (e) {
		e.preventDefault();

		let birthtime = $('#birthtime').val();
		if (!validateBirthTime(birthtime)) { // if not valid
			handleValidationError('birthtime', 'This is an optional field. You can leave it blank or select candidate\'s valid birth time.');
		}
		else { // if valid
			$('#birthtime').parent().addClass('has-success');
			$('#err-birthtime').empty();
		}
	});

	$('#marital-status').on('hidden.bs.select', function (e) {
		e.preventDefault();
		
		let maritalStatus = $('#marital-status').val().trim();
		if (!validateDropdown(maritalStatus)) {
			handleDropdownValidationError('marital-status', 'This is a required field. Please select from the available options.');
		}
		else {
			$('#err-marital-status').empty();
		}
	});

	$('#native').focusin(function (e) {
		e.preventDefault();

		if ($('#native').parent().hasClass('has-error')) {
			$('#native').parent().removeClass('has-error');
		}

		if ($('#native').parent().hasClass('has-success')) {
			$('#native').parent().removeClass('has-success');
		}
	});

	$('#native').focusout(function (e) {
		e.preventDefault();

		let native = $('#native').val().trim();
		if (!validateText(native)) { // if not valid
			handleValidationError('native', 'This is a required field. Please enter candidate\'s native place.');
		}
		else { // if valid
			$('#native').parent().addClass('has-success');
			$('#err-native').empty();
		}
	});

	$('#birth-place').focusin(function (e) {
		e.preventDefault();

		if ($('#birth-place').parent().hasClass('has-success')) {
			$('#birth-place').parent().removeClass('has-success');
		}
	});

	$('#birth-place').focusout(function (e) {
		e.preventDefault();

		let birthPlace = $('#birth-place').val().trim();
		$('#birth-place').parent().addClass('has-success');
		$('#err-birth-place').empty();
	});

	$('#caste').on('hidden.bs.select', function (e) {
		e.preventDefault();

		let caste = $('#caste').val().trim();
		if (!validateDropdown(caste)) {
			handleDropdownValidationError('caste', 'This is a required field. Please select from the available options.');
		}
		else {
			$('#err-caste').empty();
		}
	});

	$('#height-ft').on('hidden.bs.select', function (e) {
		e.preventDefault();
		
		let heightFt = $('#height-ft').val();
		if (!validateDropdown(heightFt)) {
			handleDropdownValidationError('height-ft', 'This is a required field. Please select from the available options.');
		}
		else {
			$('#err-height-ft').empty();
		}
	});

	$('#height-in').on('hidden.bs.select', function (e) {
		e.preventDefault();

		let heightIn = $('#height-in').val();
		if (!validateDropdown(heightIn)) {
			handleDropdownValidationError('height-in', 'This is a required field. Please select from the available options.');
		}
		else {
			$('#err-height-in').empty();
		}
	});

	$('#weight').focusin(function (e) {
		e.preventDefault();

		if ($('#weight').parent().hasClass('has-error')) {
			$('#weight').parent().removeClass('has-error');
		}

		if ($('#weight').parent().hasClass('has-success')) {
			$('#weight').parent().removeClass('has-success');
		}
	});

	$('#weight').focusout(function (e) {
		e.preventDefault();

		let weight = $('#weight').val();
		if (!validateOptionalNumber(weight)) { // if not valid
			handleValidationError('weight', 'This is a an optional field. You can leave it blank or please enter a valid number.');
		}
		else { // if valid
			$('#weight').parent().addClass('has-success');
			$('#err-weight').empty();
		}
	});

	$('#education').on('hidden.bs.select', function (e) {
		e.preventDefault();

		let education = $('#education').val().trim();
		if (!validateDropdown(education)) {
			handleDropdownValidationError('education', 'This is a required field. Please select from the available options.');
		}
		else {
			$('#err-education').empty();
		}
	});

	$('#occupation').on('hidden.bs.select', function (e) {
		e.preventDefault();
		
		let occupation = $('#occupation').val().trim();
		if (!validateDropdown(occupation)) {
			handleDropdownValidationError('occupation', 'This is a required field. Please select from the available options.');
		}
		else {
			$('#err-occupation').empty();
		}
	});

	$('#annual-income').focusin(function (e) {
		e.preventDefault();

		if ($('#annual-income').parent().hasClass('has-error')) {
			$('#annual-income').parent().removeClass('has-error');
		}

		if ($('#annual-income').parent().hasClass('has-success')) {
			$('#annual-income').parent().removeClass('has-success');
		}
	});

	$('#fannual-income').focusout(function (e) {
		e.preventDefault();

		let annualIncome = $('#annual-income').val();
		if (!validateOptionalNumber(annualIncome)) { // if not valid
			handleValidationError('annual-income', 'This is an optional field. You can leave it blank or please enter a valid number.');
		}
		else { // if valid
			$('#annual-income').parent().addClass('has-success');
			$('#err-annual-income').empty();
		}
	});
	
	$('#father-name').focusin(function (e) {
		e.preventDefault();

		if ($('#father-name').parent().hasClass('has-error')) {
			$('#father-name').parent().removeClass('has-error');
		}

		if ($('#father-name').parent().hasClass('has-success')) {
			$('#father-name').parent().removeClass('has-success');
		}
	});

	$('#father-name').focusout(function (e) {
		e.preventDefault();

		let fatherName = $('#father-name').val().trim();
		if (!validateFullname(fatherName)) { // if not valid
			handleValidationError('father-name', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
		}
		else { // if valid
			$('#father-name').parent().addClass('has-success');
			$('#err-father-name').empty();
		}
	});
	
	$('#mother-name').focusin(function (e) {
		e.preventDefault();

		if ($('#mother-name').parent().hasClass('has-error')) {
			$('#mother-name').parent().removeClass('has-error');
		}

		if ($('#mother-name').parent().hasClass('has-success')) {
			$('#mother-name').parent().removeClass('has-success');
		}
	});

	$('#mother-name').focusout(function (e) {
		e.preventDefault();

		let motherName = $('#mother-name').val().trim();
		if (!validateFullname(motherName)) { // if not valid
			handleValidationError('mother-name', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
		}
		else { // if valid
			$('#mother-name').parent().addClass('has-success');
			$('#err-mother-name').empty();
		}
	});

	$('#no-of-married-bro').focusin(function (e) {
		e.preventDefault();

		if ($('#no-of-married-bro').parent().hasClass('has-error')) {
			$('#no-of-married-bro').parent().removeClass('has-error');
		}

		if ($('#no-of-married-bro').parent().hasClass('has-success')) {
			$('#no-of-married-bro').parent().removeClass('has-success');
		}
	});

	$('#no-of-married-bro').focusout(function (e) {
		e.preventDefault();

		let noOfMarriedBro = $('#no-of-married-bro').val();
		if (!validateNumber(noOfMarriedBro)) { // if not valid
			handleValidationError('no-of-married-bro', 'This is a required field. Please enter a valid number.');
		}
		else { // if valid
			$('#no-of-married-bro').parent().addClass('has-success');
			$('#err-no-of-married-bro').empty();
		}
	});

	$('#no-of-married-sis').focusin(function (e) {
		e.preventDefault();

		if ($('#no-of-married-sis').parent().hasClass('has-error')) {
			$('#no-of-married-sis').parent().removeClass('has-error');
		}

		if ($('#no-of-married-sis').parent().hasClass('has-success')) {
			$('#no-of-married-sis').parent().removeClass('has-success');
		}
	});

	$('#no-of-married-sis').focusout(function (e) {
		e.preventDefault();

		let noOfMarriedSis = $('#no-of-married-sis').val();
		if (!validateNumber(noOfMarriedSis)) { // if not valid
			handleValidationError('no-of-married-sis', 'This is a required field. Please enter a valid number.');
		}
		else { // if valid
			$('#no-of-married-sis').parent().addClass('has-success');
			$('#err-no-of-married-sis').empty();
		}
	});

	$('#no-of-unmarried-bro').focusin(function (e) {
		e.preventDefault();

		if ($('#no-of-unmarried-bro').parent().hasClass('has-error')) {
			$('#no-of-unmarried-bro').parent().removeClass('has-error');
		}

		if ($('#no-of-unmarried-bro').parent().hasClass('has-success')) {
			$('#no-of-unmarried-bro').parent().removeClass('has-success');
		}
	});

	$('#no-of-unmarried-bro').focusout(function (e) {
		e.preventDefault();

		let noOfunmarriedBro = $('#no-of-unmarried-bro').val();
		if (!validateNumber(noOfunmarriedBro)) { // if not valid
			handleValidationError('no-of-unmarried-bro', 'This is a required field. Please enter a valid number.');
		}
		else { // if valid
			$('#no-of-unmarried-bro').parent().addClass('has-success');
			$('#err-no-of-unmarried-bro').empty();
		}
	});

	$('#no-of-unmarried-sis').focusin(function (e) {
		e.preventDefault();

		if ($('#no-of-unmarried-sis').parent().hasClass('has-error')) {
			$('#no-of-unmarried-sis').parent().removeClass('has-error');
		}

		if ($('#no-of-unmarried-sis').parent().hasClass('has-success')) {
			$('#no-of-unmarried-sis').parent().removeClass('has-success');
		}
	});

	$('#no-of-unmarried-sis').focusout(function (e) {
		e.preventDefault();

		let noOfUnmarriedSis = $('#no-of-unmarried-sis').val();
		if (!validateNumber(noOfUnmarriedSis)) { // if not valid
			handleValidationError('no-of-unmarried-sis', 'This is a required field. Please enter a valid number.');
		}
		else { // if valid
			$('#no-of-unmarried-sis').parent().addClass('has-success');
			$('#err-no-of-unmarried-sis').empty();
		}
	});

	$('#mosal-name').focusin(function (e) {
		e.preventDefault();

		if ($('#mosal-name').parent().hasClass('has-error')) {
			$('#mosal-name').parent().removeClass('has-error');
		}

		if ($('#mosal-name').parent().hasClass('has-success')) {
			$('#mosal-name').parent().removeClass('has-success');
		}
	});

	$('#mosal-name').focusout(function (e) {
		e.preventDefault();

		let mosalName = $('#mosal-name').val().trim();
		if (!validateFullname(mosalName)) { // if not valid
			handleValidationError('mosal-name', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
		}
		else { // if valid
			$('#mosal-name').parent().addClass('has-success');
			$('#err-mosal-name').empty();
		}
	});

	$('#mosal-native').focusin(function (e) {
		e.preventDefault();

		if ($('#mosal-native').parent().hasClass('has-error')) {
			$('#mosal-native').parent().removeClass('has-error');
		}

		if ($('#mosal-native').parent().hasClass('has-success')) {
			$('#mosal-native').parent().removeClass('has-success');
		}
	});

	$('#mosal-native').focusout(function (e) {
		e.preventDefault();

		let mosalNative = $('#mosal-native').val().trim();
		if (!validateText(mosalNative)) { // if not valid
			handleValidationError('mosal-native', 'This is a required field. Please enter the native place of candidate\'s maternal family.');
		}
		else { // if valid
			$('#mosal-native').parent().addClass('has-success');
			$('#err-mosal-native').empty();
		}
	});

	$('#address').focusin(function (e) {
		e.preventDefault();

		if ($('#address').parent().hasClass('has-error')) {
			$('#address').parent().removeClass('has-error');
		}

		if ($('#address').parent().hasClass('has-success')) {
			$('#address').parent().removeClass('has-success');
		}
	});

	$('#address').focusout(function (e) {
		e.preventDefault();

		let address = $('#address').val().trim();
		if (!validateText(address)) { // if not valid
			handleValidationError('address', 'This is a required field. Please enter the complete address.');
		}
		else { // if valid
			$('#address').parent().addClass('has-success');
			$('#err-address').empty();
		}
	});

	$('#mobile-number').focusin(function (e) {
		e.preventDefault();

		if ($('#mobile-number').parent().hasClass('has-error')) {
			$('#mobile-number').parent().removeClass('has-error');
		}

		if ($('#mobile-number').parent().hasClass('has-success')) {
			$('#mobile-number').parent().removeClass('has-success');
		}
	});

	$('#mobile-number').focusout(function (e) {
		e.preventDefault();

		let mobileNumber = $('#mobile-number').val();
		if (!validateMobileNumber(mobileNumber)) { // if not valid
			handleValidationError('mobile-number', 'This is a required field. It can only start with 7, 8 or 9 and must have exactly 10 digits.');
		}
		else { // if valid
			$('#mobile-number').parent().addClass('has-success');
			$('#err-mobile-number').empty();
		}
	});

	$('#email-id').focusin(function (e) {
		e.preventDefault();

		if ($('#email-id').parent().hasClass('has-error')) {
			$('#email-id').parent().removeClass('has-error');
		}

		if ($('#email-id').parent().hasClass('has-success')) {
			$('#email-id').parent().removeClass('has-success');
		}
	});

	$('#email-id').focusout(function (e) {
		e.preventDefault();

		let emailId = $('#email-id').val();
		if (!validateEmailId(emailId)) { // if not valid
			handleValidationError('email-id', 'This is an optional field. You can leave it blank or please enter a valid email id.');
		}
		else { // if valid
			$('#email-id').parent().addClass('has-success');
			$('#err-email-id').empty();
		}
	});

	$('#btn-add-biodata').on('click', function (e) {
		e.preventDefault();

		addBiodata();
	});

	$('#btn-reset').on('click', function () {
		resetData();
	});
});

function fetchCities(callback) {
	let url = '../api/External/GetCities?countryCode=101';

	$.ajax({
		method: 'GET'
		, url: url
		, contentType: 'application/json'
		, dataType: 'json'
		, success: function (data, textStatus, jqXhr) {
			callback(data);
		}
		, error: function (jqXhr, textStatus, errorThrown) {

		}
	});
}

function validateDropdown(value) {
	if (isNullOrWhitespace(value)) {
		return false;
	}
	return true;
}

function validateFullname(fullname) {
	if (isNullOrWhitespace(fullname) || !fullname.match(REGEX_FULLNAME)) { //if no fullname or not matching regex
		return false;
	}
	return true;
}

function validateDob(dob) {
	if (isNullOrWhitespace(dob) || !moment(dob, 'YYYY-MM-DD').isValid()) {
		return false;
	}
	return true;
}

function validateBirthTime(birthtime) {
	if (!isNullOrWhitespace(birthtime) && !moment(birthtime, 'HH:mm').isValid()) {
		return false;
	}
	return true;
}

function validateText(value) {
	if (isNullOrWhitespace(value)) {
		return false;
	}
	return true;
}

function validateOptionalNumber(value) {
	if (!isNullOrWhitespace(value) && isNaN(value)) {
		return false;
	}
	return true;
}

function validateNumber(value) {
	if (isNullOrWhitespace(value) || isNaN(value)) {
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
	if (!isNullOrWhitespace(emailId) && !emailId.match(REGEX_EMAIL_ID)) { //if emailid present and not matching regex
		return false;
	}
	return true;
}

function addBiodata() {
	let isValid = true;
	let gender = $('#gender').val().trim();
	let fullname = $('#fullname').val().trim();
	let dob = $('#dob').val();
	let birthtime = $('#birthtime').val();
	let maritalStatus = $('#marital-status').val().trim();
	let native = $('#native').val().trim();
	let birthPlace = $('#birth-place').val().trim();
	let caste = $('#caste').val().trim();
	let heightFt = $('#height-ft').val();
	let heightIn = $('#height-in').val();
	let weight = $('#weight').val();
	let bloodGroup = $('#blood-group').val().trim();
	let manglik = $('#manglik').val().trim();
	let horoscopeMatch = $('#horoscope-match').val().trim();
	let foodHabits = $('#food-habits').val().trim();
	let education = $('#education').val().trim();
	let degrees = $('#degrees').val().trim();
	let educationDetails = $('#education-details').val().trim();
	let occupation = $('#occupation').val().trim();
	let professionSector = $('#professional-sector').val().trim();
	let annualIncome = $('#annual-income').val();
	let professionDetails = $('#profession-details').val().trim();
	let fatherName = $('#father-name').val().trim();
	let motherName = $('#mother-name').val().trim();
	let noOfMarriedBro = $('#no-of-married-bro').val();
	let noOfMarriedSis = $('#no-of-married-sis').val()
	let noOfUnmarriedBro = $('#no-of-unmarried-bro').val();
	let noOfUnmarriedSis = $('#no-of-unmarried-sis').val();
	let familyDetails = $('#family-details').val().trim();
	let mosalName = $('#mosal-name').val().trim();
	let mosalNative = $('#mosal-native').val().trim();
	let address = $('#address').val().trim();
	let city = $('#city').val().trim();
	let mobileNumber = $('#mobile-number').val();
	let emailId = $('#email-id').val().trim();

	if (!validateDropdown(gender)) {
		isValid = false;
		handleDropdownValidationError('gender', 'This is a required field. Please select from the available options.');
	}

	if (!validateFullname(fullname)) { // if not valid
		isValid = false;
		handleValidationError('fullname', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
	}

	if (!validateDob(dob)) { // if not valid
		isValid = false;
		handleValidationError('dob', 'This is a required field. Please select candidate\'s date of birth. Candidate should be above 18 years of age.');
	}

	if (!validateBirthTime(birthtime)) { // if not valid
		isValid = false;
		handleValidationError('birthtime', 'This is an optional field. You can leave it blank or select candidate\'s valid birth time.');
	}

	if (!validateDropdown(maritalStatus)) {
		isValid = false;
		handleDropdownValidationError('marital-status', 'This is a required field. Please select from the available options.');
	}

	if (!validateText(native)) { // if not valid
		isValid = false;
		handleValidationError('native', 'This is a required field. Please enter candidate\'s native place.');
	}

	if (!validateDropdown(caste)) {
		isValid = false;
		handleDropdownValidationError('caste', 'This is a required field. Please select from the available options.');
	}

	if (!validateDropdown(heightFt)) {
		isValid = false;
		handleDropdownValidationError('height-ft', 'This is a required field. Please select from the available options.');
	}

	if (!validateDropdown(heightIn)) {
		isValid = false;
		handleDropdownValidationError('height-in', 'This is a required field. Please select from the available options.');
	}

	if (!validateOptionalNumber(weight)) { // if not valid
		isValid = false;
		handleValidationError('weight', 'This is a an optional field. You can leave it blank or please enter a valid number.');
	}

	if (!validateDropdown(education)) {
		isValid = false;
		handleDropdownValidationError('education', 'This is a required field. Please select from the available options.');
	}

	if (!validateDropdown(occupation)) {
		isValid = false;
		handleDropdownValidationError('occupation', 'This is a required field. Please select from the available options.');
	}


	if (!validateOptionalNumber(annualIncome)) { // if not valid
		isValid = false;
		handleValidationError('annual-income', 'This is an optional field. You can leave it blank or please enter a valid number.');
	}

	if (!validateFullname(fatherName)) { // if not valid
		isValid = false;
		handleValidationError('father-name', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
	}

	if (!validateFullname(motherName)) { // if not valid
		isValid = false;
		handleValidationError('mother-name', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
	}

	if (!validateNumber(noOfMarriedBro)) { // if not valid
		isValid = false;
		handleValidationError('no-of-married-bro', 'This is a required field. Please enter a valid number.');
	}

	if (!validateNumber(noOfMarriedSis)) { // if not valid
		isValid = false;
		handleValidationError('no-of-married-sis', 'This is a required field. Please enter a valid number.');
	}

	if (!validateNumber(noOfunmarriedBro)) { // if not valid
		isValid = false;
		handleValidationError('no-of-unmarried-bro', 'This is a required field. Please enter a valid number.');
	}

	if (!validateNumber(noOfUnmarriedSis)) { // if not valid
		isValid = false;
		handleValidationError('no-of-unmarried-sis', 'This is a required field. Please enter a valid number.');
	}

	if (!validateFullname(mosalName)) { // if not valid
		isValid = false;
		handleValidationError('mosal-name', 'This is a required field. It can contain only alphabets (A to Z) or (a to z) and spaces.');
	}

	if (!validateText(mosalNative)) { // if not valid
		isValid = false;
		handleValidationError('mosal-native', 'This is a required field. Please enter the native place of candidate\'s maternal family.');
	}

	if (!validateText(address)) { // if not valid
		isValid = false;
		handleValidationError('address', 'This is a required field. Please enter the complete address.');
	}

	if (!validateMobileNumber(mobileNumber)) { // if not valid
		isValid = false;
		handleValidationError('mobile-number', 'This is a required field. It can only start with 7, 8 or 9 and must have exactly 10 digits.');
	}

	if (!validateEmailId(emailId)) { // if not valid
		isValid = false;
		handleValidationError('email-id', 'This is an optional field. You can leave it blank or please enter a valid email id.');
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
	$('#gender').selectpicker('val', '');
	$('#marital-status').selectpicker('val', '');
	$('#caste').selectpicker('val', '');
	$('#height-ft').selectpicker('val', '');
	$('#height-in').selectpicker('val', '');
	$('#blood-group').selectpicker('val', '');
	$('#manglik').selectpicker('val', '');
	$('#horoscope-match').selectpicker('val', '');
	$('#food-habits').selectpicker('val', '');
	$('#education').selectpicker('val', '');
	$('#degrees').selectpicker('val', '');
	$('#occupation').selectpicker('val', '');
	$('#professional-sector').selectpicker('val', '');
	$('#city').selectpicker('val', '');
	
	$('.custom-error').empty();

	$('#fullname').parent().removeClass('has-error');
	$('#fullname').parent().removeClass('has-success');

	$('#dob').parent().removeClass('has-error');
	$('#dob').parent().removeClass('has-success');

	$('#birthtime').parent().removeClass('has-error');
	$('#birthtime').parent().removeClass('has-success');

	$('#native').parent().removeClass('has-error');
	$('#native').parent().removeClass('has-success');

	$('#birth-place').parent().removeClass('has-error');
	$('#birth-place').parent().removeClass('has-success');

	$('#weight').parent().removeClass('has-error');
	$('#weight').parent().removeClass('has-success');

	$('#education-details').parent().removeClass('has-error');
	$('#education-details').parent().removeClass('has-success');

	$('#annual-income').parent().removeClass('has-error');
	$('#annual-income').parent().removeClass('has-success');

	$('#profession-details').parent().removeClass('has-error');
	$('#profession-details').parent().removeClass('has-success');

	$('#father-name').parent().removeClass('has-error');
	$('#father-name').parent().removeClass('has-success');

	$('#mother-name').parent().removeClass('has-error');
	$('#mother-name').parent().removeClass('has-success');

	$('#no-of-married-bro').parent().removeClass('has-error');
	$('#no-of-married-bro').parent().removeClass('has-success');

	$('#no-of-married-sis').parent().removeClass('has-error');
	$('#no-of-married-sis').parent().removeClass('has-success');

	$('#no-of-unmarried-bro').parent().removeClass('has-error');
	$('#no-of-unmarried-bro').parent().removeClass('has-success');

	$('#no-of-unmarried-sis').parent().removeClass('has-error');
	$('#no-of-unmarried-sis').parent().removeClass('has-success');

	$('#family-details').parent().removeClass('has-error');
	$('#family-details').parent().removeClass('has-success');

	$('#mosal-name').parent().removeClass('has-error');
	$('#mosal-name').parent().removeClass('has-success');

	$('#mosal-native').parent().removeClass('has-error');
	$('#mosal-native').parent().removeClass('has-success');

	$('#address').parent().removeClass('has-error');
	$('#address').parent().removeClass('has-success');

	$('#mobile-number').parent().removeClass('has-error');
	$('#mobile-number').parent().removeClass('has-success');

	$('#email-id').parent().removeClass('has-error');
	$('#email-id').parent().removeClass('has-success');
	
	$('#err-message').empty();
	$('#err-message').addClass('hide');
}