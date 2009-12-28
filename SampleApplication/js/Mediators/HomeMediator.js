function HomeMediator(
        services,
        userNameWidget,
        addUserWidget,
        userListWidget,
        ajaxErrorWidget)
{
    var me = this;

    // injections
    this.services = services;
    this.userNameWidget = userNameWidget;
    this.addUserWidget = addUserWidget;
    this.userListWidget = userListWidget;
    this.ajaxErrorWidget = ajaxErrorWidget;

    //events
    me.addUserWidget.AddUser = function(name, password) { me.AddUser(name, password); };
}

HomeMediator.prototype.DocumentLoaded = function()
{
    var me = this;

    this.services.GetCurrentUser(function (msg) {
            me.userNameWidget.SetUserName(msg.d);
    },
    function(msg) {
            me.ajaxErrorWidget.SetError(msg.Message);
    });

    me.BindUsers();
};

HomeMediator.prototype.AddUser = function(name, password)
{
    var me = this;

    this.services.AddUser(name, password,
        function (msg) {
            if(msg.d.Success)
            {
                me.BindUsers();
            }
            else
            {
                 me.addUserWidget.SetError(msg.d.Message);              
            }
        },
         function(msg) {
            me.ajaxErrorWidget.SetError(msg.Message);
        });
};

HomeMediator.prototype.BindUsers = function()
{
    var me = this;
    
    this.services.GetAllUsers(function (users) {
          me.userListWidget.Render(users.d);
    },
    function(msg) {
            me.ajaxErrorWidget.SetError(msg.Message);
    });
};