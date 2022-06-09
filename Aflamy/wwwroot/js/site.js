$(document).ready(function () {
    $('#CategoryTable').DataTable();
});

$(document).ready(function () {
    $('#MoviesTable').DataTable();
});


$(function () {
    $.fn.selectpicker.Constructor.BootstrapVersion = '5.1.3';

    $('select').selectpicker();
});
