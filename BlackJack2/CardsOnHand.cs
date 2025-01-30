public class CardsOnHand
{
    public List<int> currentHand = new List<int>();
    static Deck mainDeck = new Deck();
    static Random rnd = new Random();

    public void DrawCard()
    {
        int newCard = mainDeck.LstDeck.Find(x => x == rnd.Next(1, 12));

        mainDeck.LstDeck.Remove(newCard);
        currentHand.Add(newCard);

        Console.WriteLine($"New card value {newCard}");
    }

}