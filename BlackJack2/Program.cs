Console.WriteLine("Welcome to Black Jack!\nPlease place your bets:");
double usrBet = 100; //double.Parse(Console.ReadLine());

Game newGame = new Game();

newGame.StartGame(usrBet);
// int userScore = newGame.UserScore;
// int dealerScore = newGame.DealerScore;

while (newGame.UserScore < 21)
{
    Console.Write("Hit or Stand?");
    string hitOrStand = Console.ReadLine();

    if (hitOrStand.ToLower() == "hit")
    {
        newGame.UserDrawCard();
        Console.WriteLine($"Your score: {newGame.UserScore}");
    }
    else if (hitOrStand == "stand")
    {
        break;
    }
    else
    {
        Console.Write("Hit or Stand?");
        hitOrStand = Console.ReadLine();
    }

}

while (newGame.DealerScore < 17)
{
    newGame.DealerDrawCard();
    Console.WriteLine($"Dealer's score: {newGame.DealerScore}");
}

if // Winning situation
((newGame.UserScore > newGame.DealerScore) && (newGame.UserScore <= 21) ||
 (newGame.UserScore <= 21) && (newGame.DealerScore > 21))
{
    Console.WriteLine($"You win ${usrBet * 2}!");
}
else if ((newGame.UserScore < newGame.DealerScore) && (newGame.DealerScore <= 21))
{
    Console.WriteLine($"The house wins ${usrBet}");
}