using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamining2015
{
    class SortedDictionary
    {

        SortedDictionary<int, UserPreference> sdic = new SortedDictionary<int, UserPreference>();

        //Ophalen UserPreference uit dictionary, insert rating, terugzetten userpreference.

        public void SetRating(int id, int itemId, double rating)
        {
            
            UserPreference u;

            if(sdic.TryGetValue(id,out u)){

                u.setWaardering(itemId,rating);

                sdic[id] = u;

            }
            else
            {

                u = new UserPreference();
                
                u.setId(id);
                
                u.setWaardering(itemId,rating);

                sdic[id] = u;

            }
           
        }
        public UserPreference getUserPreference(int id)
        {

            UserPreference u;
            
            sdic.TryGetValue(id, out u);
            
            return u;
               
        }

    }
    
}
