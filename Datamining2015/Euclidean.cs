using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamining2015
{
    class Euclidean : Algorithm
    {
        double ratingVerschil;
        double totaalRating;

        public double Calculate(RecordData data)
        {
            //Binnenkomende ratings zijn alleen van similair items, neem verschil per item doe deze in het kwadraat, vervolgens optellen en de wortel van nemen.

            for (int i = 0; i < data.getRatingsUser1().Count; i++)
            {

                ratingVerschil = Math.Abs((double) data.getRatingsUser1()[i] -  (double) data.getRatingsUser2()[i]);

                ratingVerschil = Math.Pow(ratingVerschil, 2);

                totaalRating += ratingVerschil; 

            }

            totaalRating = Math.Pow(totaalRating, 0.5);

                return totaalRating;
        }

    }
}
