/* Copyright 2022 CENTURY 21 Coast to Coast. All rights reserved. */

homeTimeout = setTimeout(returnToHome, 180000);

$("#body").click(function () {
    clearTimeout(homeTimeout);
    homeTimeout = setTimeout(returnToHome, 180000);
});

$(".residential_listing_data")
    .click(function () {
    window.location.href = "/Residential/Details/" + this.id;
}).mouseover(function () {
    $(".residential_listing_data").css('cursor', 'pointer');
});

$(".rental_listing_data")
    .click(function () {
    window.location.href = "/Rental/Details/" + this.id;
}).mouseover(function () {
    $(".rental_listing_data").css('cursor', 'pointer');
});

function returnToHome() {
    window.location.href = "/Home/Locked";
}

function homeScreen() {
    window.location.href = "/Home";
}