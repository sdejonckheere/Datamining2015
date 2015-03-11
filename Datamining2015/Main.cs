using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datamining2015
{
    public partial class Main : Form
    {

        Algorithm algorithm;

        public Main()
        {
            InitializeComponent();

            Euclidean euclidean = new Euclidean();

            Pearson pearson = new Pearson();

            Cosine cosine = new Cosine();
            
            SortedDictionary sd = new SortedDictionary();
            UserPreference u = new UserPreference();
            RecordData d = new RecordData();

            sd.SetRating(1, 101, 4.75);
            sd.SetRating(1, 103, 4.5);
            sd.SetRating(1, 113, 5);
            sd.SetRating(1, 104, 4.25);
            sd.SetRating(1, 105, 4);
          
            sd.SetRating(2, 101, 4);
            sd.SetRating(2, 103, 3);
            sd.SetRating(2, 113, 5);
            sd.SetRating(2, 104, 2);
            sd.SetRating(2, 105, 1);
            

            u = sd.getUserPreference(1);

            d = u.returnRecordData(sd.getUserPreference(2));

            //System.Diagnostics.Debug.WriteLine("get id " +d.getId());
            //System.Diagnostics.Debug.WriteLine("get com " +d.getCompareId());

            algorithm = cosine;

            double answer = cosine.Calculate(d);

            System.Diagnostics.Debug.WriteLine(answer);

            //algorithm.Calculate();

            //TESTING & DEBUGGING

            /*

            foreach (var item in d.getSimilairItems())
            {
                Console.WriteLine("Gemeenschappelijke items zijn:" + item);
            }
            foreach (var item in d.getRatingsUser1())
            {
                Console.WriteLine("Ratings user1:" + item);
            }
            foreach (var item in d.getRatingsUser2())
            {
                Console.WriteLine("Ratings user2:" + item);
            }
            foreach (var item in d.getRatingsUser2())
            {
                Console.WriteLine("Ratings user2:" + item);
            }
            foreach (var item in d.getUniqueItemsUser2())
            {
                Console.WriteLine("Unique items2:" + item);
            }
            foreach (var item in d.getUniqueItemsRatingsUser2())
            {
                Console.WriteLine("Unique ratings2:" + item);
            }
            
            */ 
             
        }

    }
}
