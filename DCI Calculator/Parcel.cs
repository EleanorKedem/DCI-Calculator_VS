using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    class Parcel
    {
        private int totalWeight;
        private int totalValue;
        private int averageValue;
        private string mine;
        private string country;

        Dictionary<Item, int> parcel;

        Parcel()
        {
            parcel = new Dictionary<Item, int>();
        }

        public int AddItem (Item i)
        {
            int sum;

            if (parcel.TryGetValue(i, out sum))
            {
                ++sum;
            }
            else
            {
                sum = 1;
            }
            parcel.Add(i, sum);

            return sum;
        }
    }
}
