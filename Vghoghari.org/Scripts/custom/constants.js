﻿var PROTOCOL = window.location.protocol;
var URL = window.location.host;
var BASEURL = PROTOCOL + '//' + URL;

var REGEX_FULLNAME = /^(-?([A-Za-z].\s)?([A-Za-z][A-Za-z]*)\s?)+([A-Za-z]'([A-Za-z][A-Za-z]*))?$/;
var REGEX_USERNAME = /^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}$/;
var REGEX_PASSWORD = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/;
var REGEX_MOBILE_NUMBER = /^[789]\d{9}$/;
var REGEX_EMAIL_ID = /^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$/;

var IMAGE_TYPE = ['image/jpeg', 'image/pjpeg', 'image/png']