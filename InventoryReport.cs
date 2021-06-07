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
        void AddLogistics(DateTime dateTime);
        InventoryReport GetDailyReport();
    }

    public class DailyReportBuilder : IFurnitureInventoryBuider
    {

        private InventoryReport _report;
        private readonly IEnumerable<FurnitureItem> _items;

        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            Reset();
            this._items = items;
        }

        public void Reset()
        {
            _report = new InventoryReport();
        }
        public void AddDimensions()
        {
            _report.DimensionsSection = string.Join(Environment.NewLine, _items.Select(product =>
                        $"Product: {product.Name} \n" +
                        $"Price {product.Price} \n" +
                        $"Height {product.Height} \n" +
                        $"Width {product.Width} \n" +
                        $"Weight {product.Weight} \n"));
        }

        public void AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = "Report generated on {dateTime}";
        }

        public void AddTite()
        {
            _report.TitleSection = "------ Daily Inventory Report ------\n\n";
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finishedReport = _report;
            Reset();

            return finishedReport;
        }



    }
    public class InventoryBuilderDirector
    {
        private IFurnitureInventoryBuider _builder;

        public InventoryBuilderDirector(IFurnitureInventoryBuider concreteBuilder)
        {
            _builder = concreteBuilder;
        }

        public void BuildCompleteReport()
        {
            _builder.AddTite();
            _builder.AddDimensions();
            _builder.AddLogistics(DateTime.Now);
        }
    }
}
