﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Util
{
    private static Random random = new Random();
    ///<summary>Return a random number from 0-max (both inclusive)</summary>
    public static int Rng(int max)
    {
        return random.Next(max +1);
    }
    ///<summary>Return a random number from lowerLimit-upperLimit (both inclusive)</summary>
    public static int Rng(int lowerLimit, int upperLimit)
    {
        return random.Next(lowerLimit, upperLimit+1);
    }
}
