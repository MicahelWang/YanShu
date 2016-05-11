﻿using System.ComponentModel.DataAnnotations;

namespace WeChatPortal.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "电子邮电")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }
}