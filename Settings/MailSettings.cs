﻿namespace VerdonSale.Settings
{
    public class MailSettings
    {
        public string Username { get; set; } = "yusufolayinka09@gmail.com";
        public string Password { get; set; }
        public int Port { get; set; } = 587;
        public string FromEmail { get; set; } = "yusufolayinka09@gmail.com";
        public string Host { get; set; } = "smtp.gmail.com";
    }
}
