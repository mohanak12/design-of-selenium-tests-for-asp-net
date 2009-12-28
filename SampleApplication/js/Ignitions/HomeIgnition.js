function HomeIgnition()
{
}

HomeIgnition.prototype.CreateAndRun = function()
{
    var baseUrl = $("#hdnBaseUrl").val();

    var containerBuilder = new JsInject.ContainerBuilder();
    containerBuilder.Register("Services", function(c) {return new Services(baseUrl);});
    containerBuilder.Register("UserNameWidget", function(c) {return new UserNameWidget();});
    containerBuilder.Register("AddUserWidget", function(c) {return new AddUserWidget();});
    containerBuilder.Register("UserListWidget", function(c) {return new UserListWidget();});
    containerBuilder.Register("AjaxErrorWidget", function(c) {return new AjaxErrorWidget();});
    
    containerBuilder.Register("HomeMediator", function(c) {return new HomeMediator(
            c.Resolve("Services"),
            c.Resolve("UserNameWidget"),
            c.Resolve("AddUserWidget"),
            c.Resolve("UserListWidget"),
            c.Resolve("AjaxErrorWidget")
            );});

    var container = containerBuilder.Create();

    var mediator = container.Resolve("HomeMediator");

    mediator.DocumentLoaded();
};