
$(function () {
    console.log("Ready");

    $('#date').datepicker();

    $('#dialog').dialog({ autoOpen: false });

    $('#tradeTicket').click(function () {
        $("#confirmTrade").dialog("open");
    });


});