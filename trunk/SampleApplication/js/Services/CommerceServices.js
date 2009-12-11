/*globals $, ServiceProxy */
function Services(baseUrl)
{
    this.baseUrl = baseUrl;
}

Services.prototype.GetVendor = function(vendorId, callback)
{
    this.Callback("Services/Guard.asmx", 'GetUserName', 
        {
        }, 
        callback, function() { } );  
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