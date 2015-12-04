namespace Cosmetics.Products
{
    using System.Text;
    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        private const int ProductNameMinLenght = 3;
        private const int ProductNameMaxLenght = 10;
        private const int BrandNameMinLenght = 2;
        private const int BrandNameMaxLenght = 10;

        private string name;
        private string brand;

        protected Product(
            string name, 
            string brand, 
            decimal price, 
            GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value, 
                    ProductNameMaxLenght,
                    ProductNameMinLenght, 
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength, 
                        "Product name", ProductNameMinLenght, ProductNameMaxLenght));

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringLengthIsValid(
                    value,
                    BrandNameMaxLenght,
                    BrandNameMinLenght,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Product brand", BrandNameMinLenght, BrandNameMaxLenght));

                this.brand = value;
            }
        }

        public decimal Price { get; private set; }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            var printResult = new StringBuilder();
            printResult.AppendLine($"- {this.Brand} - {this.Name}:");
            printResult.AppendLine($"  * Price: ${this.Price}");
            printResult.AppendLine($"  * For gender: {this.Gender}");

            return printResult.ToString().Trim();
        }
    }
}