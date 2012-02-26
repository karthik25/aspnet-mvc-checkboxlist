$(document).ready(function () {
    $('.chkClickable').click(function () {
        if ($(this).is(':checked')) {
            $(this).next('.hdnStatus').val('true');
        }
        else {
            $(this).next('.hdnStatus').val('false');
        }
    });
});
