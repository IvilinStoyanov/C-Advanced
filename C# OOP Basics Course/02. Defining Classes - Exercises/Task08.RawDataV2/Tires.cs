public class Tires
{
    private double pressure;
    private int age;

    public Tires(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }

    public double Pressure => this.pressure;
    public int Age => this.age;


}