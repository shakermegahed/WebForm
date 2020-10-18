using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Net;
using System.Data;
using System.Configuration;
using System.Web;

namespace DAL
{
    public static class GeneralMethods
    {
        public static string ConvertToSearchWord(string word)
        {
            try
            {
                if (word == "")
                    return "";
                string x = "";
                foreach (char ch in word.ToCharArray())
                {
                    switch (ch)
                    {
                        case 'أ':
                            x += "[أ,آ,ا,إ]";
                            break;
                        case 'إ':
                            x += "[أ,آ,ا,إ]";
                            break;
                        case 'ا':
                            x += "[أ,آ,ا,إ]";
                            break;
                        case 'آ':
                            x += "[أ,آ,ا,إ]";
                            break;
                        case 'ؤ':
                            x += "[و,ؤ]";
                            break;
                        case 'و':
                            x += "[و,ؤ]";
                            break;
                        case 'ئ':
                            x += "[ي,ئ,ى]";
                            break;
                        case 'ى':
                            x += "[ي,ئ,ى]";
                            break;
                        case 'ي':
                            x += "[ي,ئ,ى]";
                            break;
                        case 'ة':
                            x += "[ه,ة]";
                            break;
                        case 'ه':
                            x += "[ه,ة]";
                            break;
                        default:
                            x += ch.ToString();
                            break;

                    }

                }
                return x;
            }
            catch { return ""; }
        }
        public static string ConvertToDateString(string Date)
        {
            try
            {
                DateTime dt = DateTime.Parse(Date);
                return dt.Day + "/" + dt.Month + "/" + dt.Year;
            }
            catch { return ""; }
        }
        public static bool DeleteRestorVisible(object Active, string type)
        {
            try
            {
                return !(bool)Active == Convert.ToBoolean(type);
            }
            catch
            {
                return false;
            }
        }
        public static string GetYoutube(object Vurl)
        {
            if (string.IsNullOrEmpty(Vurl.ToString()))
                return string.Empty;
            else
            {
                try
                {
                    string CutStr = Vurl.ToString().Remove(0, Vurl.ToString().IndexOf("?v=") + 3);
                    string VideoYoutube = CutStr.Split('&')[0];
                    return "<iframe width=\"300\" height=\"220\" src=\"http://www.youtube.com/embed/" + VideoYoutube + "\" frameborder=\"0\" allowfullscreen></iframe>";
                }
                catch { return string.Empty; }
            }
        }
        public static string GetYoutubeBig(object Vurl)
        {
            if (string.IsNullOrEmpty(Vurl.ToString()))
                return string.Empty;
            else
            {
                try
                {
                    string CutStr = Vurl.ToString().Remove(0, Vurl.ToString().IndexOf("?v=") + 3);
                    string VideoYoutube = CutStr.Split('&')[0];
                    return "<iframe width=\"640\" height=\"480\" src=\"http://www.youtube.com/embed/" + VideoYoutube + "\" frameborder=\"0\" allowfullscreen></iframe>";
                }
                catch { return string.Empty; }
            }
        }
        public static string GetYoutubeThum(object Vurl)
        {
            if (string.IsNullOrEmpty(Vurl.ToString()))
                return string.Empty;
            else
            {
                try
                {
                    string CutStr = Vurl.ToString().Remove(0, Vurl.ToString().IndexOf("?v=") + 3);
                    string VideoYoutube = CutStr.Split('&')[0];
                    return "http://i1.ytimg.com/vi/" + VideoYoutube + "/hqdefault.jpg";
                }
                catch { return string.Empty; }
            }
        }

