using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using InmueblateWeb.Models;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;

namespace InmueblateWeb.Controllers
{
    public class AccountController : Controller
    {
        Service servicio = new Service();
        SuperUsuarioEN supEN = null;
        UsuarioEN usuEN = null;
        InmobiliariaEN inmEN = null;
        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            ViewBag.Tipo = "Sin modelo";
            return View();
        }


        //ObtenerUsuario?
        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            ViewBag.Tipo = "Con modelo";
            ViewBag.URL = returnUrl;
            ViewBag.Nombre = model.UserName;
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    supEN = servicio.NuevoInmueblate_SuperUsuario_ObtenerUsuarioPorEmail(model.UserName);
                    
                    Session["idUsuario"] = supEN.Id;
                    Session["nombreUsuario"] = supEN.Nombre;
                    Session["telefUusario"] = supEN.Telefono;
                    Session["emailUsuario"] = supEN.Email;
                    Session["direcUsuario"] = supEN.Direccion;
                    Session["poblaUsuario"] = supEN.Poblacion;
                    Session["CPUsuario"] = supEN.CodigoPostal;
                    Session["paisUsuario"] = supEN.Pais;
                    Session["valoUsuario"] = supEN.ValoracionMedia;
                    switch (supEN.GetType().Name)
                    {
                        case "UsuarioEN": usuEN = (UsuarioEN)supEN;
                            Session["muroUsuario"] = supEN.Muro.Id;
                            Session["apellUsuario"] = usuEN.Apellidos;
                            Session["nifUsuario"] = usuEN.Nif;
                            Session["fechaUsuario"] = usuEN.FechaNacimiento;
                            Session["privaUsuario"] = usuEN.Privacidad;
                            Session["tipoUsuario"] = "Usuario";
                            Session["listaAmigos"] = usuEN.ListaAmigos;
                            return RedirectToAction("Index", "HomeUS", new { id = supEN.Id, area = "Usuarios" });
                            //return RedirectToAction("Index", "HomeUSPE", new { area = "UsuariosPerfil" });
                            //break;
                        case "InmobiliariaEN": inmEN = (InmobiliariaEN)supEN;
                            Session["cifUsuaio"] = inmEN.Cif;
                            Session["descUsuario"] = inmEN.Descripcion;
                            Session["tipoUsuario"] = "Inmobiliaria";
                            return RedirectToAction("Index", "HomeIN", new { id = supEN.Id, area = "Inmobiliaria" });
                            //break;
                        default: ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.");
                            break;
                    }
                    
                    
                }
                else
                {
                    ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioCP usu = new UsuarioCP();
                int id = usu.RegistrarUsuario(model.Name,model.Apellidos, model.Nif, model.Email, model.Direccion, model.Poblacion, model.CodigoPostal, model.Pais, model.Password, "", model.Telefono, Convert.ToDateTime(model.FechaNacimiento), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Amigos);

                if (id != -1)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    supEN = servicio.NuevoInmueblate_SuperUsuario_ObtenerUsuarioPorEmail(model.Email);

                    Session["idUsuario"] = supEN.Id;
                    Session["nombreUsuario"] = supEN.Nombre;
                    Session["telefUusario"] = supEN.Telefono;
                    Session["emailUsuario"] = supEN.Email;
                    Session["direcUsuario"] = supEN.Direccion;
                    Session["poblaUsuario"] = supEN.Poblacion;
                    Session["CPUsuario"] = supEN.CodigoPostal;
                    Session["paisUsuario"] = supEN.Pais;
                    Session["valoUsuario"] = supEN.ValoracionMedia;
                    Session["muroUsuario"] = supEN.Muro;
                    switch (supEN.GetType().Name)
                    {
                        case "UsuarioEN": usuEN = (UsuarioEN)supEN;
                            Session["apellUsuario"] = usuEN.Apellidos;
                            Session["nifUsuario"] = usuEN.Nif;
                            Session["fechaUsuario"] = usuEN.FechaNacimiento;
                            Session["privaUsuario"] = usuEN.Privacidad;
                            Session["tipoUsuario"] = "Usuario";
                            Session["listaAmigos"] = usuEN.ListaAmigos;
                            return RedirectToAction("Index", "Home", new { area = "" });
                            //return RedirectToAction("Index", "HomeUS", new { id = (int)Session["idUsuario"],  area = "Usuarios" });
                        //return RedirectToAction("Index", "HomeUSPE", new { area = "UsuariosPerfil" });
                        //break;
                        case "InmobiliariaEN": inmEN = (InmobiliariaEN)supEN;
                            Session["cifUsuaio"] = inmEN.Cif;
                            Session["descUsuario"] = inmEN.Descripcion;
                            Session["tipoUsuario"] = "Inmobiliaria";
                            return RedirectToAction("Index", "Home", new { area = "" });
                            //return RedirectToAction("Index", "HomeIN", new { id = (int)Session["idUsuario"], area = "Inmobiliaria" });
                        //break;
                        default: ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.");
                            break;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "La creación del usuario ha fallado. Pongasé en contacto con el administrador si el problema persiste.");
                }
                // Attempt to register the user
                //MembershipCreateStatus createStatus;
                //Membership.CreateUser(model.Name, model.Password, model.Email, null, null, true, null, out createStatus);
                //
                //if (createStatus == MembershipCreateStatus.Success)
                //{
                //    FormsAuthentication.SetAuthCookie(model.Name, false /* createPersistentCookie */);
                //    return RedirectToAction("Index", "Home");//areausuarios index home
                //    //dameuserconid
                //}
                //else
                //{
                //    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
