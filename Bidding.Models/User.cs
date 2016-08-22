using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bidding.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Cannot be null")]
        //[Display(Name = "用户组ID")]
        //public int GroupID { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "显示名")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Cannot be null")]
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 用户状态<br />
        /// 0正常，1锁定，2未通过邮件验证，3未通过管理员
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistrationTime { get; set; }

        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 上次登陆IP
        /// </summary>
        public DateTime LoginIP { get; set; }

        //public virtual UserGroup Group { get; set; }


    }
}
