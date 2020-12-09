// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;

    $(".next").click(function () {

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();

        //Add Class Active
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

        //show the next fieldset
        next_fs.show();
        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                next_fs.css({ 'opacity': opacity });
            },
            duration: 600
        });
    });

    $(".previous").click(function () {

        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();

        //Remove class active
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

        //show the previous fieldset
        previous_fs.show();

        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                previous_fs.css({ 'opacity': opacity });
            },
            duration: 600
        });
    });

    $('.radio-group .radio').click(function () {
        $(this).parent().find('.radio').removeClass('selected');
        $(this).addClass('selected');
    });

    $(".submit").click(function () {
        return false;
    })

});
<<<<<<< HEAD
function search() {
    const houseNumber = document.getElementById("houseNumber").value;
    const streetName = document.getElementById("streetName").value.toUpperCase();
    const zipCode = document.getElementById("zip").value; 
=======

//added api function manually
function addressApiSearch() {
    const houseNumber = document.getElementById("houseNumber").value;
    const streetName = document.getElementById("streetName").value.toUpperCase();
    const zipCode = document.getElementById("zip").value;
>>>>>>> origin/WhatItDoBoo

    const searchURL = `https://data.wprdc.org/api/3/action/datastore_search?filters={\"PROPERTYZIP\": \"${zipCode}\", \"PROPERTYHOUSENUM\":\"${houseNumber}\", \"PROPERTYADDRESS\":\"${streetName}\"}&resource_id=518b583f-7cc8-4f60-94d0-174cc98310dc&fields=\"_id\"`;

    console.log(searchURL);

    var request = new XMLHttpRequest();

    request.open('GET', searchURL);

    request.onload = function () {
        var data = JSON.parse(this.response);
<<<<<<< HEAD
        console.log(data);
        console.log(data.result);
        if (data.result.records.length == 0) {
            document.getElementById("FoundProperty").innerHTML = "Property not found."
        }
        else if (data.result.records.length == 1) {
            var property = data.result.records[0];
            document.getElementById("FoundProperty").innerHTML = property._id;
        }

=======

        if (data.result.records.length == 1) {
            var property = data.result.records[0];
            document.getElementById("AddressID").value = property._id;
        }
>>>>>>> origin/WhatItDoBoo
    }

    request.send();
}