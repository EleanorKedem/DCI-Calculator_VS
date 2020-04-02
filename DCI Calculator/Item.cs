using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    public class Item
    {
        private double totalWeight;
        private double totalValue;
        private double averageValue;
        private int totalStonesNum;
        private StoneModel key;
        private StoneSize size;

        SortedList<int, Stone> stones;
        SortedList<int, int> numbers;

        #region Constructors
        public Item()
        {
            stones = new SortedList<int, Stone>();
            numbers = new SortedList<int, int>();
            totalStonesNum = 0;
            averageValue = 0;
            totalValue = 0;
            totalWeight = 0;
        }

        public Item(StoneModel m, StoneSize s)
        {
            stones = new SortedList<int, Stone>();
            numbers = new SortedList<int, int>();
            totalStonesNum = 0;
            averageValue = 0;
            totalValue = 0;
            totalWeight = 0;
            key = m;
            size = s;
        }

        public Item(StoneModel m, StoneSize s, double w)
        {
            stones = new SortedList<int, Stone>();
            numbers = new SortedList<int, int>();
            totalStonesNum = 0;
            averageValue = 0;
            totalValue = 0;
            totalWeight = w;
            key = m;
            size = s;
        }
        #endregion

        #region Properties

        public StoneModel Key
        {
            get { return key; }
            set { key = value; }
        }

        public double TotalWeight
        {
            get { return totalWeight; }
            set { totalWeight = value; }
        }

        public double TotalValue
        {
            get { return totalValue; }
            set { totalValue = value; }
        }

        public double AverageValue
        {
            get { return averageValue; }
            set { averageValue = value; }
        }

/*        public double Percent
        {
            get { return percent; }
            set { percent = value; }
        }
        */
        public int TotalStonesNum
        {
            get { return totalStonesNum; }
            set { totalStonesNum = value; }
        }

        #endregion

        /// <summary>
        /// TODO - doesn't take decreases into consideration
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public void AddStones(int position, int num, double price)
        {
            if (numbers.ContainsKey(position))
            {
                //TODO check in what way to update value
                numbers[position] = num;
                UpdateItem();
            }

            else
            {
                Stone s = new Stone(size, key, position, price);
                stones.Add(position, s);
                numbers.Add(position, num);
                UpdateItem();
            }
        }

        public void UpdateItem()
        {
            double sum = 0;

            totalStonesNum = 0;
            foreach (int i in numbers.Keys)
            {
                totalStonesNum += numbers[i];

                sum += numbers[i] * stones[i].SPrice;
            }

            if (totalStonesNum != 0)
            {
                averageValue = sum / totalStonesNum;
            }

            else
            {
                averageValue = 0;
            }

            totalValue = totalWeight * averageValue;
        }
    }
}
