using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hors.Models
{
    public enum FixPeriod
    {
        None = 0,
        Time = 1,
        Day = 2,
        Week = 4,
        Month = 8,
        Year = 16
    }

    public class DatesRawData
    {
        public List<string> Tokens;
        public string Pattern;
        public List<AbstractPeriod> Dates;

        public string GetPattern()
        {
            return Pattern;
        }
    }

    public struct DateTimeToken
    {
        public DateTimeTokenType Type;
        public DateTime DateFrom;
        public DateTime DateTo;
        public TimeSpan Span;

        public override string ToString()
        {
            return $"[Type={Type}, DateFrom={DateFrom.ToString(CultureInfo.CurrentCulture)}, DateTo={DateTo.ToString(CultureInfo.CurrentCulture)}, Span={Span.ToString()}]";
        }
    }

    public enum DateTimeTokenType
    {
        Fixed,
        Period,
        SpanForward,
        SpanBackward,
    }

    public enum PartTime
    {
        None,
        Quarter,
        Half
    }

    public enum RelativeMode
    {
        None,
        Next,
        Previous,
        Current,
        CurrentNext
    }

    public enum Period
    {
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year,
        None,
    }

    public enum DayTime
    {
        None,
        Morning,
        Noon,
        Day,
        Evening,
        Night
    }
}