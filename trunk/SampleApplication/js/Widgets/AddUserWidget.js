function AddUserWidget()
{
    var me = this;
    
    $("#btnAddUser").click(function()
        {
            me.FireAddUser($("#txtName").val(), $("#txtPassword").val());
            return false;
        });
    
}

AddUserWidget.prototype.SetError = function(msg)
{
    $("#lblError").html(msg);
};


AddUserWidget.prototype.FireAddUser = function(name, password)
{
    if(this.AddUser !== undefined)
    {
        this.AddUser(name, password);
    }
};