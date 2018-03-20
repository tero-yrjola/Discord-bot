using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Util
{
    private static Random random = new Random();
    ///<summary>Return a random number from 0-max (upperlimit is exclusive)</summary>
    public static int Rng(int max)
    {
        return random.Next(max);
    }
    ///<summary>Return a random number from lowerLimit-upperLimit (upperlimit is exclusive)</summary>
    public static int Rng(int lowerLimit, int upperLimit)
    {
        return random.Next(lowerLimit, upperLimit);
    }
}

