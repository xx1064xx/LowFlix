const hamburgerMenu = document.querySelector('.hamburgerMenu');
const lowFlixLogo = document.querySelector('.lowFlixIndexLogo');
const body = document.querySelector('body');
const header = document.querySelector('header');
const navbar = document.querySelector('.navbar');
const navbarBottom = document.getElementById("mobileNav");

hamburgerMenu.addEventListener('click', () => {

    hamburgerMenu.classList.toggle('active');
    navbar.classList.toggle('active');
    lowFlixLogo.classList.toggle('active');
    body.classList.toggle('active');

    if (hamburgerMenu.classList.contains('active')) {
        navbarBottom.style.display = "flex";
        //body.style.overflow = "hidden";
    } else {
        navbarBottom.style.display = "none";
        //body.style.overflow = "visible";
    }

})

window.addEventListener("resize", handleScreenChange);
document.addEventListener("DOMContentLoaded", function () {

    handleScreenChange();

});

function handleScreenChange() {
    var screenWidth = window.innerWidth;

    if (screenWidth <= 768) {

        hamburgerMenu.style.display = "flex";

        if (hamburgerMenu.classList.contains('active')) {
            navbarBottom.style.display = "flex";
        } else {
            navbarBottom.style.display = "none";
        }


    } else {

        hamburgerMenu.classList.remove('active');
        navbar.classList.remove('active');
        lowFlixLogo.classList.remove('active');
        body.classList.remove('active');
        hamburgerMenu.style.display = "none";
        navbarBottom.style.display = "flex";
    }

}