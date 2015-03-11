using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamining2015
{
    public class UserPreference
    {
        private int id;
        private double[] ratings;
        private int[] itemIds;
        
        private int beginItem = 0;
        private int endItem = 0;
        private int[] itemsTempArr;
        private double[] ratingsTempArr;

        int searchResult;

        public void setWaardering(int itemId, double rating)
        {

            //Check of binnenkomende rating de eerste is
            if (beginItem == 0)
            {

                itemIds = new int[1];
                ratings = new double[1];
                
                this.itemIds[0] = itemId;
                this.ratings[0] = rating;

                beginItem = itemId;
                endItem = itemId;

                return;
            
            }
            //Invoegen aan begin
            if (itemId < beginItem)
            {
                //vergroten
                itemsTempArr = new int[itemIds.Length+1];
                ratingsTempArr = new double[ratings.Length+1];
                
                //plaats eerste

                itemsTempArr[0] = itemId;
                ratingsTempArr[0] = rating;

                //Kopieer restant

                itemIds.CopyTo(itemsTempArr, 1);
                ratings.CopyTo(ratingsTempArr, 1);

                //Maak concreet

                itemIds = itemsTempArr;
                ratings = ratingsTempArr;

                //Update begin & eindwaarde

                beginItem = itemId;

                return;
            }
            //Invoegen aan het eind
            if (itemId > endItem)
            {

                //vergroten

                itemsTempArr = new int[itemIds.Length + 1];
                ratingsTempArr = new double[ratings.Length + 1];

                //vullen

                itemIds.CopyTo(itemsTempArr, 0);
                ratings.CopyTo(ratingsTempArr, 0);

                //plaats laatste

                itemsTempArr[itemsTempArr.Length - 1] = itemId;
                ratingsTempArr[ratingsTempArr.Length - 1] = rating;

                //maak concreet

                itemIds = itemsTempArr;
                ratings = ratingsTempArr;

                //Update begin & eindwaarde

                endItem = itemId;

                return;
 
            }
            //invoegen tussenin
            if(itemId >= beginItem && itemId <= endItem){
      
                searchResult = Array.BinarySearch(itemIds, itemId);
                
                //Bij positief searchResult gaat het om een bestaand item update
                
                if (searchResult >= 0)
                {
 
                    ratings[searchResult] = rating;
                    
                    return;
                
                }
                
                //Bij negatief resultaat gaat het om een nieuw item

                if (searchResult < 0)
                {
                                     
                    //vergroten

                    itemsTempArr = new int[itemIds.Length + 1];
                    ratingsTempArr = new double[ratings.Length + 1];

                    // Kopieer orgineel naar temp
                    //Corigeer searchresult

                    searchResult = Math.Abs(searchResult);
                    searchResult--;

                    Array.Copy(itemIds, itemsTempArr, searchResult);
                    Array.Copy(ratings, ratingsTempArr, searchResult);
                    itemsTempArr[searchResult] = itemId;
                    ratingsTempArr[searchResult] = rating;
                    Array.Copy(itemIds, searchResult, itemsTempArr, searchResult+1,(itemIds.Length-searchResult));
                    Array.Copy(ratings, searchResult, ratingsTempArr, searchResult + 1, (ratings.Length - searchResult));

                    itemIds = itemsTempArr;
                    ratings = ratingsTempArr;

                }
           
            }
        
        }
         
        public int[] getSimilairItems(int[] userItems)
        {
            int[] indenticalItems;
            
             List<int> items = new List<int>();

            for (int i = 0; i < userItems.Length; i++)
            {
                for (int j = 0; j < this.itemIds.Length; j++)
                {
                    if (userItems[i] == this.itemIds[j])
                    {
                        items.Add(userItems[i]);
                    }
                }
            }

            indenticalItems = items.ToArray();

            return indenticalItems;
        }
        
        public void printUser(){
            
        Array.ForEach(itemIds, x => System.Diagnostics.Debug.WriteLine(x));
        Array.ForEach(ratings, x => System.Diagnostics.Debug.WriteLine(x));
     
            }
    }
}
