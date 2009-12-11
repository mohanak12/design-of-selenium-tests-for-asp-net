function HomeIgnition()
{
}

HomeIgnition.prototype.CreateAndRun = function()
{
    var baseUrl = $("#hdnBaseUrl").val();

    var containerBuilder = new JsInject.ContainerBuilder();
    containerBuilder.Register("Services", function(c) {return new Services(baseUrl);});
    containerBuilder.Register("UserNameWidget", function(c) {return new UserNameWidget();});
    containerBuilder.Register("HomeMediator", function(c) {return new HomeMediator(c.Resolve("Services"), c.Resolve("UserNameWidget"));});

    var container = containerBuilder.Create();

    var mediator = container.Resolve("HomeMediator");

    mediator.DocumentLoaded();
};