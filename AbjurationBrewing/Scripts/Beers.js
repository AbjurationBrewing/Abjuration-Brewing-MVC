$(document).ready(function () {
    $('#beersTable').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        ajax: {
            'url': './Beers/Grid',
            "type": "POST",
            'data': function (d) {

            }
        },
        pageLength: 10,
        //dom: 'rt<"bottom"pi><"clear">',
        language: {
        //    'info': '_TOTAL_ Beers',
            'infoEmpty': '',
            'infoFiltered': '',
            'emptyTable': 'No Beers Found',
            'zeroRecords': 'No Beers Found'
        },
        'rowCallback': function (row, data, index) {
            var beerId = data[3];
            var version = data[2];

            $(row).click(function (e) {
                openRecipe(beerId, version);
            }).hover(function () {
                $(this).addClass('hoveredRow');
            }, function () {
                $(this).removeClass('hoveredRow');
            });
        },
        order: [[0, 'asc']],
        columns: [
                { "name": "Abbreviation" },
                { "name": "Name" },
                {
                    "name": "Current Version",
                    "orderable": false,
                }
        ]
    });
});

function openRecipe(beerId, version) {
    $.fancybox({
        'href': '/PartialView/BeerRecipe?beerId=' + beerId + '&version=' + version,
        'type': 'ajax',
        'closeOnEscape': true,
        'autoScale': true,
        'transitionIn': 'elastic',
        'transitionOut': 'elastic',
        'centerOnScroll': true
    });
}