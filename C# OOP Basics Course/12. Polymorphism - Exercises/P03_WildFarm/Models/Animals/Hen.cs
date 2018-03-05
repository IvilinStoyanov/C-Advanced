using System;
using System.Collections.Generic;
using System.Text;


public class Hen : Bird
{
    public const double IncreaseWeightPercentage = 0.35d;

    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override void IncreaseWeight(Food food)
    {
        this.Weight += this.FoodEaten * IncreaseWeightPercentage;
        this.FoodEaten += food.FoodQuantity;
    }

    public override string ProduceSound()
    {
        return "Cluck";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

