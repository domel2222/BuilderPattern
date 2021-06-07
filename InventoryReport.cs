using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class FurnitureItem
    {
        public string Name;
        public double Price;
        public double Height;
        public double Width;
        public double Weight;

        public FurnitureItem(string productName, double price, double height, double width, double weight)
        {
            Name = productName;
            Price = price;
            Height = height;
            Width = width;
            Weight = weight;
        }
    }

    public class InventoryReport
    {
        public string TitleSection;
        public string DimensionsSection;
        public string LogisticsSection;



        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DimensionsSection)
                .AppendLine(LogisticsSection)
                .ToString();
        }
    }

    public interface IFurnitureInventoryBuider
    {
        void AddTite();
        void AddDimensions();
        void AddLogistics();
        InventoryReport GetDailyReport();
    }

    public class DailyReportBuilder : IFurnitureInventoryBuider
    {

        private InventoryReport _report;

        public DailyReportBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _report = new InventoryReport();
        }
        public void AddDimensions()
        {
            throw new NotImplementedException();
        }

        public void AddLogistics()
        {
            throw new NotImplementedException();
        }

        public void AddTite()
        {
            throw new NotImplementedException();
        }

        public InventoryReport GetDailyReport()
        {
            throw new NotImplementedException();
        }
    }
}
