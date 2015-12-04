namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private const int CategoryNameMinLebnght = 2;
        private const int CategoryNameMaxLebnght = 15;

        private readonly IList<IProduct> products = new List<IProduct>();
        private string name;

        public Category(string name)
        {
            this.Name = name;
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
                    CategoryNameMaxLebnght,
                    CategoryNameMinLebnght, 
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Category name", CategoryNameMinLebnght, CategoryNameMaxLebnght));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.products.Contains(cosmetics))
            {
                throw new InvalidOperationException(
                    $"Product {cosmetics.Name} does not exist in category {this.Name}!");
            }

            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            var printResult = new StringBuilder();
            printResult.AppendLine(
                $"{this.Name} category - {this.products.Count} product{(this.products.Count == 1 ? "" : "s")} in total");
            if (this.products.Any())
            {
                var orderedCategory = this.products
                    .OrderBy(p => p.Brand)
                    .ThenByDescending(p => p.Price);

                foreach (var product in orderedCategory)
                {
                    printResult.AppendLine(product.Print());
                }
            }

            return printResult.ToString().Trim();
        }
    }
}