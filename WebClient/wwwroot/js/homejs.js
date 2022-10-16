const RegisterButton = document.getElementById("Register")
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

RegisterButton.addEventListener('click', () => {
	container.classList.add("form-rigt-register");
});

signInButton.addEventListener('click', () => {
	container.classList.remove("form-rigt-login");
});