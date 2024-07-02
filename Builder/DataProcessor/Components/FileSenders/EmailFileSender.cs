using DataProcessor.FileLocations;
using System.Net.Mail;
using System.Net;

namespace DataProcessor.Components.FileSenders;
public class EmailFileSender: IFileSender
{
    public void SendFile(IFileLocations fileLocations)
    {
        // Return early if processed file is missing
        if (!File.Exists(fileLocations.ProcessingPathFileExtension))
        {
            throw new ArgumentException($"File does not exist at {fileLocations.ProcessingPathFileExtension}");
        }

        // As the details below are made up
        bool testing = true;

        if (testing) 
        {
            return;
        }

        // Constuct email message
        var mailMessage = new MailMessage
        {
            From = new MailAddress("from@example.com"),
            Subject = fileLocations.StartingFileName,
            Body = $"Please find {fileLocations.StartingFileName} attached."
        };

        // Select file and destination
        Attachment attachment = new(fileLocations.ProcessingPathFileExtension);
        mailMessage.To.Add(fileLocations.DestinationLocation);
        mailMessage.Attachments.Add(attachment);

        // Need SMTP server details, but this has
        SmtpClient smtpClient = new("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("username", "password"),
            EnableSsl = true
        };

        // Send
        smtpClient.Send(mailMessage);
    }
}
