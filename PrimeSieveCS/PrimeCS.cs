// ---------------------------------------------------------------------------
// PrimeCS.cs : Dave's Garage Prime Sieve in C++
// ---------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace PrimeSieveCS
{
    class PrimeCS
    {
        class prime_sieve
        {
            private readonly int sieveSize = 0;
            private readonly BitArray bitArray;
            private static readonly Dictionary<int, int> myDict = new Dictionary<int, int> 
            { 
                { 10 , 1 },                 // Historical data for validating our results - the number of primes
                { 100 , 25 },               // to be found under some limit, such as 168 primes under 1000
                { 1000 , 168 },
                { 10000 , 1229 },
                { 100000 , 9592 },
                { 1000000 , 78498 },
                { 10000000 , 664579 },
                { 100000000 , 5761455 } 
            };

            public prime_sieve(int size) 
            {
                sieveSize = size;
                bitArray = new BitArray(sieveSize, true);
            }

            public int countPrimes()
            {
                int count = 1;
                for (int i = 3; i < this.bitArray.Count; i += 2)
                    if (bitArray[i])
                        count++;
                return count;
            }

            public bool validateResults()
            {
                if (myDict.ContainsKey(this.sieveSize))
                    return myDict[this.sieveSize] == this.countPrimes();
                return false;
            }

            // primeSieve
            // 
            // Calculate the primes up to the specified limit

            public void runSieve()
            {
                int factor = 3;
                int q = (int) Math.Sqrt(this.sieveSize);

                while (factor <= q)
                {
                    for (int num = factor; num <= this.sieveSize; num += 2)
                    {
                        if (bitArray[num])
                        {
                            factor = num;
                            break;
                        }
                    }

                    // If marking factor 3, you wouldn't mark 6 (it's a mult of 2) so start with the 3rd instance of this factor's multiple.
                    // We can then step by factor * 2 because every second one is going to be even by definition

                    for (int num = factor * factor; num < this.sieveSize; num += factor * 2)
                        bitArray[num] = false;

                    factor += 2;
                }
            }

            public void printResults(bool showResults, double duration, int passes)
            {
                if (showResults)
                    Console.Write("2, ");

                int count = 1;
                for (int num = 3; num <= this.sieveSize; num += 2)
                {
                    if (bitArray[num])
                    {
                        if (showResults)
                            Console.Write(num + ", ");
                        count++;
                    }
                }
                if (showResults)
                    Console.WriteLine("");
                Console.WriteLine("Passes: " + passes + ", Time: " + duration + ", Avg: " + (duration / passes) + ", Limit: " + this.sieveSize + ", Count: " + count + ", Valid: " + validateResults());
            }
        }

        static void Main(string[] args)
        {
            const int sieveSize = 1_000_000;
            var passes = 0;
            prime_sieve sieve = null;
            var tStart = DateTime.UtcNow;

            while ((DateTime.UtcNow - tStart).TotalSeconds < 5)
            {
                sieve = new prime_sieve(sieveSize);
                sieve.runSieve();
                passes++;
            }

            var tD = DateTime.UtcNow - tStart;
            if (sieve != null)
                sieve.printResults(false, tD.TotalSeconds, passes);
        }
    }
}
