using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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

            //Check of Array leeg is.
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
                                     
                    // Vergroten

                    itemsTempArr = new int[itemIds.Length + 1];
                    ratingsTempArr = new double[ratings.Length + 1];

                    // Kopieer orgineel naar temp
                    // Corigeer searchresult

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

        //Vergelijk UserPreference met huidige UserPreference, geef terug similair items

        public RecordData returnRecordData(UserPreference compareTo)
        {

            ArrayList similairItemsList = new ArrayList();
            ArrayList ratingsUser1List = new ArrayList();
            ArrayList ratingsUser2List = new ArrayList();
            ArrayList uniqueItemsUser2List = new ArrayList();
            ArrayList uniqueItemsUser2RatingsList = new ArrayList();
            ArrayList uniqueItemsUser1List = new ArrayList();
            ArrayList uniqueItemsUser1RatingsList = new ArrayList();

            int[] itemsUser2 = compareTo.getItems();
            double[] ratingsUser2 = compareTo.getRatings();
            
            //Loop beide itemidarrs, wanneer gelijk zet id in similairitems evenalsbijhorende rating
           
            for (int i = 0; i < itemIds.Length; i++ )
            {

                for (int j = 0; j < itemsUser2.Length; j++ )
                {
               
                    if (itemIds[i] == itemsUser2[j])
                    {
                        similairItemsList.Add(itemIds[i]);
                        ratingsUser1List.Add(ratings[i]);
                        ratingsUser2List.Add(ratingsUser2[j]);
                        break;
                    }
                    
                }  
            }

          

            //Vergelijk similair items met items user2, wanneer niet gelijk insert id in unique uniqueItemsUser2List
           

            for (int i = 0; i < itemsUser2.Length; i++ )
            {

                bool itemExists = false;

                foreach (int value in similairItemsList)
                {

                    if (value == itemsUser2[i])
                    {                      
                        itemExists = true;                
                    }
                                  
                }
                if (itemExists == false)
                {                
                    uniqueItemsUser2List.Add(itemsUser2[i]);
                    uniqueItemsUser2RatingsList.Add(ratingsUser2[i]);
                }
              
            }

            for (int i = 0; i < itemIds.Length; i++)
            {

                bool itemExists = false;

                foreach (int value in similairItemsList)
                {

                    if (value == itemIds[i])
                    {
                        itemExists = true;
                    }

                }
                if (itemExists == false)
                {
                    uniqueItemsUser1List.Add(itemIds[i]);
                    uniqueItemsUser1RatingsList.Add(ratings[i]);
                }

            }


                      
            RecordData data = new RecordData();

            data.setSimilairItems(similairItemsList);
            data.setRatingsUser1(ratingsUser1List);
            data.setRatingsUser2(ratingsUser2List);
            data.setUniqueItemsUser2(uniqueItemsUser2List);
            data.setUniqueItemsUser2Ratings(uniqueItemsUser2RatingsList);
            data.setUserId(id);
            data.setComparedId(compareTo.getId());
            
            data.setUniqueItemsUser1(uniqueItemsUser1List);
            data.setUniqueItemsUser1Ratings(uniqueItemsUser1RatingsList);
           
            return data;

        }
   
        //Getters & Setters

        public void setId(int i)
        {

            this.id = i;

        }
        
        public int getId()
        {

            return id;

        }

        public int[] getItems()
        {
            return itemIds;
        }

        public double[] getRatings()
        {
            return ratings;
        }

    }
}
