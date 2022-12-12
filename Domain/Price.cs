namespace Domain;

public class Price
{
    public Price(int almPrice, int fam40X40Price, int fam50X50Price, int almGlutenfriPrice)
    {
        this.AlmPrice = almPrice;
        this.Fam40x40Price = fam40X40Price;
        this.Fam50x50Price = fam50X50Price;
        this.AlmGlutenfriPrice = almGlutenfriPrice;
    }
    public int AlmPrice { get; set; }
    
    public int Fam40x40Price { get; set; }
    
    public int Fam50x50Price { get; set; }
    
    public int AlmGlutenfriPrice { get; set; }
}