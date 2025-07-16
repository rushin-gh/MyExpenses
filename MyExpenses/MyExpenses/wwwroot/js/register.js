﻿function ValidateRegistrationForm() {

    let usernameInput = document.getElementById('usernameInput');
    let passwordInput = document.getElementById('passwordInput');

    let usernameErr = document.getElementById('username-err');
    let passwordErr = document.getElementById('password-err');

    let isValid = true;
    console.log(usernameInput.value);
    if (usernameInput.value.length < 6) {
        usernameErr.innerText = 'username should contain more than 5 chars';
        isValid = false;
    }

    console.log(passwordInput.value.length);
    if (passwordInput.value.length < 8) {
        passwordErr.innerHTML = 'password should contain more than 7 chars';
        isValid = false;
    }

    return isValid;
}

function resetErrors() {
    let usernameErr = document.getElementById('username-err');
    let passwordErr = document.getElementById('password-err');

    usernameErr.innerText = '';
    passwordErr.innerText = '';
}