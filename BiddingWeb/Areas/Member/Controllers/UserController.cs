using Bidding.BLL;
using Bidding.Common;
using Bidding.Models;
using BiddingWeb.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiddingWeb.Areas.Member.Controllers
{
    public class UserController : Controller
    {
        // GET: Member/User
        public ActionResult Index()
        {
            return View();
        }

        ///// <summary>
        ///// 验证码
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult VerificationCode()
        //{
        //    string verificationCode = Security.CreateVerificationText(6);
        //    Bitmap _img = Security.CreateVerificationImage(verificationCode, 160, 30);
        //    _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    TempData["VerificationCode"] = verificationCode.ToUpper();
        //    return null;
        //}

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != register.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
                return View(register);
            }
            if (ModelState.IsValid)
            {
                UserService userService = new UserService();
                if (userService.Exist(register.UserName)) ModelState.AddModelError("UserName", "用户名已存在");
                else
                {
                    User _user = new User()
                    {
                        UserName = register.UserName,
                        //默认用户组代码写这里
                        DisplayName = register.DisplayName,
                        Password = Security.Sha256(register.Password),
                        //邮箱验证与邮箱唯一性问题
                        Email = register.Email,
                        //用户状态问题
                        Status = 0,
                        RegistrationTime = System.DateTime.Now
                    };
                    _user = userService.Add(_user);
                    if (_user.UserID > 0)
                    {
                        return Content("注册成功！");
                        //AuthenticationManager.SignIn();
                    }
                    else { ModelState.AddModelError("", "注册失败！"); }
                }
            }
            return View(register);
        }
    }
}