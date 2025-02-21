public class Game
{
    public List<double> userCards = [];
    public List<double> dealerCards = [];
    public double UserScore { get { return userCards.Sum(); } }
    public double DealerScore { get { return dealerCards.Sum(); } }
    private Deck mainDeck = new Deck();
    static Random rnd = new Random();
    public void UserDrawCard()
    {
        double newCard = mainDeck.LstDeck[rnd.Next(0, mainDeck.LstDeck.Count())];
        string newCardName = mainDeck.DeckCards[mainDeck.LstDeck.IndexOf(newCard)];
        string[] newCardNameSplit = newCardName.Split(" ");

        bool isPictureCard = newCardNameSplit[1] == "Jack" || newCardNameSplit[1] == "Queen" || newCardNameSplit[1] == "King";
        bool isAce = newCardNameSplit[1] == "Ace";

        // Give appropriate values to cards
        if (isPictureCard) { userCards.Add(10); }
        else if (isAce) { userCards.Add(11); }
        else { userCards.Add(Math.Floor(newCard)); }

        Console.WriteLine($"Your new card's value is {newCardName}");

        // Remove card from deck
        mainDeck.DeckCards.Remove(newCardName);
        mainDeck.LstDeck.Remove(newCard);
    }
    public void DealerDrawCard()
    {
        double newCard = mainDeck.LstDeck[rnd.Next(0, mainDeck.LstDeck.Count())];
        string newCardName = mainDeck.DeckCards[mainDeck.LstDeck.IndexOf(newCard)];
        string[] newCardNameSplit = newCardName.Split(" ");

        bool isPictureCard = newCardNameSplit[1] == "Jack" || newCardNameSplit[1] == "Queen" || newCardNameSplit[1] == "King";
        bool isAce = newCardNameSplit[1] == "Ace";

        // Give appropriate values to cards
        if (isPictureCard) { dealerCards.Add(10); }
        else if (isAce) { dealerCards.Add(11); }
        else { dealerCards.Add(Math.Floor(newCard)); }

        if ((dealerCards.Count() == 2) && (DealerScore != 21))
        {
            Console.WriteLine("Dealer's new card's value is hidden.");
        }
        else
        {
            Console.WriteLine($"Dealer's new cards value is {newCardName}");
        }

        // Remove card from deck
        mainDeck.DeckCards.Remove(newCardName);
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
        if ((userCards.Count == 2) && (UserScore == 21))
        {
            return true;
        }

        return false;
    }
    public void PrintCurrentDeck()
    {
        foreach (string c in mainDeck.DeckCards)
        {
            Console.Write($"{c} | ");
        }
        // Console.WriteLine(mainDeck.LstDeck.Count());
    }
}