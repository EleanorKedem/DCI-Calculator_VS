using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCI_Calculator
{
    public enum StoneSize
    {
        Specials,
        CT10,
        CT9,
        CT8,
        CT7,
        CT6,
        CT5,
        CT4,
        CT3,
        GR10,
        GR8,
        GR6,
        GR5,
        GR4,
        GR3,
        PCT2,
        PCT4,
        minus9plus7,
        minus7plus5,
        minus5plus3,
        minus3plus1
    }

    public enum StoneSubgroup
    {
        Specials,
        Total5to10CT,
        Total10GRto4CT,
        GR8,
        Total13plus,
        TotalSmall
    }
    public enum StoneModel
    {
        Crystals,
        SawableHigh,
        SawableLow,
        ZHigh,
        ZLow,
        Makeable,
        MakeableHigh,
        MakeableLow,
        SpottedZ,
        Spotted,
        Clivage,
        Rejections,
        Boart
    }

    public enum StoneClarity
    {
        QU1,
        QU2,
        QU3,
        QU4
    }
    public class Stone
    {
        private StoneSize stoneSize;
        private StoneModel stoneModel;
        private char stoneColour;
        private StoneClarity stoneClarity;
        private double stonePrice;
        private int key;
        private int stoneWeight;

        #region Constructors
        public Stone()
        {
            //empty constructor
            stoneWeight = -1;
        }

        public Stone (StoneSize size, StoneModel model, int position, double price)
        {
            stoneSize = size;
            stoneModel = model;
            key = position;
            stonePrice = price;
        }

        public Stone(StoneSize size, StoneModel model, char colour, StoneClarity clarity)
        {
            stoneSize = size;
            stoneModel = model;
            stoneColour = colour;
            stoneClarity = clarity;
            stoneWeight = -1;
            stonePrice = -1;
        }

        public Stone(StoneSize size, StoneModel model, char colour, StoneClarity clarity, int weight)
        {
            stoneSize = size;
            stoneModel = model;
            stoneColour = colour;
            stoneClarity = clarity;
            stoneWeight = weight;
            stonePrice = -1;
        }

        #endregion

        #region Properties

        public StoneSize SSize
        {
            get { return stoneSize; }
            set { stoneSize = value; }
        }

        public StoneModel SModel
        {
            get { return stoneModel; }
            set { stoneModel = value; }
        }

        public double SPrice
        {
            get { return stonePrice; }
            set { stonePrice = value; }
        }

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        #endregion


        public void UpdateStone(StoneSize size, StoneModel model, char colour, StoneClarity clarity) 
        {
            stoneSize = size;
            stoneModel = model;
            stoneColour = colour;
            stoneClarity = clarity;
        }

    }
}
