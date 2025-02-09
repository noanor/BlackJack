public class Game
{
    private List<int> userCards = new List<int>();
    private List<int> dealerCards = new List<int>();
    public int UserScore { get { return userCards.Sum(); } }
    public int DealerScore { get { return dealerCards.Sum(); } }
    static Deck mainDeck = new Deck();
    static Random rnd = new Random();
    public void UserDrawCard()
    {
        int newCard = mainDeck.LstDeck.Find(x => x == rnd.Next(0, mainDeck.LstDeck.Count()));

        userCards.Add(mainDeck.LstDeck[newCard]);
        Console.WriteLine($"Your new card's value is {mainDeck.LstDeck[newCard]}");

        mainDeck.LstDeck.Remove(mainDeck.LstDeck[newCard]);
    }
    public void DealerDrawCard()
    {
        // int newCard = mainDeck.LstDeck.Find(x => x == rnd.Next(1, 12));
        int newCard = mainDeck.LstDeck[rnd.Next(0, mainDeck.LstDeck.Count())];

        dealerCards.Add(mainDeck.LstDeck[newCard]);
        if ((dealerCards.Count() == 2) && (DealerScore != 21))
        {
            Console.WriteLine("Dealer's new card's value is hidden.");
        }
        else
        {
            Console.WriteLine($"Dealer's new cards value is {mainDeck.LstDeck[newCard]}");
        }

        mainDeck.LstDeck.Remove(mainDeck.LstDeck[newCard]);
    }

    public void StartGame(double placedBet)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0) { UserDrawCard(); }
            else { DealerDrawCard(); }
        }

        Console.WriteLine($"Your score: {UserScore}");
    }
    public void PrintCurrentDeck()
    {
        foreach (int c in mainDeck.LstDeck)
        {
            Console.Write($"{c} | ");
        }

    }
}