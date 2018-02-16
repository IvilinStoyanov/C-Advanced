public class Cargo
{
    private int weight;
    private string type;

    public Cargo(int weight , string type)
    {
        this.weight = weight;
        this.type = type;
    }

    public int Weight => this.weight;
    public string Type => this.type;
}