﻿using System;

namespace DiariesForPractice.DiariesGenerator.Extenstions
{
    public static class DateExtensions
    {
        public static string ToString(this DateTime date)
        {
            return date.ToString($"{date.Date} г.");
        }
    }
}