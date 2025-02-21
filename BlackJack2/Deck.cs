public class Deck
{
    public List<double> LstDeck = [];
    public List<string> DeckCards = [];
    public Deck()
    {
        // https://math.stackexchange.com/questions/2312962/probability-of-drawing-certain-cards-in-blackjack
        // Create a deck to draw out cards randomly later

        /*
        Clover : .1
        Spade  : .2
        Heart  : .3
        Diamond: .4
        */

        // for (int i = 0; i < 52; i++)
        // {
        //     if (i < 4) { LstDeck.Add(2); }
        //     else if (i < 8) { LstDeck.Add(3); }
        //     else if (i < 12) { LstDeck.Add(4); }
        //     else if (i < 16) { LstDeck.Add(5); }
        //     else if (i < 20) { LstDeck.Add(6); }
        //     else if (i < 24) { LstDeck.Add(7); }
        //     else if (i < 28) { LstDeck.Add(8); }
        //     else if (i < 32) { LstDeck.Add(9); }
        //     else if (i < 36) { LstDeck.Add(10); }
        //     else if (i < 40) { LstDeck.Add(10); }
        //     else if (i < 44) { LstDeck.Add(10); }
        //     else if (i < 48) { LstDeck.Add(10); }
        //     else if (i < 52) { LstDeck.Add(11); }

        // }

        for (int i = 2; i < 15; i++) { LstDeck.Add(i + 0.1); }
        for (int i = 2; i < 15; i++) { LstDeck.Add(i + 0.2); }
        for (int i = 2; i < 15; i++) { LstDeck.Add(i + 0.3); }
        for (int i = 2; i < 15; i++) { LstDeck.Add(i + 0.4); }

        for (int i = 0; i < 52; i++)
        {
            string[] eltSplit = LstDeck[i].ToString().Split(",");
            string cardType = "Diamond";
            if (eltSplit[1] == "1") { cardType = "Clover"; }
            else if (eltSplit[1] == "2") { cardType = "Spade"; }
            else if (eltSplit[1] == "3") { cardType = "Heart"; }

            if (eltSplit[0] == "11") { DeckCards.Add($"{cardType} Jack"); }
            else if (eltSplit[0] == "12") { DeckCards.Add($"{cardType} Queen"); }
            else if (eltSplit[0] == "13") { DeckCards.Add($"{cardType} King"); }
            else if (eltSplit[0] == "14") { DeckCards.Add($"{cardType} Ace"); }
            else { DeckCards.Add($"{cardType} {eltSplit[0]}"); }
        }
    }

    // for (int i = 0; i < 52; i += 4)
    // {
    //     DeckCards.Add($"Clover {LstDeck[i].ToString()}");
    // }
    // for (int i = 1; i < 52; i += 4)
    // {
    //     DeckCards.Add($"Spade {LstDeck[i].ToString()}");
    // }
    // for (int i = 2; i < 52; i += 4)
    // {
    //     DeckCards.Add($"Heart {LstDeck[i].ToString()}");
    // }
    // for (int i = 3; i < 52; i += 4)
    // {
    //     DeckCards.Add($"Diamond {LstDeck[i].ToString()}");
    // }
}
