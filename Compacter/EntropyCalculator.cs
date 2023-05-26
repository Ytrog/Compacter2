﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compacter
{
    /// <summary>
    /// Calculate entropy. Inspired by: https://github.com/merces/entropy/blob/master/entropy.cpp
    /// </summary>
    public static class EntropyCalculator
    {
        public static double Calculate(FileInfo fileInfo)
        {

            uint[] count = CountBytes(fileInfo);

            double entropy = CalculateEntropy(fileInfo.Length, count);

            return entropy;
        }

        /// <summary>
        /// Calculate the Shannon entropy of a file
        /// </summary>
        /// <param name="fileLength">The total length of the file</param>
        /// <param name="count">The statistics per byte (it is an array of length 256 with the count per byte value)</param>
        /// <returns></returns>
        public static double CalculateEntropy(long fileLength, uint[] count)
        {
            double entropy = 0;
            double temp;

            for (int i = 0; i < count.Length; i++)
            {
                temp = ((double)count[i]) / fileLength;

                if (temp > 0)
                {
                    entropy += temp * Math.Abs(Math.Log2(temp));
                }
            }

            return entropy;
        }

        /// <summary>
        /// Count the bytes in a file
        /// </summary>
        /// <param name="fileInfo">The file</param>
        /// <returns></returns>
        public static uint[] CountBytes(FileInfo fileInfo)
        {
            uint[] byteCount = new uint[256]; // create an array with the count for each byte value (from 0x00 to 256)

            // TODO count the bytes
            // TODO error handling
            // TODO LATER measure performance and tune
#warning no error handling 
            using (var stream = fileInfo.OpenRead())
            {
                int currentByte = default;
                do
                {
                    currentByte = stream.ReadByte();
                    if (currentByte >= 0)
                    {
                        byteCount[currentByte]++;
                    }

                } while (currentByte != -1);
            }

            return byteCount;
        }
    }
}
