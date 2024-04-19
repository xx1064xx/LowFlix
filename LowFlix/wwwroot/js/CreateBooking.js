const filmSelector = document.getElementById('FilmSelector');
const movieAddFields = document.getElementById('movieAddFields');
const filmCopySelector = document.getElementById('FilmCopySelector');
var pedaloData = null;
var counter = 0;

var FilmCopyNumbers = [];

filmSelector.addEventListener("change", function () {



    filmCopySelector.innerHTML = '';

    pedaloData.forEach(option => {

        if (option.filmId == filmSelector.value.toLowerCase()) {

            filmCopySelector.innerHTML += `<option value="${option.filmCopyId}">${option.filmNumber}</option>`;
        }

    });


});


document.addEventListener("DOMContentLoaded", function () {

    fetchressources();

});

function addFilm() {

    var number = filmCopySelector.options[filmCopySelector.selectedIndex].text;

    console.log(number);

    if (filmCopySelector.value != "") {
        //var number = filmCopySelector.value;

        FilmCopyNumbers.push(number);

        movieAddFields.innerHTML += `<div class="formGroup">
                <label asp-for="Booking.RentalDate"></label>
                <label class="inputField">${number}</label>
                <input type="hidden" name="FilmCopies[${counter}].FilmNumber" value="${number}" />
            </div>`;

        counter++;
    }

    

}

function fetchressources() {
    fetch('/Bookings/Create?handler=FilmCopyList')
        .then(response => response.json())
        .then(data => {

            pedaloData = data;
            console.log(data);


            // fill options

            filmCopySelector.innerHTML = '';

            data.forEach(option => {

                if (option.filmId == filmSelector.value.toLowerCase()) {

                    filmCopySelector.innerHTML += `<option value="${option.filmCopyId}">${option.filmNumber}</option>`;
                }

            });





        })
        .catch(error => console.error('Error:', error));


}