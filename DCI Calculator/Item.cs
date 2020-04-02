using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    class Item
    {
        private int totalWeight;
        private int totalValue;
        private int averageValue;
        private int totalStonesNum;
        private Model model;
        private Size size;

        Dictionary<Stone, int> item;

        Item()
        {
            item = new Dictionary<Stone, int>();
            totalStonesNum = 0;
            averageValue = 0;
            totalValue = 0;
            totalWeight = 0;
        }

        Item(Model m, Size s)
        {
            item = new Dictionary<Stone, int>();
            totalStonesNum = 0;
            averageValue = 0;
            totalValue = 0;
            totalWeight = 0;
            model = m;
            size = s;
        }

        /// <summary>
        /// TODO - doesn't take decreases into consideration
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int AddStones(Stone s, int sum)
        {
            int tempSum;
         
            if (item.TryGetValue(s, out tempSum))
            {
                if (tempSum != sum)
                    totalStonesNum += (tempSum - sum);
            }
            else
            {
                totalStonesNum += sum;
            }
            item.Add(s, sum);

            return sum;
        }
    }
}
