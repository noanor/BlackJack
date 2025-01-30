public class CardsOnHand
{
    public List<int> LstCards = new List<int>();
    public int score { get; set; }

    static Random rnd = new Random();

    

    public CardsOnHand()
    {
        int c1 = rnd.Next(2, 12);
        int c2 = rnd.Next(2, 12);

        LstCards.Add(c1);
        LstCards.Add(c2);
    }

    public void DrawCard()
    {
        int newCard = rnd.Next(2, 12);
        LstCards.Add(newCard);
    }

    public int CalcScore()
    {
        return LstCards.Sum();
    }



}