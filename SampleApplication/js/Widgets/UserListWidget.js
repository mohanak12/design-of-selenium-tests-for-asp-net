function UserListWidget()
{}

UserListWidget.prototype.Empty = function()
{
    $("#holderUsers").empty();
};

UserListWidget.prototype.Render = function(users)
{
    $("#holderUsers").setTemplateElement("templateUsers");
    $("#holderUsers").processTemplate(users);
};