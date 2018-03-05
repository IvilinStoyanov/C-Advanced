using System;
using System.Collections.Generic;
using System.Text;


public class Owl : Bird
{
    public const double IncreaseWeightPercentage = 0.25d;

    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {

    }

    public override void IncreaseWeight(Food food)
    {
        if (food.GetType().Name == "Meat")
        {
            this.Weight += food.FoodQuantity * IncreaseWeightPercentage;
            this.FoodEaten += food.FoodQuantity;
        }
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

