using System;
using System.Collections.Generic;
using System.Text;

class Report
{
    // Report Class Properties
    public string Title { get; }
    public string Subtitle { get; }
    public List<(string Heading, string Content)> Sections { get; }
    public List<string> Charts { get; }
    public string Footer { get; }

    private Report(Builder builder)
    {
        Title = builder.TitleVal;
        Subtitle = builder.SubtitleVal;
        Sections = new List<(string, string)>(builder.SectionList);
        Charts = new List<string>(builder.ChartList);
        Footer = builder.FooterVal;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("========================================");
        sb.AppendLine(Title);
        if (Subtitle != null) sb.AppendLine(Subtitle);
        sb.AppendLine("========================================");
        for (int i = 0; i < Sections.Count; i++) {
            sb.AppendLine();
            sb.AppendLine($"{i + 1}. {Sections[i].Heading}");
            sb.AppendLine($"   {Sections[i].Content}");
        }
        if (Charts.Count > 0) {
            sb.AppendLine();
            sb.AppendLine($"Charts: [{string.Join(", ", Charts)}]");
        }
        if (Footer != null) {
            sb.AppendLine();
            sb.Append($"--- {Footer} ---");
        }
        return sb.ToString();
    }

    public class Builder
    {
        // Builder class maintains the state and the state is reassigned to report properties.
        internal string TitleVal;
        internal string SubtitleVal;
        internal List<(string Heading, string Content)> SectionList = new List<(string, string)>();
        internal List<string> ChartList = new List<string>();
        internal string FooterVal;

        public Builder(string title) { TitleVal = title; }

        public Builder Subtitle(string subtitle)
        {
            SubtitleVal = subtitle;
            return this;
        }

        public Builder AddSection(string heading, string content)
        {
            SectionList.Add((heading, content));
            return this;
        }

        public Builder AddChart(string chart)
        {
            ChartList.Add(chart);
            return this;
        }

        public Builder Footer(string footer)
        {
            FooterVal = footer;
            return this;
        }

        public Report Build()
        {
            // TODO: Validate that SectionList is not empty
            // If empty, throw InvalidOperationException("Report must have at least one section")
            if(SectionList.Count == 0)
            {
                throw new InvalidOperationException("Report must have at least one section");
            }
            return new Report(this);
        }
    }
}

class Program
{
    static void Main()
    {
        Report report = new Report.Builder("Q4 Performance Report")
                .Subtitle("October - December 2024")
                .AddSection("Executive Summary", "Revenue grew 15% quarter over quarter.")
                .AddSection("Key Metrics", "DAU: 1.2M, MAU: 5.8M, Revenue: $12.3M")
                .AddSection("Challenges", "Infrastructure costs increased by 8%.")
                .AddChart("revenue-trend")
                .AddChart("user-growth")
                .Footer("Confidential - Internal Use Only")
                .Build();

        Console.WriteLine(report);
        SystemConsole.WriteLine();

        try
        {
            Report empty = new Report.Builder("Empty Report").Build();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}