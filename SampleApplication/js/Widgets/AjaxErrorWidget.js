function AjaxErrorWidget()
{
    $("#lblAjaxErrorMessage").hide();
}

AjaxErrorWidget.prototype.SetError = function(msg)
{
    $("#lblAjaxErrorMessage").show();
    $("#lblAjaxErrorMessage").html($("#lblAjaxErrorMessage").html() + "<br>" + msg);
};
