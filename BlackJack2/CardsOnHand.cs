public class CardsOnHand
{
    public List<int> LstCards = new List<int>();
    public int score { get; set; }

    static Random rnd = new Random();

    static int GenerateDeck()
    {
        int rndCard = rnd.Next(1, 49);

        // https://math.stackexchange.com/questions/2312962/probability-of-drawing-certain-cards-in-blackjack
        // Create a deck to draw out cards randomly later
        // while (int i < 1 < 4) 
        // { deck[c] = 2}...
    }

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