using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Datamining2015
{
    public class RecordData
    {

        int userId;
        int comparedId;

        ArrayList SimilairItems;
        ArrayList RatingsUser1;
        ArrayList RatingsUser2;
        ArrayList UniqueItemsUser1;
        ArrayList UniqueItemsUser1Ratings;
        ArrayList UniqueItemsUser2;
        ArrayList UniqueItemsUser2Ratings;

 
        public void setUserId(int i)
        {
         
            userId = i;
        
        }

        public void setComparedId(int i)
        {

            comparedId = i;

        }
        public int getId()
        {

            return userId;

        }

        public int getCompareId()
        {

            return comparedId;

        }
        
        public void setSimilairItems(ArrayList a){

            SimilairItems = a;

        }
        public void setRatingsUser1(ArrayList a)
        {

            RatingsUser1 = a;

        }
        public void setRatingsUser2(ArrayList a)
        {

            RatingsUser2 = a;

        }

        public void setUniqueItemsUser1(ArrayList a)
        {
            UniqueItemsUser1 = a;
        }
        public void setUniqueItemsUser1Ratings(ArrayList a)
        {
            UniqueItemsUser1Ratings = a;
        }

        public void setUniqueItemsUser2(ArrayList a)
        {
            UniqueItemsUser2 = a;
        }
        public void setUniqueItemsUser2Ratings(ArrayList a)
        {
            UniqueItemsUser2Ratings = a;
        }

        public ArrayList getSimilairItems()
        {
            return SimilairItems;
        }
        public ArrayList getRatingsUser1()
        {
            return RatingsUser1;
        }
        public ArrayList getRatingsUser2()
        {
            return RatingsUser2;
        }
        public ArrayList getUniqueItemsUser2()
        {
            return UniqueItemsUser2;
        }
        public ArrayList getUniqueItemsRatingsUser2()
        {
            return UniqueItemsUser2Ratings;
        }
        public ArrayList getUniqueItemsUser1()
        {
            return UniqueItemsUser1;
        }
        public ArrayList getUniqueItemsRatingsUser1()
        {
            return UniqueItemsUser1Ratings;
        }

    }
   
}
