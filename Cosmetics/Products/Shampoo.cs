namespace Cosmetics.Products
{
    using System.Text;
    using Common;
    using Contracts;

    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;

        public Shampoo(
            string name,
            string brand,
            decimal price,
            GenderType gender,
            uint milliliters,
            UsageType usage)
            : base(
                  name,
                  brand,
                  CalculateShampooPrice(price, milliliters),
                  gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }

            private set
            {
                this.milliliters = value;
            }
        }

        public UsageType Usage { get; private set; }

        public override string Print()
        {
            var printResult = new StringBuilder();
            printResult.AppendLine(base.Print());
            printResult.AppendLine($"  * Quantity: {this.Milliliters} ml");
            printResult.AppendLine($"  * Usage: {this.Usage}");
            return printResult.ToString().Trim();
        }

        private static decimal CalculateShampooPrice(decimal price, uint milliliters)
        {
            return price * milliliters;
        }
    }
}