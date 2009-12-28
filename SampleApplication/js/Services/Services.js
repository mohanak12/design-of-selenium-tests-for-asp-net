/*globals $, ServiceProxy */
function Services(baseUrl)
{
    this.baseUrl = baseUrl;
}

Services.prototype.GetCurrentUser = function(callback, failed)
{
    this.SimpleCallback("Services/Guard.asmx", 'GetCurrentUser', callback, failed );
};

Services.prototype.GetAllUsers = function(callback, failed)
{
    this.SimpleCallback("Services/Users.asmx", 'GetAll', callback, failed);
};

Services.prototype.AddUser = function(name, password, callback, failed)
{
    this.Callback("Services/Users.asmx", 'AddUser', {name: name, password: password}, callback, failed);
};

Services.prototype.SimpleCallback = function(serviceName, methodName, succeed, failed)
{
    this.Callback(serviceName, methodName, {}, succeed, failed);
};

Services.prototype.Callback = function(serviceName, methodName, input, succeed, failed)
{
    var svcProxy = new ServiceProxy(this.baseUrl + serviceName);
  
    svcProxy.invoke(methodName,
            input, 
            succeed,
            failed,
            true);
};