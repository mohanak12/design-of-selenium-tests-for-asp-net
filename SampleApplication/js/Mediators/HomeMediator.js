function HomeMediator(
        services,
        userNameWidget,
        addUserWidget,
        userListWidget)
{
    var me = this;

    // injections
    this.services = services;
    this.userNameWidget = userNameWidget;
    this.addUserWidget = addUserWidget;
    this.userListWidget = userListWidget;

    //events
    me.addUserWidget.AddUser = function(name, password) { me.AddUser(name, password); };
}

HomeMediator.prototype.DocumentLoaded = function()
{
    var me = this;

    this.services.GetCurrentUser(function (msg) {
          me.userNameWidget.SetUserName(msg.d);
    });

    me.BindUsers();
};

HomeMediator.prototype.AddUser = function(name, password)
{
    var me = this;
    
    this.services.AddUser(name, password, function (users) {
          me.BindUsers()
    });   
};

HomeMediator.prototype.BindUsers = function()
{
    var me = this;
    
    this.services.GetAllUsers(function (users) {
          me.userListWidget.Render(users.d);
    });    
};