using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMVCPattern.Models {
    public class ItemsRepository {
        public void AddItem(Item item) { 
            /* Implement me */ 
        }

        public Item FetchByID(int itemID) { 
            /* Implement me */  return null; 
        }

        public IList<Item> ListItems(int pageSize, int pageIndex) { 
            /* Implement me */ return null; 
        }
        public void SubmitChanges() { 
            /* Implement me */ 
        }
    }
}