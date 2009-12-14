function UserListWidget()
{}

UserListWidget.prototype.Render = function(users)
{
    $("#holderUsers").setTemplateElement("templateUsers");
    $("#holderUsers").processTemplate(users);
};