public class Game
{
    public List<int> userCards = new List<int>();
    public List<int> dealerCards = new List<int>();
    // private int newCard 
    // { 
    //     get { return mainDeck.LstDeck[rnd.Next(0, mainDeck.LstDeck.Count())]; }
    //     set 
    //     {
    //         if (value == 11)
    //         {
    //             value = 1;
    //         }
    //     }
    // }
    public int UserScore { get { return userCards.Sum(); } }
    public int DealerScore { get { return dealerCards.Sum(); } }
    private Deck mainDeck = new Deck();
    static Random rnd = new Random();
    public void UserDrawCard()
    {
        // int newCard = mainDeck.LstDeck.Find(x => x == rnd.Next(0, mainDeck.LstDeck.Count() - 1));
        int newCard = mainDeck.LstDeck[rnd.Next(0, mainDeck.LstDeck.Count())];

        if ((newCard == 11) && (UserScore > 10))
        {
            newCard = 1;
        }

        userCards.Add(newCard);
        Console.WriteLine($"Your new card's value is {newCard}");

        mainDeck.LstDeck.Remove(newCard);
    }
    public void DealerDrawCard()
    {
        // int newCard = mainDeck.LstDeck.Find(x => x == rnd.Next(1, 12));
        int newCard = mainDeck.LstDeck[rnd.Next(0, mainDeck.LstDeck.Count())];

        if ((newCard == 11) && (DealerScore > 10))
        {
            newCard = 1;
        }

        dealerCards.Add(newCard);
        if ((dealerCards.Count() == 2) && (DealerScore != 21))
        {
            Console.WriteLine("Dealer's new card's value is hidden.");
        }
        else
        {
            Console.WriteLine($"Dealer's new cards value is {newCard}");
        }

        mainDeck.LstDeck.Remove(newCard);
    }

    public void StartGame(decimal placedBet)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0) { UserDrawCard(); }
            else { DealerDrawCard(); }
        }

        Console.WriteLine($"Your score: {UserScore}");
    }
    public bool IsBlackJack()
    {
        if((userCards.Count == 2) && (UserScore == 21))
        {
            return true;
        }

        return false;
    }
    public void PrintCurrentDeck()
    {
        foreach (int c in mainDeck.LstDeck)
        {
            Console.Write($"{c} | ");
        }

    }
}