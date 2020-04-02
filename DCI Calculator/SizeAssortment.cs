using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    public class SizeAssortment
    {
        private StoneSize key;
        private StoneSubgroup group;
        private double totalWeight;
        private double insertedWeight; //TODO with enter or with kill check if all weight was inserted
        private double totalValue;
        private double averageValue;
        private double percentWeight;
        private double percentValue;
        private int numStones; //TODO consider because not necessarily number of stones but a relational sample
        private String valuer;

        public SortedList<StoneModel, Item> items;

        #region Constructors

        public SizeAssortment()
        {
            items = new SortedList<StoneModel, Item>();
            totalWeight = 0;
            insertedWeight = 0;
            totalValue = 0;
            averageValue = 0;
            percentWeight = 0;
            percentValue = 0;
            numStones = 0;
            valuer = "";
        }

        public SizeAssortment(StoneSize k, double w)
        {
            items = new SortedList<StoneModel, Item>();
            key = k;
            switch(k)
            {
                case StoneSize.Specials:
                    group = StoneSubgroup.Specials;
                    break;
                case StoneSize.CT10:
                case StoneSize.CT9:
                case StoneSize.CT8:
                case StoneSize.CT7:
                case StoneSize.CT6:
                case StoneSize.CT5:
                    group = StoneSubgroup.Total5to10CT;
                    break;
                case StoneSize.CT4:
                case StoneSize.CT3:
                case StoneSize.GR10:
                    group = StoneSubgroup.Total10GRto4CT;
                    break;
                case StoneSize.GR8:
                    group = StoneSubgroup.GR8;
                    break;
                case StoneSize.GR6:
                case StoneSize.GR5:
                case StoneSize.GR4:
                case StoneSize.GR3:
                    group = StoneSubgroup.Total13plus;
                    break;
                default:
                    group = StoneSubgroup.TotalSmall;
                    break;
            }
            totalWeight = w;
            insertedWeight = 0;
            totalValue = 0;
            percentWeight = 0;
            percentValue = 0;
            numStones = 0;
            valuer = "";
        }

        public SizeAssortment(StoneSize k, double w, String name)
        {
            items = new SortedList<StoneModel, Item>();
            key = k;
            switch (k)
            {
                case StoneSize.Specials:
                    group = StoneSubgroup.Specials;
                    break;
                case StoneSize.CT10:
                case StoneSize.CT9:
                case StoneSize.CT8:
                case StoneSize.CT7:
                case StoneSize.CT6:
                case StoneSize.CT5:
                    group = StoneSubgroup.Total5to10CT;
                    break;
                case StoneSize.CT4:
                case StoneSize.CT3:
                case StoneSize.GR10:
                    group = StoneSubgroup.Total10GRto4CT;
                    break;
                case StoneSize.GR8:
                    group = StoneSubgroup.GR8;
                    break;
                case StoneSize.GR6:
                case StoneSize.GR5:
                case StoneSize.GR4:
                case StoneSize.GR3:
                    group = StoneSubgroup.Total13plus;
                    break;
                default:
                    group = StoneSubgroup.TotalSmall;
                    break;
            }
            totalWeight = w;
            insertedWeight = 0;
            totalValue = 0;
            percentWeight = 0;
            percentValue = 0;
            numStones = 0;
            valuer = name;
        }

        #endregion

        #region Properties

        public StoneSize Key
        {
            get { return key; }
            set { key = value; }
        }

        public StoneSubgroup Group
        {
            get { return group; }
            set { group = value; }
        }

        public double TotalWeight
        {
            get { return totalWeight; }
            set { totalWeight = value; }
        }

        public double InsertedWeight
        {
            get { return insertedWeight; }
            set { insertedWeight = value; }
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

        public double PercentWeight
        {
            get { return percentWeight; }
            set { percentWeight = value; }
        }

        public double PercentValue
        {
            get { return percentValue; }
            set { percentValue = value; }
        }

        public int NumStones
        {
            get { return numStones; }
            set { numStones = value; }
        }

        #endregion

        #region SizeAssortmentMethods

        public void AddModel(StoneModel key, Item value)
        {
            if (items.ContainsKey(key))
            {
                //TODO check in what way to update value
              items[key].TotalWeight = value.TotalWeight;
            }

            else
            {
                items.Add(key, value); 
                UpdateTotalEnteredWeight();
            }
        }

        public void UpdateTotalEnteredWeight()
        {
            insertedWeight = 0;

            foreach (StoneModel key in items.Keys)
            {
                insertedWeight += items[key].TotalWeight;
            }
        }

        public double CheckEnteredWeight()
        {
            return (insertedWeight - totalWeight);
        }

        public bool UpdateItemWeight(StoneModel m, double w)
        {
            if (items.ContainsKey(m))
            {
                items[m].TotalWeight = w;
                UpdateTotalEnteredWeight();
                return true;
            }

            else
            {
                return false;
            }
        }

        public void UpdateValues()
        {
            numStones = 0;
            totalValue = 0;

            foreach(StoneModel key in items.Keys)
            {
                numStones += items[key].TotalStonesNum;
                totalValue += items[key].TotalValue;
            }

            averageValue = totalValue / totalWeight;
        }

        #endregion
    }
}
