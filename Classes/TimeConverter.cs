using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BerlinClock.Classes;
using BerlinClock.Utility;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        //Convert the given time to Berlin Clock format
        public string convertTime(string aTime)
        {
            var result = new List<string>();

            var timeForBerlinClock = TimeUtils.ConvertTimeStringTo24Format(aTime);
            //adding hours, seconds and minutes to the result list
            result.Add(FormatBerlinClock.GetLampForSeconds(timeForBerlinClock.Seconds));
            result.Add(FormatBerlinClock.GetLampsForHours((int)timeForBerlinClock.TotalHours, 1));
            result.Add(FormatBerlinClock.GetLampsForHours((int)timeForBerlinClock.TotalHours, 2));
            result.Add(FormatBerlinClock.GetLampsForMinutesThirdRow(timeForBerlinClock.Minutes));
            result.Add(FormatBerlinClock.GetLampsForMinutesFourthRow(timeForBerlinClock.Minutes));

            //string utility to join all the Seconds, Minutes & hours results
            return StringUtils.JoinStringLines(result.ToArray());
        }

        

    }
}
