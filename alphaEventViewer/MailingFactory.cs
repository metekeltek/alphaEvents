using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using alphaEventViewer.Models;

namespace alphaEventViewer
{
    public class MailingFactory
    {
        public MailingFactory()
        {
            Chilkat.Global glob = new Chilkat.Global();
            glob.UnlockBundle("Anything for 30-day trial");
        }
        
        public void SendVerificationMail(ParticipantRegistrationModel participation, EventItemEntity eventItem, Guid participationId)
        {
            Chilkat.MailMan mailman = new Chilkat.MailMan();
            
            mailman.SmtpHost = "smtp.1und1.de";
            mailman.SmtpUsername = "tnverification@devalpha.de";
            mailman.SmtpPassword = "8s4EnhvljJDSWonVTShv";
            
            Chilkat.Email email = new Chilkat.Email();

            email.Subject = "Anmeldung bestätigen";
            //Paste compressed Html Template here

            email.SetHtmlBody($"<!doctype html><html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\"><head> <title> </title> <!--[if !mso]><!-- --> <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"> <!--<![endif]--> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> <style type=\"text/css\"> #outlook a {{ padding: 0; }} .ReadMsgBody {{ width: 100%; }} .ExternalClass {{ width: 100%; }} .ExternalClass * {{ line-height: 100%; }} body {{ margin: 0; padding: 0; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; }} table, td {{ border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; }} img {{ border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; }} p {{ display: block; margin: 13px 0; }} </style> <!--[if !mso]><!--> <style type=\"text/css\"> @media only screen and (max-width:480px) {{ @-ms-viewport {{ width: 320px; }} @viewport {{ width: 320px; }} }} </style> <!--<![endif]--> <!--[if mso]> <xml> <o:OfficeDocumentSettings> <o:AllowPNG/> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml> <![endif]--> <!--[if lte mso 11]> <style type=\"text/css\"> .outlook-group-fix {{ width:100% !important; }} </style> <![endif]--> <style type=\"text/css\"> @media only screen and (min-width:480px) {{ .mj-column-per-100 {{ width: 100% !important; max-width: 100%; }} }} </style> <style type=\"text/css\"> @media only screen and (max-width:480px) {{ table.full-width-mobile {{ width: 100% !important; }} td.full-width-mobile {{ width: auto !important; }} }} </style></head><body> <div style=\"\"> <!--[if mso | IE]> <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"\" style=\"width:600px;\" width=\"600\" > <tr> <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\"> <![endif]--> <div style=\"Margin:0px auto;max-width:600px;\"> <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"width:100%;\"> <tbody> <tr> <td style=\"direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;\"> <!--[if mso | IE]> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> <tr> <td class=\"\" style=\"vertical-align:top;width:600px;\" > <![endif]--> <div class=\"mj-column-per-100 outlook-group-fix\" style=\"font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"vertical-align:top;\" width=\"100%\"> <tr> <td align=\"center\" style=\"font-size:0px;padding:20px;word-break:break-word;\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"border-collapse:collapse;border-spacing:0px;\"> <tbody> <tr> <td style=\"width:70px;\"> <img height=\"auto\" src=\"https://www.alphadata.de/wp-content/uploads/2019/06/alphalogo1024x1024.png\" style=\"border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;\" width=\"70\" /> </td> </tr> </tbody> </table> </td> </tr> <tr> <td style=\"font-size:0px;padding:10px 25px;word-break:break-word;\"> <p style=\"border-top:solid 4px #054E9B;font-size:1;margin:0px auto;width:100%;\"> </p> <!--[if mso | IE]> <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-top:solid 4px #054E9B;font-size:1;margin:0px auto;width:550px;\" role=\"presentation\" width=\"550px\" > <tr> <td style=\"height:0;line-height:0;\"> &nbsp; </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td align=\"center\" style=\"font-size:0px;padding:10px 25px;padding-bottom:15px;word-break:break-word;\"> <div style=\"font-family:helvetica;font-size:23px;line-height:1;text-align:center;color:#054E9B;\"> Vielen Dank für Ihre Buchung! </div> </td> </tr> <tr> <td align=\"left\" style=\"font-size:0px;padding:10px 25px;padding-bottom:15px;word-break:break-word;\"> <div style=\"font-family:helvetica;font-size:18px;line-height:28px;text-align:left;color:#054E9B;\"> Hier können Sie nochmal Ihre Daten überprüfen und die Anmeldung bestätigen: </div> </td> </tr> <tr> <td align=\"left\" style=\"font-size:0px;padding:10px 25px;padding-bottom:30px;word-break:break-word;\"> <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\" style=\"cellspacing:0;color:#054E9B;font-family:helvetica;font-size:16px;line-height:29px;table-layout:auto;width:100%;\"> <tr> <td style=\"padding: 0 6px;\"><b>Event</b></td> </tr> <tr> <td style=\"padding: 0 9px;\">Titel</td> <td style=\"padding: 0 0 0 9px;\">{eventItem.Title}</td> </tr> <tr> <td style=\"padding: 0 9px;\">Beginn</td> <td style=\"padding: 0 0 0 9px;\">{eventItem.Beginning}</td> </tr> <tr> <td style=\"padding: 0 9px;\">Ende</td> <td style=\"padding: 0 0 0 9px;\">{eventItem.End}</td> </tr> <tr> <td style=\"padding: 0 9px;\">Preis</td> <td style=\"padding: 0 0 0 9px;\">{eventItem.FullPrice}</td> </tr> </table> </td> </tr> <tr> <td align=\"left\" style=\"font-size:0px;padding:10px 25px;padding-bottom:30px;word-break:break-word;\"> <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\" style=\"cellspacing:0;color:#054E9B;font-family:helvetica;font-size:16px;line-height:29px;table-layout:auto;width:100%;\"> <tr> <td style=\"padding: 0 6px;\"><b>Teilnehmer</b></td> </tr> <tr> <td style=\"padding: 0 9px;\">Name</td> <td style=\"padding: 0 0 0 9px;\">{participation.FirstName} {participation.LastName}</td> </tr> <tr> <td style=\"padding: 0 9px;\">Addresse</td> <td style=\"padding: 0 0 0 9px;\">{participation.Street} {participation.ZipCode} {participation.City}</td> </tr> <tr> <td style=\"padding: 0 9px;\">Telefon</td> <td style=\"padding: 0 0 0 9px;\">{participation.Phone}</td> </tr> </table> </td> </tr> <tr> <td align=\"center\" vertical-align=\"middle\" style=\"font-size:0px;padding:10px 25px;word-break:break-word;\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"border-collapse:separate;line-height:100%;\"> <tr> <td align=\"center\" bgcolor=\"#f45e43\" role=\"presentation\" style=\"border:none;border-radius:3px;cursor:auto;padding:10px 25px;background:#f45e43;\" valign=\"middle\"> <a href=\"https://localhost:5001/confirm/{participationId}\" style=\"background:#f45e43;color:white;font-family:Helvetica;font-size:13px;font-weight:normal;line-height:120%;Margin:0;text-decoration:none;text-transform:none;\" target=\"_blank\"> Anmeldung bestätigen </a> </td> </tr> </table> </td> </tr> </table> </div> <!--[if mso | IE]> </td> </tr> </table> <![endif]--> </td> </tr> </tbody> </table> </div> <!--[if mso | IE]> </td> </tr> </table> <![endif]--> </div></body></html>");
            
            email.From = "alphaEvents <tnverification@devalpha.de>";
            bool success = email.AddTo("", participation.EMailAddress);
            
            success = mailman.SendEmail(email);
            if (success != true)
            {
                Debug.WriteLine(mailman.LastErrorText);
                return;
            }
            success = mailman.CloseSmtpConnection();
            if (success != true)
            {
                Debug.WriteLine("Connection to SMTP server not closed cleanly.");
            }

            Debug.WriteLine("Mail Sent!");
        }

