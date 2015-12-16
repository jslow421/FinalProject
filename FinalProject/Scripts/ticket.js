
$(function () {
    console.log("Ready");

    $('#date').datepicker();
    $('#datetimepicker4').datetimepicker();

    $('#dialog').dialog({ autoOpen: false });

    $('#tradeButton').click(function () {
        $("#dialog").dialog("open");
        console.log($('#tradeTicket').val());
    });

    $('#dialogCancel').click(function () {
        $('#dialog').dialog("close");
    });

    $('#dialogConfirm').click(function () {
        console.log("Submitting Form");
        $('#trade').submit();
    });

    $('#create').click(function () {
        console.log("Create Form");
        var time = $('#time').val().trim();
        var isValid = timeValidation(time);

        if (isValid) {
            alert("Valid")
            $('#createForm').submit();
        }
    });

    function timeValidation(time) {
        var pattern = new RegExp("([0-9]):([0-9])([0-9])");
        var result = pattern.test(time);

        if (result) {
            console.log(true);
            return true;
        } else {
            console.log(false);
            return false;
        }
    }

    $('#createForm').validate({
        rules: {
            date: {
                required: true,
                date: true
            },
            time: {
                required: true,
                equalTo: /([0-9]):([0-9])([0-9])/
            }
        }
    });
});