using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PIEIMS
{
    //工具类,存放功能函数和常量值
    class utils
    {
        //数据库连接字符串;
        public static string ConnectStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C#code\win_final_work\PIEIMS\PIEIMS\App_Data\App_Database.mdf;Integrated Security=True";

        //对用户输入的密码进行MD5加密;
        public static string Get_MD5(string plain_txt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] source_data = System.Text.Encoding.UTF8.GetBytes(plain_txt);
            byte[] target_data = md5.ComputeHash(source_data);
            string MD5_pwd = "";
            for(int i = 0; i < target_data.Length; i++)
            {
                MD5_pwd += target_data[i].ToString("x2");
            }
            return MD5_pwd;
        }
    }
}
