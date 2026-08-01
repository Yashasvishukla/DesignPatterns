using System;
using System.Collections.Generic;

class Email
{
    public string To { get; }
    public string Subject { get; }
    public List<string> Cc { get; }
    public List<string> Bcc { get; }
    public string Body { get; }
    public string Priority { get; }
    public List<string> Attachments { get; }


    /// <summary>
    /// Private constructor that initializes the Email object using the builder pattern.
    /// </summary>
    /// <param name="builder"></param>
    private Email(Builder builder)
    {
        To = builder.To;
        Subject = builder.Subject;
        Cc = new List<string>(builder.CcList);
        Bcc = new List<string>(builder.BccList);
        Body = builder.BodyText;
        Priority = builder.PriorityText;
        Attachments = new List<string>(builder.AttachmentList);
    }

    public override string ToString()
    {
        return $"Email{{to='{To}', subject='{Subject}', cc=[{string.Join(", ", Cc)}], bcc=[{string.Join(", ", Bcc)}], body='{Body}', priority='{Priority}', attachments=[{string.Join(", ", Attachments)}]}}";
    }

    public class Builder
    {
        internal string To;
        internal string Subject;
        internal List<string> CcList = new List<string>();
        internal List<string> BccList = new List<string>();
        internal string BodyText;
        internal string PriorityText = "normal";
        internal List<string> AttachmentList = new List<string>();


        /// <summary>
        /// Builder constructor that initializes the required fields for the Email object.
        /// We have two required fields: To and Subject. The rest are optional and can be set using the builder methods.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        public Builder(string to, string subject)
        {
            To = to;
            Subject = subject;
        }

        public Builder Cc(string cc)
        {
            CcList.Add(cc);
            return this;
        }

        public Builder Bcc(string bcc)
        {
            BccList.Add(bcc);
            return this;
        }

        public Builder SetBody(string body)
        {
            BodyText = body;
            return this;
        }

        public Builder SetPriority(string priority)
        {
            PriorityText = priority;
            return this;
        }

        public Builder Attachment(string attachment)
        {
            AttachmentList.Add(attachment);
            return this;
        }

        public Email Build()
        {
            return new Email(this);
        }
    }
}