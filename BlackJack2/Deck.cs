public class Deck
{
    public List<int> LstDeck = new List<int>();
    public Deck()
    {
        // https://math.stackexchange.com/questions/2312962/probability-of-drawing-certain-cards-in-blackjack
        // Create a deck to draw out cards randomly later

        for (int i = 0; i < 52; i++)
        {
            if (i < 4) { LstDeck.Add(2); }
            else if (i < 8) { LstDeck.Add(3); }
            else if (i < 12) { LstDeck.Add(4); }
            else if (i < 16) { LstDeck.Add(5); }
            else if (i < 20) { LstDeck.Add(6); }
            else if (i < 24) { LstDeck.Add(7); }
            else if (i < 28) { LstDeck.Add(8); }
            else if (i < 32) { LstDeck.Add(9); }
            else if (i < 48) { LstDeck.Add(10); }
            else if (i < 52) { LstDeck.Add(11); }

        }
    }
}