        public static string FormatString(object str)
        {
            try
            {
                int len = 70;
                if (len != 0)
                {
                    if (str.ToString().Length >= len - 3)
                    {
                        int cut = len;
                        while (str.ToString()[cut] == ' ') { cut++; }
                        return (str.ToString().Substring(0, cut) + "...").Replace("\r\n", "<br />");
                    }
                    else
                    {
                        //more.Visible = false;
                        return str.ToString().Replace("\r\n", "<br />");
                    }
                }
                else { return str.ToString().Replace("\r\n", "<br />"); }
            }
            catch { return str.ToString(); }
        }
        public static string FormatString200(object str)
        {
            try
            {
                int len = 200;
                if (len != 0)
                {
                    if (str.ToString().Length >= len - 3)
                    {
                        int cut = len;
                        while (str.ToString()[cut] == ' ') { cut++; }
                        return (str.ToString().Substring(0, cut) + "...").Replace("\r\n", "<br />");
                    }
                    else
                    {
                        //more.Visible = false;
                        return str.ToString().Replace("\r\n", "<br />");
                    }
                }
                else { return str.ToString().Replace("\r\n", "<br />"); }
            }
            catch { return str.ToString(); }
        }
        public static string CutString(object Content, int CharNum)
        {
            string Result = "";
            if (Content != null && Content.ToString().Length > CharNum)
            {
                Result = Regex.Replace(Content.ToString(), "<.*?>", string.Empty);
                if (Result.Length > CharNum)
                {
                    Result = Result.Remove(CharNum);
                    int x = Result.LastIndexOf(' ');
                    Result = Result.Remove(x);
                    Result += "...";
                }
            }
            else
            {
                Result = Content.ToString();
            }
            return Result;
        }
        //[ValidateAntiForgeryToken]
        //[ValidateInput(true)]
        public static string SendMessage(string mailTo, string mailFrom, string Password, string mailFromDisplayName, string mailCc, string subject, string body, string EmailSignature, System.Net.Mail.Attachment attachment)
        {
            try
            {
                if (!string.IsNullOrEmpty(mailTo))
                {
                    SmtpClient SmtpMail = new SmtpClient();
                    SmtpMail.Host = "smtp.office365.com";
                    SmtpMail.Port = 25;
                    SmtpMail.EnableSsl = true;
                    SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpMail.UseDefaultCredentials = false;
                    SmtpMail.Timeout = 20000;
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    SmtpMail.Credentials = new System.Net.NetworkCredential(mailFrom, Password);
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(mailFrom, mailFromDisplayName);
                    mail.To.Add(mailTo);
                    mail.Attachments.Add(attachment);
                    if (!string.IsNullOrEmpty(mailCc))
                    {
                        mail.CC.Add(mailCc);
                    }
                    mail.Subject = subject;
                    mail.Body = "<table width=\"100%\"><tr><td align=\"left\" dir='ltr'><span style=\"font-size: 12pt;\">" + body + "</span></td></tr><tr><td align=\"center\">" + EmailSignature + "</td></tr></table>";

                    mail.IsBodyHtml = true;
                    SmtpMail.Send(mail);
                }
                return mailTo;
            }
            catch { return ""; }
        }

        //[ValidateAntiForgeryToken]
        //[ValidateInput(true)]
        public static string SendMessage(string mailTo, string mailFrom, string Password, string mailFromDisplayName, string mailCc, string subject, string body, string EmailSignature)
        {
            try
            {
                if (!string.IsNullOrEmpty(mailTo))
                {
                    SmtpClient SmtpMail = new SmtpClient();
                    SmtpMail.Host = "smtp.stackmail.com";
                    SmtpMail.Port = 25;
                    SmtpMail.EnableSsl = false;
                    SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpMail.UseDefaultCredentials = false;
                    SmtpMail.Timeout = 20000;
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    SmtpMail.Credentials = new System.Net.NetworkCredential(mailFrom, Password);

                    /////////////////////////////////////////////////////////////////////////////
                    //SmtpMail.Host = "smtpout.secureserver.net";
                    //SmtpMail.Port = 25;
                    //SmtpMail.EnableSsl = false;
                    //SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //SmtpMail.UseDefaultCredentials = false;
                    //SmtpMail.Timeout = 20000;
                    //SmtpMail.Credentials = new System.Net.NetworkCredential("test@me-tags.com", "mail123");
                    MailMessage mail = new MailMessage();

                    mail.From = new MailAddress(mailFrom, mailFromDisplayName);
                    mail.To.Add(mailTo);
                    if (!string.IsNullOrEmpty(mailCc))
                    {
                        mail.CC.Add(mailCc);
                    }
                    //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mail.Subject = subject;
                    mail.Body = "<table width=\"100%\"><tr><td align=\"left\" dir='ltr'><span style=\"font-size: 12pt;\">" + body + "</span></td></tr><tr><td align=\"center\">" + EmailSignature + "</td></tr></table>";

                    mail.IsBodyHtml = true;
                    SmtpMail.Send(mail);
                }
                return mailTo;
            }
            catch { return ""; }
        }

        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyz";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public static string CreateRandomName(int PasswordLength)
        {
            string _allowedChars = "abcdefghijkmnopqrstuvwxyz";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
    }
}
