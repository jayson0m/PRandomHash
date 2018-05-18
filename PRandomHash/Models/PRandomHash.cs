/*
    PRandomHash - 
        A very, very simple algorithm that can be used to generate pseudo random IDs for indexes
 
    Copyright (c) 2018 Jayson Munro

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
 */

using System;

namespace PRandomHash.Models
{
    public class PRHash
    {
        public string output { get; set; }
        
        // Dev vars
        public string devword1 { get; set; }
        public string devword2{ get; set; }
        public string devoutput { get; set; }

        public PRHash GetHash(string word1, string word2, int limit = 10)
        {
            PRHash hash = new PRHash();
            // Add chars to the words to make them the same length
            word1 = word1.PadRight(limit, 'y'); 
            word2 = word2.PadRight(limit, 'x');
            
            // convert to character array
            char[] word1Arr = word1.ToCharArray();
            char[] word2Arr = word2.ToCharArray(); 
            // cycle through array while less than the limit. 
            for (var i = 0 ; i < limit; i++)
            {
                // convert character to byte. 
                byte w1 = Convert.ToByte(word1Arr[i]);
                byte w2 = Convert.ToByte(word2Arr[i]);
                
                // add w1 and w1.  xor the value by the index plus w2. 
                double o = (w1 + w2) ^ (i + w1);
                
                // Log(o)^2 
                o = Math.Pow((o * Math.Log(o)), 2);
                
                // round own to whole number 
                o = Math.Floor(o);
                
                // if greater than 99 lower number under 100. 
                if (o > 99)
                    o %= 100;
                
                hash.output += o;
                
                // dev vars 
                hash.devword1 += w1.ToString() + ':';
                hash.devword2 += w2.ToString() + ':';
                hash.devoutput += o.ToString() + ':';  
            }
            return hash;
        }
    }
}