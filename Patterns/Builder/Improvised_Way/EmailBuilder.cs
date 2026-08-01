using System;
using System.Collections.Generic;
using System.Linq;

public enum EmailPriority
{
    Normal,
    High,
    Low
}

public sealed record Email(
    string To,
    string Subject,
    IReadOnlyList<string> Cc,
    IReadOnlyList<string> Bcc,
    string? Body,
    EmailPriority Priority,
    IReadOnlyList<string> Attachments)
{
    public override string ToString()
    {
        return $"Email{{to='{To}', subject='{Subject}', cc=[{string.Join(", ", Cc)}], bcc=[{string.Join(", ", Bcc)}], body='{Body}', priority='{Priority.ToString().ToLower()}', attachments=[{string.Join(", ", Attachments)}]}}";
    }

    public sealed class Builder
    {
        private readonly string to;
        private readonly string subject;
        private readonly List<string> ccList = new();
        private readonly List<string> bccList = new();
        private string? bodyText;
        private EmailPriority priorityValue = EmailPriority.Normal;
        private readonly List<string> attachmentList = new();

        public Builder(string to, string subject)
        {
            this.to = ValidateRequiredString(to, nameof(to));
            this.subject = ValidateRequiredString(subject, nameof(subject));
        }

        public Builder Cc(string cc)
        {
            ccList.Add(ValidateRequiredString(cc, nameof(cc)));
            return this;
        }

        public Builder Bcc(string bcc)
        {
            bccList.Add(ValidateRequiredString(bcc, nameof(bcc)));
            return this;
        }

        public Builder Body(string body)
        {
            bodyText = body;
            return this;
        }

        public Builder Priority(EmailPriority priority)
        {
            priorityValue = priority;
            return this;
        }

        public Builder Attachment(string attachment)
        {
            attachmentList.Add(ValidateRequiredString(attachment, nameof(attachment)));
            return this;
        }

        public Email Build()
        {
            ValidateEmailAddress(to);
            ValidateEmailAddressList(ccList, "Cc");
            ValidateEmailAddressList(bccList, "Bcc");

            return new Email(
                To: to,
                Subject: subject,
                Cc: ccList.ToList(),
                Bcc: bccList.ToList(),
                Body: bodyText,
                Priority: priorityValue,
                Attachments: attachmentList.ToList()
            );
        }

        private static string ValidateRequiredString(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{paramName} cannot be null or empty.", paramName);

            return value;
        }

        private static void ValidateEmailAddress(string email)
        {
            if (!email.Contains("@") || email.StartsWith("@") || email.EndsWith("@"))
                throw new ArgumentException($"Invalid email address: {email}");
        }

        private static void ValidateEmailAddressList(IEnumerable<string> emails, string label)
        {
            foreach (var email in emails)
            {
                if (!email.Contains("@") || email.StartsWith("@") || email.EndsWith("@"))
                    throw new ArgumentException($"Invalid {label} email address: {email}");
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        var email1 = new Email.Builder("alice@example.com", "Meeting Tomorrow")
            .Body("Let's meet at 10am in conference room B.")
            .Build();

        var email2 = new Email.Builder("bob@example.com", "Project Update")
            .Cc("carol@example.com")
            .Cc("dave@example.com")
            .Bcc("manager@example.com")
            .Body("Attached is the Q4 report.")
            .Priority(EmailPriority.High)
            .Attachment("q4-report.pdf")
            .Attachment("summary.xlsx")
            .Build();

        Console.WriteLine(email1);
        Console.WriteLine();
        Console.WriteLine(email2);
    }
}