const hamburgerMenu = document.querySelector('.hamburgerMenu');
const navbar = document.querySelector('.navbar');
const navbarBottom = document.getElementById("mobileNav");

hamburgerMenu.addEventListener('click', () => {
    hamburgerMenu.classList.toggle('active');
    navbar.classList.toggle('active');

    if (hamburgerMenu.classList.contains('active')) {
        navbarBottom.style.display = "flex";
    } else {
        navbarBottom.style.display = "none";
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
        hamburgerMenu.style.display = "none";
        navbarBottom.style.display = "flex";
    }

}