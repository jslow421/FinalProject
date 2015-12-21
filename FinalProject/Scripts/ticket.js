
$(function () {
    console.log("Ready");

    $('#date').datetimepicker();

    $('#dialog').dialog({ autoOpen: false });

    $('#tradeTable').on('click', '.tradeButton', function () {
        $("#dialog").dialog("open");
        console.log($(this.id));
        console.log($('#tradeTicket').val(this.id));
    });

  /*  $('.tradeButton').click(function () {
        $("#dialog").dialog("open");
        console.log($('#tradeTicket').val());
    });
    */
    $('#dialogCancel').click(function () {
        $('#dialog').dialog("close");
    });

    $('#dialogConfirm').click(function () {
        console.log("Submitting Form");
        $('#trade').submit();
    });

   
    
});