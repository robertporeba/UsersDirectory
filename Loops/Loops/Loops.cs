﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Loops
{
    class Loops
    {
        //1
        public bool PrimeNumbers(int a)
        {
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void ShowPrimeNumbers()
        {
            for (int i = 2; i <= 100; i++)
            {
                if (PrimeNumbers(i) == true)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}