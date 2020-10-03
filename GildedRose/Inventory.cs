using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace GildedRose
{
    class Inventory
    {
        private readonly IEnumerable<Item> items;

        public Inventory(IEnumerable<Item> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Items:
        /// "+5 Dexterity Vest"
        /// "Aged Brie"
        /// "Elixir of the Mongoose"
        /// "Sulfuras, Hand of Ragnaros"
        /// "Backstage passes to a TAFKAL80ETC concert"
        /// "Conjured Mana Cake"
        /// </summary>
         
        public void UpdateQuality()
        {
            // Hint: Iterate through this.items and check Name property to access specific item
            foreach(Item item in items)
            {
                if(!item.Name.Contains("Sulfuras"))
                {
                    item.SellIn--;
                    if (item.Name.Contains("Conjured"))
                    {
                        if (item.Quality > 0)
                            item.Quality = item.SellIn >= 0 ? item.Quality - 2 : item.Quality - 4;

                    }
                    else if (item.Name.Contains("Aged Brie"))
                    {
                        if (item.Quality < 50)
                            item.Quality = item.SellIn >= 0 ? item.Quality + 1 : item.Quality + 2;
                    }
                    else if (item.Name.Contains("Backstage passes"))
                    {
                        if (item.SellIn <= 10 && item.SellIn > 5)
                            item.Quality += 2;

                        if (item.SellIn <= 5)
                            item.Quality += 3;

                        if (item.SellIn < 0)
                            item.Quality = 0;

                        else if(item.SellIn > 10)
                            item.Quality++;

                    }
                    else
                    {
                        //Normal items
                        if(item.Quality > 0)
                            item.Quality = item.SellIn >= 0 ? item.Quality - 1 : item.Quality - 2;

                    }
                    //Protection. Quality can be between 0 - 50 expect legendary items
                    if (item.Quality < 0)
                        item.Quality = 0;

                    if (item.Quality > 50)
                        item.Quality = 50;
                }
            }
            
        }
    }
}
