let mainNav = document.getElementById("js-menu");
let accountNav = document.getElementById("js-account-menu");

let navBarToggle = document.getElementById("js-navbar-toggle");

let logobkground = document.getElementById("logo");

$('.AdvancedSearch').toggle();
$('#logout').on('click', function () { $('#logoutForm').submit(); })
$('#Search').on('click', function () { $('#SearchBar').submit(); })
$('.backBtn').on('click', function(){ history.go(-1);})
$('#toggleSearch').on('click', function(){
    $('.AdvancedSearch').slideToggle("slow", function(){});
});

navBarToggle.addEventListener("click", function () {
    mainNav.classList.toggle("active");
});