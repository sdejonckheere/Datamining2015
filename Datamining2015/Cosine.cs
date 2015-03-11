using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Datamining2015
{
    class Cosine : Algorithm
    {

        double x;
        double y;

        public double Calculate(RecordData data)
        {

            foreach (double item in data.getRatingsUser1())
            {
                x += (item * item);
            }
            foreach (double item in data.getUniqueItemsRatingsUser1())
            {
                x += (item * item);
            }
            foreach (double item in data.getRatingsUser2())
            {
                y += (item * item);
            }
            foreach (double item in data.getUniqueItemsRatingsUser2())
            {
                y += (item * item);
            }
            double dotProduct = 0;

            for (int i = 0; i < data.getRatingsUser1().Count; i++ )
            {

                dotProduct += (double)data.getRatingsUser1()[i] * (double)data.getRatingsUser2()[i];

            }

            x = Math.Sqrt(x);
            y = Math.Sqrt(y);

            System.Diagnostics.Debug.WriteLine("dotProduct " + dotProduct);
            System.Diagnostics.Debug.WriteLine("X " +x);
            System.Diagnostics.Debug.WriteLine("y " +y);


            return dotProduct / (x * y);

        }
    }
}
