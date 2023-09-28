using System.Collections.Generic;
public class MenuRepo
{
        List<MenuItem> _menu = new List<MenuItem>();
        public MenuRepo(){
            Seed();
        }

        public void Seed() {
            MenuItem pizza = new MenuItem(1, "pizza", "it's pizza", "dough, cheese, sauce", 1.00);
            MenuItem burger = new MenuItem(2, "Cheeseburger", "cheeseburger, fries, and a drink", "beef, cheese, bread", 5.00);
            MenuItem ramen = new MenuItem(3, "Ramen", "ramen bowl and a drink", "ramen noodles, pork broth, eggs, seaweed, bean sprouts", 10.00);
            AddContentToDirectory(pizza);
            AddContentToDirectory(burger);
            AddContentToDirectory(ramen);
        }

        public void AddContentToDirectory(MenuItem item){
            _menu.Add(item);
        }

        public List<MenuItem> GetAllMenuItems(){
            return _menu;
        }

        public MenuItem GetItemByNumber(int number){
            foreach(MenuItem item in _menu){
                if(number == item.MealNumber){
                    return item;
                }
            }
            return default;
        }

        public MenuItem GetItemByName(string name){
            foreach(MenuItem item in _menu){
                if(name.ToLower() == item.MealName.ToLower()){
                    return item;
                }
            }
            return default;
        }

        public void UpdateNumber(int number, MenuItem itemToChange){
            itemToChange.MealNumber = number;
        }

        public void UpdateName(string name, MenuItem itemToChange){
            itemToChange.MealName = name;
        }

        public void UpdateDescription(string description, MenuItem itemToChange){
            itemToChange.Description = description;
        }

        public void UpdateIngredients(string ingredients, MenuItem itemToChange){
            itemToChange.Ingredients = ingredients;
        }

        public void UpdatePrice(double price, MenuItem itemToChange){
            itemToChange.Price = price;
        }

        public void DeleteItem(MenuItem item){
            _menu.Remove(item);
        }
}
