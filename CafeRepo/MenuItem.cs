public class MenuItem
{
        public int MealNumber {get; set;}
        
        public string MealName {get; set;}

        public string Description {get; set;}

        public string Ingredients {get; set;}

        public double Price {get; set;}

        public MenuItem(){}

        public MenuItem(int number, string name, string description, string ingredients, double price)
        {
            MealNumber = number;
            MealName = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
}
