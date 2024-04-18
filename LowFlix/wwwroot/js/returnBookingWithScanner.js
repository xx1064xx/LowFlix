
const typeHiddenSpace = document.getElementById('typeHiddenSpace');
var movieNumberFields = document.querySelectorAll('.tableRow .filmNumberField');
const filmCopyNumberInput = document.getElementById('filmCopyNumberInput');
var filmCopyNumbers = [];

document.addEventListener("DOMContentLoaded", function () {

    movieNumberFields.forEach(function (movieNumberField) {

        filmCopyNumbers.push(movieNumberField.textContent.trim());

    });
    buildInputHidden();
    

});

function buildInputHidden() {

    typeHiddenSpace.innerHTML = ``;

    for (var i = 0; i < filmCopyNumbers.length; i++) {

        typeHiddenSpace.innerHTML += `<input name="FilmCopies[${i}].FilmNumber" value="${filmCopyNumbers[i]}" type="hidden"></input>`

    }



}

function removeFilm() {

    var filmCopyNumber = filmCopyNumberInput.value;

    movieNumberFields.forEach(function (movieNumberField) {
        
        if (movieNumberField.textContent.trim() === filmCopyNumber) {

            var index = filmCopyNumbers.indexOf(movieNumberField.textContent.trim());

            filmCopyNumbers.splice(index, 1);

            buildInputHidden();

            movieNumberField.parentNode.remove(); 
        }
    });

    filmCopyNumberInput.value = '';

}



