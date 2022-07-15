$(".class_residential_selector").click(function () {
    window.location.href = "/Residential/2/0/" + this.id;
});

$(".class_rental_selector").click(function () {
    window.location.href = "/Rental/2/0/" + this.id;
});

$("#id_nav_back").click(function () {
    history.go(-1);
});