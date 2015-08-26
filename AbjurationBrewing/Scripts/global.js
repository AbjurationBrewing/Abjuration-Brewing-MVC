$(document).ready(function () {
    if ($.cookie("ageOk") !== 't') {
        $.fancybox({
            'href': '#ageConfirmDiv',
            'modal': true,
            'closeOnEscape': false,
            'autoSize': true,
            'autoResize': true,
            'autoCenter': true
        });

        $('#ageNo').on('click', function (event) {
            event.stopPropagation();
            $.removeCookie("ageOk");
            window.location.replace('http://www.google.com');
        });

        $('#ageYes').on('click', function (event) {
            event.stopPropagation();
            $.cookie("ageOk", "t", { expires: 1 });
            $.fancybox.close();
        });
    }
});

function formatDate(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return date.getMonth() + 1 + "/" + date.getDate() + "/" + date.getFullYear() + "  " + strTime;
}

function escapeRegExp(string) {
    return string.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
}

function replaceAll(string, find, replace) {
    return string.replace(new RegExp(escapeRegExp(find), 'g'), replace);
}

function getQueryStringValue(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}