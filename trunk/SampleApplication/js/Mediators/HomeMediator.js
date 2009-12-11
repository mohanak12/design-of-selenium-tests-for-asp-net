function HomeMediator(
        services,
        userNameWidget)
{

    // injections
    this.services = services;
    this.userNameWidget = userNameWidget;
}

HomeMediator.prototype.DocumentLoaded = function()
{
    var me = this;

    this.services.GetCurrentUser(function (msg) {
          me.userNameWidget.SetUserName(msg.d);
    });
};


