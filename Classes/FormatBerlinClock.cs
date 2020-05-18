using System;
using System.Linq;
using BerlinClock.Utility;

namespace BerlinClock.Classes
{
    public static class FormatBerlinClock
    {
        //Lamp reading for Seconds
        public static string GetLampForSeconds(int seconds)
        {
            if ((seconds < 0) || (seconds > 59))
                throw new ArgumentException("Parameter seconds must be between 0 and 59");
            //here switched on at even & off on odd seconds
            return seconds % 2 == 0 ? Constants.SwitchedOnYellowCharacter.ToString()
            : Constants.SwitchedOffCharacter.ToString();
        }

        //Lamp reading for Hours
        public static string GetLampsForHours(int hours, int nRow)
        {
            if ((hours < 0) || (hours > 24))
                throw new ArgumentException("Parameter hours must be between 0 and 24");

            if ((nRow != 1) && (nRow != 2))
                throw new ArgumentException("Parameter nRow must be 1 or 2");

            // here switched on lamp count 5 hours
            var lampsArray = Enumerable.Repeat(Constants.SwitchedOffCharacter, 4).ToArray();
            var numberOfSwitchedOnLamps = nRow == 1 ? hours / 5 : hours % 5;
            for (var nLamp = 0; nLamp < numberOfSwitchedOnLamps; nLamp++)
                lampsArray[nLamp] = Constants.SwitchedOnRedCharacter;

            return string.Join("", lampsArray);
        }

        //Lamp reading for 3rd row minutes
        public static string GetLampsForMinutesThirdRow(int minutes)
        {
            if ((minutes < 0) || (minutes > 59))
                throw new ArgumentException("Parameter minutes must be between 0 and 59");

            // here switched on lamp count 5 minutes
            var lampsArray = Enumerable.Repeat(Constants.SwitchedOffCharacter, 11).ToArray();
            var numberOfSwitchedOnLamps = minutes / 5;
            for (var nLamp = 0; nLamp < numberOfSwitchedOnLamps; nLamp++)
                lampsArray[nLamp] = ((nLamp == 2) || (nLamp == 5) || (nLamp == 8)) ?
                    Constants.SwitchedOnRedCharacter : Constants.SwitchedOnYellowCharacter;

            return string.Join("", lampsArray);
        }

        //Lamp reading for 4th row minutes
        public static string GetLampsForMinutesFourthRow(int minutes)
        {
            if ((minutes < 0) || (minutes > 59))
                throw new ArgumentException("Parameter minutes must be between 0 and 59");

            // here switched on lamp count 1 minute
            var lampsArray = Enumerable.Repeat(Constants.SwitchedOffCharacter, 4).ToArray();
            var numberOfSwitchedOnLamps = minutes % 5;
            for (var nLamp = 0; nLamp < numberOfSwitchedOnLamps; nLamp++)
                lampsArray[nLamp] = Constants.SwitchedOnYellowCharacter;

            return string.Join("", lampsArray);
        }
    }
}