        public void SendConfirmationMail(JobContactConfirmationEntity participation, string eventItemTitle)
        {
            Chilkat.MailMan mailman = new Chilkat.MailMan();

            mailman.SmtpHost = "smtp.1und1.de";
            mailman.SmtpUsername = "tnverification@devalpha.de";
            mailman.SmtpPassword = "8s4EnhvljJDSWonVTShv";
        

            Chilkat.Email email = new Chilkat.Email();

            email.Subject = "Anmeldung erfolgreich";
            //Paste compressed Html Template here
            
            email.SetHtmlBody($"<!doctype html><html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\"><head> <title> </title> <!--[if !mso]><!-- --> <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"> <!--<![endif]--> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> <style type=\"text/css\"> #outlook a {{ padding: 0; }} .ReadMsgBody {{ width: 100%; }} .ExternalClass {{ width: 100%; }} .ExternalClass * {{ line-height: 100%; }} body {{ margin: 0; padding: 0; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; }} table, td {{ border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; }} img {{ border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; }} p {{ display: block; margin: 13px 0; }} </style> <!--[if !mso]><!--> <style type=\"text/css\"> @media only screen and (max-width:480px) {{ @-ms-viewport {{ width: 320px; }} @viewport {{ width: 320px; }} }} </style> <!--<![endif]--> <!--[if mso]> <xml> <o:OfficeDocumentSettings> <o:AllowPNG/> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml> <![endif]--> <!--[if lte mso 11]> <style type=\"text/css\"> .outlook-group-fix {{ width:100% !important; }} </style> <![endif]--> <style type=\"text/css\"> @media only screen and (min-width:480px) {{ .mj-column-per-100 {{ width: 100% !important; max-width: 100%; }} }} </style> <style type=\"text/css\"> @media only screen and (max-width:480px) {{ table.full-width-mobile {{ width: 100% !important; }} td.full-width-mobile {{ width: auto !important; }} }} </style></head><body> <div style=\"\"> <!--[if mso | IE]> <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"\" style=\"width:600px;\" width=\"600\" > <tr> <td style=\"line-height:0px;font-size:0px;mso-line-height-rule:exactly;\"> <![endif]--> <div style=\"Margin:0px auto;max-width:600px;\"> <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"width:100%;\"> <tbody> <tr> <td style=\"direction:ltr;font-size:0px;padding:20px 0;text-align:center;vertical-align:top;\"> <!--[if mso | IE]> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> <tr> <td class=\"\" style=\"vertical-align:top;width:600px;\" > <![endif]--> <div class=\"mj-column-per-100 outlook-group-fix\" style=\"font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"vertical-align:top;\" width=\"100%\"> <tr> <td align=\"center\" style=\"font-size:0px;padding:20px;word-break:break-word;\"> <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"border-collapse:collapse;border-spacing:0px;\"> <tbody> <tr> <td style=\"width:70px;\"> <img height=\"auto\" src=\"https://www.alphadata.de/wp-content/uploads/2019/06/alphalogo1024x1024.png\" style=\"border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;\" width=\"70\" /> </td> </tr> </tbody> </table> </td> </tr> <tr> <td style=\"font-size:0px;padding:10px 25px;word-break:break-word;\"> <p style=\"border-top:solid 4px #054E9B;font-size:1;margin:0px auto;width:100%;\"> </p> <!--[if mso | IE]> <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-top:solid 4px #054E9B;font-size:1;margin:0px auto;width:550px;\" role=\"presentation\" width=\"550px\" > <tr> <td style=\"height:0;line-height:0;\"> &nbsp; </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td align=\"center\" style=\"font-size:0px;padding:10px 25px;padding-bottom:15px;word-break:break-word;\"> <div style=\"font-family:helvetica;font-size:20px;line-height:1;text-align:center;color:#054E9B;\"> Vielen Dank für Ihre Buchung! </div> </td> </tr> <tr> <td align=\"left\" style=\"font-size:0px;padding:10px 25px;padding-bottom:15px;word-break:break-word;\"> <div style=\"font-family:helvetica;font-size:17px;line-height:28px;text-align:left;color:#054E9B;\"> Ihre Anmeldung für die Veranstaltung {eventItemTitle} war erfolgreich! </div> </td> </tr> </table> </div> <!--[if mso | IE]> </td> </tr> </table> <![endif]--> </td> </tr> </tbody> </table> </div> <!--[if mso | IE]> </td> </tr> </table> <![endif]--> </div></body></html>");
           
            email.From = "alphaEvents <tnverification@devalpha.de>";
            bool success = email.AddTo("", participation.EMailAddress);

            success = mailman.SendEmail(email);
            if (success != true)
            {
                Debug.WriteLine(mailman.LastErrorText);
                return;
            }
            success = mailman.CloseSmtpConnection();
            if (success != true)
            {
                Debug.WriteLine("Connection to SMTP server not closed cleanly.");
            }

            Debug.WriteLine("Mail gesendet!");
        }
    }
}
