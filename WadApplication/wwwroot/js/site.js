let mainNav = document.getElementById("js-menu");
let accountNav = document.getElementById("js-account-menu");

let navBarToggle = document.getElementById("js-navbar-toggle");

$('#logout').on('click', function () { $('#logoutForm').submit(); })
$('#Search').on('click', function () { $('#SearchBar').submit(); })

navBarToggle.addEventListener("click", function () {
    mainNav.classList.toggle("active");
    accountNav.classList.toggle("active");
});