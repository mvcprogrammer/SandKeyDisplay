/* Copyright 2013 CENTURY 21 Coast to Coast. All rights reserved. */

$.ajaxSetup({ cache: true });

function ajaxImage(url, elm) {
    var xhr = new XMLHttpRequest(),
        blob, objectURL, arrayBufferView;

    xhr.open('GET', url, true);
    xhr.responseType = 'arraybuffer';
    xhr.addEventListener('load', function () {
        if (xhr.status === 200) {
            arrayBufferView = new Uint8Array(xhr.response),
            blob = new Blob([arrayBufferView], { 'type': 'image\/jpeg' }),
            objectURL = window.URL.createObjectURL(blob);
            elm.src = objectURL;
        }
    }, false);
    xhr.send();
}

$(document).ready(function () {

    $(".property-photo-small").click(function () {
        console.log("small photo clicked.")
        ajaxImage(this.id, document.getElementById('id_photo_holder'));
        });

    $("#id_property_go_back").click(function () {
        history.go(-1);
    });

    $(function () {
        $('#id_show_keyboard').click(function (e) {
            e.preventDefault();
            $('#id_contact_keyboard').bPopup({
                speed: 650,
                transition: 'slideIn'
            });
        });
    });

    $(".keyboard-key").click(function () {
        var email_address = $('#id_email_input').val();
        email_address += this.id;
        $('#id_email_input').val(email_address);
    });

    $(".keyboard-command").click(function () {
        var command = this.id;
        switch (command) {
            case "ESC":
            case "CLS":
                $('#id_email_input').val("");
                $('#id_contact_keyboard').bPopup().close();
                break;

            case "CLR":
                $('#id_email_input').val("");
                break;

            case "AT":
                var email_address = $('#id_email_input').val();
                email_address += "@";
                $('#id_email_input').val(email_address);
                break;

            case "DLT":
            case "BKS":
                var email_address = $('#id_email_input').val();
                email_address = email_address.substring(0, (email_address.length - 1));
                $('#id_email_input').val(email_address);
                break;

            case "SHL":
            case "SHR":
                break;

            case "SEND":
                $("#id_send_email_res_details").click();
                break;

            default:
                alert("Unhandled Keyboard Command");
        }
    });

    var email_address = "";

    function EmailCloseThankYou() {
        $('#email_thank_you').bPopup().close();
    };

    function ClearStatus() {
        $('#id_email_input').val(email_address);
    };

    $("#id_send_email_res_details").click(function () {
        email_address = $('#id_email_input').val();
        var mls_id = $('#id_mls_num').val();
        var url = "/EMail/Residential/";
        url += email_address + "/";
        url += mls_id;

        $.ajax({
            type: "GET",
            url: url,
            data: "",
            beforeSend: function () {
                $('#id_email_input').val("Processing property info request...");
            },
            statusCode: {
                400: function () {
                    $('#id_email_input').val("Bad request, Please verify your email...");
                    setTimeout(ClearStatus, 3000);
                },
                404: function () {
                    $('#id_email_input').val("Error processing request, please try again...");
                    setTimeout(ClearStatus, 3000);
                    return false;
                },
                500: function () {
                    $('#id_email_input').val("ERROR, please try again...");
                    setTimeout(ClearStatus, 3000);
                    return false;
                }
            },
            success: function (data) {
                $('#id_email_input').val("Processing......");
            },
            error: function (data) {
                $('#id_email_input').val("Send Failed, please try again...");
                setTimeout(ClearStatus, 3000);
                return false;
            }
        }).done(function () {
            $('#id_email_input').val("");
            email_address = "";
            $('#id_contact_keyboard').bPopup().close();
            $('#email_thank_you').bPopup({ speed: 650, transition: 'fadeIn' });
            setTimeout(EmailCloseThankYou, 3000);
        })

        return false;
    });

    $("#id_send_email_rnt_details").click(function () {
        email_address = $('#id_email_input').val();
        var mls_id = $('#id_mls_num').val();
        var url = "/EMail/Rental";
        url += email_address + "/";
        url += mls_id;

        $.ajax({
            type: "GET",
            url: url,
            data: "",
            beforeSend: function () {
                $('#id_email_input').val("Processing rental info request...");
            },
            statusCode: {
                400: function () {
                    $('#id_email_input').val("Bad request, Please verify your email...");
                    setTimeout(ClearStatus, 3000);
                },
                404: function () {
                    $('#id_email_input').val("Error processing request, please try again...");
                    setTimeout(ClearStatus, 3000);
                    return false;
                },
                500: function () {
                    $('#id_email_input').val("ERROR, please try again...");
                    setTimeout(ClearStatus, 3000);
                    return false;
                }
            },
            success: function (data) {
                $('#id_email_input').val("Processing......");
            },
            error: function (data) {
                $('#id_email_input').val("Send Failed, please try again...");
                setTimeout(ClearStatus, 3000);
                return false;
            }
        }).done(function () {
            $('#id_email_input').val("");
            email_address = "";
            $('#id_contact_keyboard').bPopup().close();
            $('#email_thank_you').bPopup({ speed: 650, transition: 'fadeIn' });
            setTimeout(EmailCloseThankYou, 3000);
        })

        return false;
    });

    $(function () {
        $('#id_property_contact_phone').click(function (e) {
            e.preventDefault();
            $('#id_contact_numpad').bPopup({
                speed: 650,
                transition: 'slideIn'
            });
        });
    });

    $(".num-key").click(function () {
        var phone_num = $('#id_res_phone_input').val();
        var next_value = this.id.substring(4, 5);
        phone_num += next_value;
        $('#id_res_phone_input').val(phone_num);
    });

    $(".num-command").click(function () {
        var command = this.id;
        switch (command) {

            case "num-cls":
                $('#id_res_phone_input').val("");
                $('#id_contact_numpad').bPopup().close();
                break;

            case "num-clr":
                $('#id_res_phone_input').val("");
                break;

            case "num-clr":
                $('#id_res_phone_input').val("");
                break;

            case "num-bks":
                var res_phone = $('#id_res_phone_input').val();
                res_phone = res_phone.substring(0, (res_phone.length - 1));
                $('#id_res_phone_input').val(res_phone);
                break;

            default:
                alert("Unhandled Keyboard Command");
        }
    });

    function resPhoneCloseThankYou() {
        $('#res_phone_thank_you').bPopup().close();
    };

    $("#id_res_send_phone_contact_request").click(function () {
        var res_phone = $('#id_res_phone_input').val();
        var mls_id = $('#id_mls_num').val();
        var url = "/Email/ContactRequest/";
        url += res_phone + "/";
        url += mls_id;

        $.ajax({
            type: "GET",
            url: url,
            data: "",
            success: function (data) {
                $('#id_res_phone_input').val("");
                $('#id_contact_numpad').bPopup().close();
                $('#res_phone_thank_you').bPopup({ speed: 650, transition: 'fadeIn' });
                setTimeout(resPhoneCloseThankYou, 3000);
            }
        });

        return false;
    });
});