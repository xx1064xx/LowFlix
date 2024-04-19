const movieAddFields = document.getElementById('movieAddFields');
const addButton = document.getElementById('addButton');
const filmCopyNumberInput = document.getElementById('filmCopyNumberInput');
var filmData = null;
var scannedFilmCopies = [];

document.addEventListener("DOMContentLoaded", function () {

    fetchressources();

});

function addFilm() {

    var number = filmCopyNumberInput.value;

    if (number != "") {
        addOrRemoveFilmCopyFields(number);
    }

    

}

function addOrRemoveFilmCopyFields(number) {

    filmCopyNumberInput.value = "";

    if (searchFilmCopy(number)) {

        if (searchNumber(number)) {

            console.log("ist bereits vorhanden");

            rebuildFilmCopyFields();


        }
        else {


            movieAddFields.innerHTML += `<div class="formGroup">
                <label>Film</label>
                <label name="FilmCopies[${scannedFilmCopies.length}].FilmCopyNumber" class="inputField">${number}</label>
                <input name="FilmCopies[${scannedFilmCopies.length}].FilmCopyNumber" class="inputField" value="${number}" type="hidden"></input>
            </div>`;

            scannedFilmCopies.push(number);

        }

        console.log(scannedFilmCopies);
    }

    

};

function rebuildFilmCopyFields() {

    movieAddFields.innerHTML = ``;

    for (let i = 0; i < scannedFilmCopies.length; i++) {

        movieAddFields.innerHTML += `<div class="formGroup">
            <label>Film</label>
            <label name="FilmCopies[${scannedFilmCopies.length}].FilmCopyNumber" class="inputField" value="${scannedFilmCopies[i]}">${scannedFilmCopies[i]}</label>
            <input name="FilmCopies[${scannedFilmCopies.length}].FilmCopyNumber" class="inputField" value="${scannedFilmCopies[i]}" type="hidden">${scannedFilmCopies[i]}</input>
        </div>`;

    }

}

function searchNumber(value) {
    for (let i = 0; i < scannedFilmCopies.length; i++) {
        if (scannedFilmCopies[i] === value) {

            scannedFilmCopies.splice(i, 1);

            return true;
        }
    }
    return false;
}

function searchFilmCopy(value) {

    var isValid = false;

    for (let i = 0; i < filmData.length; i++) {
        if (filmData[i].filmNumber.toString() === value) {

            isValid = true;
        }
    }

    if (isValid) {
        return true;
    } else {
        return false;
    }
}

function fetchressources() {
    fetch('/Bookings/AutoCreate?handler=FilmCopyList')
        .then(response => response.json())
        .then(data => {

            filmData = data;
            console.log(data);

        })
        .catch(error => console.error('Error:', error));


}