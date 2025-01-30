public class CardsOnHand
{
    static Deck mainDeck = new Deck();
    static Random rnd = new Random();

    public int DrawCard()
    {
        int newCard = mainDeck.LstDeck.Find(x => x == rnd.Next(1, 12));
        
        return newCard;
    }

}