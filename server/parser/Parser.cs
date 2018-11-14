using dataModel;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mgparser
{
    public class Parser : IParser
    {
        public readonly string RGXSQUAREBRACKET = @"\[[^\]]*\]";
        public readonly string RGXROUNDBRACKET = @"\([^)]+\)";
        public readonly string RGXCURLYBRACKET = @"\{[^}]*?\}";

        //public static List<IndexableEntity> Parse(Title title, TitleSubtitle titleSubtitle)
        //{
        //    string[] theWholeSubtitleFileTextLines = titleSubtitle.SubtitleText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    List<IndexableEntity> parsedSubtitles = null;
        //    IndexableEntity currentParsedSubtitle = null;
        //    TimeSpan startTime = TimeSpan.MinValue;
        //    TimeSpan endTime = TimeSpan.MinValue;
        //    bool isPreviousCaptureReadyToInsert = false;

        //    for (int i = 0; i < theWholeSubtitleFileTextLines.Length; i++)
        //    {
        //        string thisLine = theWholeSubtitleFileTextLines[i];

        //        int n;
        //        // Check if this line is not empty and not a number
        //        if (!string.IsNullOrWhiteSpace(thisLine) && !int.TryParse(thisLine.Trim(), out n))
        //        {
        //            if (currentParsedSubtitle == null || currentParsedSubtitle.EndTime != TimeSpan.Zero)
        //            { currentParsedSubtitle = new IndexableEntity(); }

        //            // This means its a start time and end time indicator
        //            if (thisLine.Contains("-->"))
        //            {
        //                // Capture start time and end time
        //                string[] timesSplit = thisLine.Split(new string[] { "-->" }, System.StringSplitOptions.RemoveEmptyEntries);
        //                if (timesSplit.Length == 2)
        //                {
        //                    if (!string.IsNullOrWhiteSpace(timesSplit[0]))
        //                    {
        //                        string startTimeString = timesSplit[0];
        //                        startTimeString = startTimeString.Remove(startTimeString.IndexOf(","));
        //                        startTime = TimeSpan.Parse(startTimeString);
        //                    }

        //                    if (!string.IsNullOrWhiteSpace(timesSplit[1]))
        //                    {
        //                        string endTimeString = timesSplit[1];
        //                        endTimeString = endTimeString.Remove(endTimeString.IndexOf(","));
        //                        endTime = TimeSpan.Parse(endTimeString);
        //                    }
        //                }
        //            }
        //            else // NOW this means its a logical correct text line to capture as a quote
        //            {
        //                if (currentParsedSubtitle.StartTime == TimeSpan.Zero) { currentParsedSubtitle.StartTime = startTime; }

        //                thisLine = CleanItOfAllSpecialCharcters(thisLine);
        //                if (!string.IsNullOrWhiteSpace(currentParsedSubtitle.SubtitleText))
        //                {
        //                    currentParsedSubtitle.SubtitleText += " ";
        //                }
        //                currentParsedSubtitle.SubtitleText += thisLine;

        //                if ((thisLine.EndsWith(".") || thisLine.EndsWith("?")) && !thisLine.EndsWith("...")) // the last part is just to make sure the statement is not continued
        //                {
        //                    isPreviousCaptureReadyToInsert = true;

        //                    currentParsedSubtitle.EndTime = endTime;
        //                    if (parsedSubtitles == null) { parsedSubtitles = new List<IndexableEntity>(); }
        //                    currentParsedSubtitle.TitleName = title.TitleName;
        //                    currentParsedSubtitle.TitleId = title.Id;
        //                    currentParsedSubtitle.SubtitleTextId = titleSubtitle.Id;
        //                    parsedSubtitles.Add(currentParsedSubtitle);
        //                    currentParsedSubtitle = null;
        //                }
        //                else
        //                {
        //                    isPreviousCaptureReadyToInsert = false;
        //                }
        //            }
        //        }
        //    }

        //    return parsedSubtitles;
        //}

        //private static string CleanItOfAllSpecialCharcters(string input)
        //{
        //    input = RegExReplacer(RGXCURLYBRACKET, input);
        //    input = RegExReplacer(RGXROUNDBRACKET, input);
        //    input = RegExReplacer(RGXSQUAREBRACKET, input);
        //    input = input.Replace("-", string.Empty);
        //    input = input.Replace("<i>", string.Empty);
        //    input = input.Replace("</i>", string.Empty);
        //    input = input.Replace("#", string.Empty);
        //    input = input.Replace("<", string.Empty);
        //    input = input.Replace(">", string.Empty);
        //    input = input.Replace("(", string.Empty);
        //    input = input.Replace(")", string.Empty);
        //    return input.Trim();
        //}

        //private static string RegExReplacer(string regEx, string inputString)
        //{
        //    MatchCollection mc = Regex.Matches(inputString, regEx);
        //    foreach (Match m in mc)
        //    {
        //        inputString = inputString.Replace(m.Value, String.Empty);
        //    }
        //    return inputString;
        //}

        private IEnumerable<ParsedText> Parse(MediaText mediaText)
        {
            string[] theWholeSubtitleFileTextLines = mediaText.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<ParsedText> parsedSubtitles = null;
            ParsedText currentParsedSubtitle = null;
            TimeSpan startTime = TimeSpan.MinValue;
            TimeSpan endTime = TimeSpan.MinValue;
            //bool isPreviousCaptureReadyToInsert = false;

            for (int i = 0; i < theWholeSubtitleFileTextLines.Length; i++)
            {
                string thisLine = theWholeSubtitleFileTextLines[i];

                int n;
                // Check if this line is not empty and not a number
                if (!string.IsNullOrWhiteSpace(thisLine) && !int.TryParse(thisLine.Trim(), out n))
                {
                    if (currentParsedSubtitle == null || currentParsedSubtitle.EndTime != TimeSpan.Zero)
                    { currentParsedSubtitle = new ParsedText(); }

                    // This means its a start time and end time indicator
                    if (thisLine.Contains("-->"))
                    {
                        // Capture start time and end time
                        string[] timesSplit = thisLine.Split(new string[] { "-->" }, System.StringSplitOptions.RemoveEmptyEntries);
                        if (timesSplit.Length == 2)
                        {
                            if (!string.IsNullOrWhiteSpace(timesSplit[0]))
                            {
                                string startTimeString = timesSplit[0];
                                startTimeString = startTimeString.Remove(startTimeString.IndexOf(","));
                                startTime = TimeSpan.Parse(startTimeString);
                            }

                            if (!string.IsNullOrWhiteSpace(timesSplit[1]))
                            {
                                string endTimeString = timesSplit[1];
                                endTimeString = endTimeString.Remove(endTimeString.IndexOf(","));
                                endTime = TimeSpan.Parse(endTimeString);
                            }
                        }
                    }
                    else // NOW this means its a logical correct text line to capture as a quote
                    {
                        if (currentParsedSubtitle.StartTime == TimeSpan.Zero) { currentParsedSubtitle.StartTime = startTime; }

                        thisLine = CleanItOfAllSpecialCharcters(thisLine);
                        if (!string.IsNullOrWhiteSpace(currentParsedSubtitle.Text))
                        {
                            currentParsedSubtitle.Text += " ";
                        }
                        currentParsedSubtitle.Text += thisLine;

                        if ((thisLine.EndsWith(".") || thisLine.EndsWith("?")) && !thisLine.EndsWith("...")) // the last part is just to make sure the statement is not continued
                        {
                            //isPreviousCaptureReadyToInsert = true;

                            currentParsedSubtitle.EndTime = endTime;
                            if (parsedSubtitles == null) { parsedSubtitles = new List<ParsedText>(); }
                            //currentParsedSubtitle. = title.TitleName;
                            currentParsedSubtitle.MediaTextId = mediaText.Id;
                            //currentParsedSubtitle.SubtitleTextId = titleSubtitle.Id;
                            parsedSubtitles.Add(currentParsedSubtitle);
                            currentParsedSubtitle = null;
                        }
                        else
                        {
                           // isPreviousCaptureReadyToInsert = false;
                        }
                    }
                }
            }

            return parsedSubtitles;
           // return null;
        }

        private string CleanItOfAllSpecialCharcters(string input)
        {
            input = RegExReplacer(RGXCURLYBRACKET, input);
            input = RegExReplacer(RGXROUNDBRACKET, input);
            input = RegExReplacer(RGXSQUAREBRACKET, input);
            input = input.Replace("-", string.Empty);
            input = input.Replace("<i>", string.Empty);
            input = input.Replace("</i>", string.Empty);
            input = input.Replace("#", string.Empty);
            input = input.Replace("<", string.Empty);
            input = input.Replace(">", string.Empty);
            input = input.Replace("(", string.Empty);
            input = input.Replace(")", string.Empty);
            return input.Trim();
        }

        private string RegExReplacer(string regEx, string inputString)
        {
            MatchCollection mc = Regex.Matches(inputString, regEx);
            foreach (Match m in mc)
            {
                inputString = inputString.Replace(m.Value, String.Empty);
            }
            return inputString;
        }

        //public Task<bool> ParseAndInsert(MediaText mediaText)
        //{
        //    // var parsedText = Parse(mediaText);

        //    return true;


        //}

    }
}
