Email email1 = new Email.Builder("alice@example.com", "Meeting Tomorrow")
                .SetBody("Let's meet at 10am in conference room B.")
                .Build();

        Email email2 = new Email.Builder("bob@example.com", "Project Update")
                .Cc("carol@example.com")
                .Cc("dave@example.com")
                .Bcc("manager@example.com")
                .SetBody("Attached is the Q4 report.")
                .SetPriority("high")
                .Attachment("q4-report.pdf")
                .Attachment("summary.xlsx")
                .Build();

        Console.WriteLine(email1);
        Console.WriteLine();
        Console.WriteLine(email2);