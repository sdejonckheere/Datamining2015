using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamining2015
{
    class Pearson : Algorithm
    {
        double sumCombinedRatings;
        double tempResult;
        double sumUser1;
        double sumSquaredUser1;
        
        double sumUser2;
        double sumSquaredUser2;
        
        double productUser1and2;
        double numerator;
        double tempUser1;
        double tempUser2;
        double pearson;

        public double Calculate(RecordData data)
        {
            // Calculate Numerator
            
            for (int i = 0; i < data.getRatingsUser1().Count; i++)
            {

               sumUser1 += (double) data.getRatingsUser1()[i];
               sumUser2 += (double) data.getRatingsUser2()[i];

               sumSquaredUser1 += Math.Pow((double)data.getRatingsUser1()[i],2);
               sumSquaredUser2 += Math.Pow((double)data.getRatingsUser2()[i], 2);

               tempResult = (double) data.getRatingsUser1()[i] * (double) data.getRatingsUser2()[i];
               sumCombinedRatings += tempResult;
 
            }

            productUser1and2 = (sumUser1 * sumUser2)/data.getRatingsUser1().Count;

            numerator = sumCombinedRatings - productUser1and2;

            //Calculate denominator

            tempUser1 = sumSquaredUser1 - (Math.Pow(sumUser1, 2) / data.getRatingsUser1().Count);

            tempUser1 = Math.Sqrt(tempUser1);

            tempUser2 = sumSquaredUser2 - (Math.Pow(sumUser2, 2) / data.getRatingsUser1().Count);

            tempUser2 = Math.Sqrt(tempUser2);

            pearson = numerator / (tempUser1 * tempUser2);

            return pearson;
        
        }
    
    }

}
