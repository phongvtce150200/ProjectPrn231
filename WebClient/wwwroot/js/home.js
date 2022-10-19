var signInButton = document.getElementById('signIn');
var registerButton = document.getElementById('Register');
var formSignIn = document.getElementById('loginForm');
var formRegister = document.getElementById('registerForm');

function showForm(form) {
    form.style.display = "block";
}
function hideForm(form){
    form.style.display = "none";
}

registerButton.addEventListener('click', () =>{
    showForm(formRegister);
    hideForm(formSignIn);
    console.log("okokokoko");
    
})
signInButton.addEventListener('click', () =>{
    showForm(formSignIn);
    hideForm(formRegister);
})

var showForm = function(){
    document.getElementById('registerForm').style.display='block';
    document.getElementById('loginForm').style.display='block';
}

