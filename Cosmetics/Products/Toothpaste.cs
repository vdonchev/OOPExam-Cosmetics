namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private const int IngradientNameMinLenght = 4;
        private const int IngradientNameMaxLenght = 12;

        private string ingredients;

        public Toothpaste(
            string name,
            string brand,
            decimal price,
            GenderType gender,
            IList<string> ingredients)
            : base(
                  name,
                  brand,
                  price,
                  gender)
        {
            this.Ingredients = this.ProcessIngredients(ingredients);
        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }

            private set
            {
                this.ingredients = value;
            }
        }

        private string ProcessIngredients(IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(
                    ingredient,
                    IngradientNameMaxLenght,
                    IngradientNameMinLenght,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Each ingredient",
                        IngradientNameMinLenght,
                        IngradientNameMaxLenght));
            }

            return string.Join(", ", ingredients);
        }

        public override string Print()
        {
            var printResult = new StringBuilder();
            printResult.AppendLine(base.Print());
            printResult.AppendLine($"  * Ingredients: {this.Ingredients}");
            return printResult.ToString().Trim();
        }
    }
}