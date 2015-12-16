
$(function () {
    console.log("Ready");

    $('#date').datetimepicker();

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

   
    
});