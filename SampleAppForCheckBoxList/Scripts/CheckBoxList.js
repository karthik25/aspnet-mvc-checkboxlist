$(document).ready(function () {
    $('.chkClickable').click(function () {
        $(this).next('.hdnStatus').val($(this).is(':checked'));
    });
});
