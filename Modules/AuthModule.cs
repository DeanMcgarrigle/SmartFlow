using System.Linq;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Validation;
using SmartFlow.DataAccess;
using SmartFlow.Extensions;
using SmartFlow.ViewModels;

namespace SmartFlow.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(SmartFlowContext context)
            : base("/login")
        {
            Get["/"] = _ => View["Auth/Login", new LoginViewModel()];
            Post["/"] = _ =>
            {
                var model = this.Bind<LoginViewModel>();
                var result = this.Validate(model);
                if (result.IsValid)
                {
                    var user = context.Users.FirstOrDefault(x => x.UserName == model.Username);

                    if (user != null &&
                                        MachSecure.BusinessObjects.Encryption.ValidatePassword(model.Password, user.Password))
                        return this.LoginAndRedirect(user.RecordId);

                    this.AddValidationError("", "The username or password you entered are incorrect");
                    model.Errors = result.Errors;
                    return View["Auth/Login", model];
                }

                model.Errors = result.Errors;
                return View["Auth/Login", model];
            };
            Get["/logout"] = _ => this.LogoutAndRedirect("~/");
        }
    }
}