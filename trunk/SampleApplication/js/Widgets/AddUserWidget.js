function AddUserWidget()
{
    var me = this;
    
    $("#btnAddUser").click(function()
        {
            me.FireAddUser($("#txtName").val(), $("#txtPassword").val());
            return false;
        });
    
}

AddUserWidget.prototype.FireAddUser = function(name, password)
{
    if(this.AddUser !== undefined)
    {
        this.AddUser(name, password);
    }
};