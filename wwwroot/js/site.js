// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#table-contact').DataTable();
});

$(document).ready(function () {
    $('#table-user').DataTable();
});

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$(document).ready(function () {
    $('.btn-total-contacts').click(function () {
        var userId = $(this).attr('user-id');
        $.ajax({
            type: 'GET',
            url: '/User/ListContactsbyUserId/' + userId,
            success: function (result) {
                $("#listUserContacts").html(result);
                $('#userContactsModal').modal();
            }
        });
    });
});
