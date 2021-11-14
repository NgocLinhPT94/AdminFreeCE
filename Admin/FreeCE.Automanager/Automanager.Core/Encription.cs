using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Core
{
    //Thuc hien ma hoa pass, decode base 64
    public class Encription
    {
        //Ma hoa password
        public static string EncryptPassword(string password)
        {
            // hash password
            return SercurityUtils.EncryptBase64(SercurityUtils.EncryptMd5(password), Constant.KeyPassWord);
        }
        //password: tu client; hashpassword: database
        public static bool CheckPassword(string password, string hashPassword)
        {
            return hashPassword.Equals(EncryptPassword(password));
        }
        public static string EncryptCaptcha(string textToBeEncrypted)
        {
            // hash captcha
            return SercurityUtils.EncryptBase64(SercurityUtils.EncryptMd5(textToBeEncrypted),
                Constant.CaptchaPassWord);
        }

        public static bool CheckCaptcha(string captcha, string hashCaptcha)
        {
            return hashCaptcha.Equals(EncryptCaptcha(captcha));
        }
    }
}
