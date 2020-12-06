using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}