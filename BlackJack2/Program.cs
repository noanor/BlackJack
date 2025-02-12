
Console.WriteLine("Hello, what is your name?");
string theName = Console.ReadLine();

Account newAcc = new Account(theName);

while (newAcc.Balance > 0)
{
    int gameCounter = 0;
    List<Game> lstGames = new List<Game>();
    lstGames.Add(new Game());

    Console.WriteLine($"Welcome to Black Jack, {newAcc.Name}!\nPlease place your bets:");
    decimal usrBet = decimal.Parse(Console.ReadLine());
    if (usrBet > newAcc.Balance)
    {
        Console.WriteLine($"Cannot bet more than account balance.\nBalance: {newAcc.Balance:C}\n\nPlease place your bet:");
        usrBet = decimal.Parse(Console.ReadLine());
    }

    lstGames[gameCounter].StartGame(usrBet);
    newAcc.Balance -= usrBet;

    while (lstGames[gameCounter].UserScore < 21)
    {
        Console.Write("Hit or Stand?");
        string hitOrStand = Console.ReadLine();

        if (hitOrStand.ToLower() == "hit")
        {
            lstGames[gameCounter].UserDrawCard();
            Console.WriteLine($"Your score: {lstGames[gameCounter].UserScore}");
            // lstGames[gameCounter].PrintCurrentDeck();
        }
        else if (hitOrStand.ToLower() == "stand")
        {
            Console.WriteLine($"Dealer's second card is {lstGames[gameCounter].dealerCards[1]}");
            Console.WriteLine($"Dealer score: {lstGames[gameCounter].DealerScore}");
            break;
        }
    }

    // Dealer draws cards until his score is 17 or above
    while (lstGames[gameCounter].DealerScore < 17)
    {
        lstGames[gameCounter].DealerDrawCard();
    }
    Console.WriteLine($"Dealer's score: {lstGames[gameCounter].DealerScore}");

    if ((lstGames[gameCounter].UserScore > lstGames[gameCounter].DealerScore) && (lstGames[gameCounter].UserScore <= 21) || (lstGames[gameCounter].UserScore <= 21) && (lstGames[gameCounter].DealerScore > 21)) // Winning situtaion
    {
        if(lstGames[gameCounter].IsBlackJack()) // BlackJack situation
        {
            Console.WriteLine($"Dealer's score: {lstGames[gameCounter].DealerScore}");
            newAcc.Balance += usrBet + (usrBet * 1.5m);
            Console.WriteLine($"You win ${(usrBet + (usrBet * 1.5m)):C}!");

        }
        else 
        {
            Console.WriteLine($"Dealer's score: {lstGames[gameCounter].DealerScore}");
            newAcc.Balance += (usrBet * 2);
            Console.WriteLine($"You win ${(usrBet * 2):C}!");

        }
    }
    else if ((lstGames[gameCounter].UserScore == lstGames[gameCounter].DealerScore) || ((lstGames[gameCounter].UserScore > 21) && (lstGames[gameCounter].DealerScore > 21))) // Tie situation
    {
        Console.WriteLine($"Dealer's score: {lstGames[gameCounter].DealerScore}");
        newAcc.Balance += usrBet;
        Console.WriteLine($"Tie game, you got {usrBet:C} back");
    }
    else // Losing situation
    {
        Console.WriteLine($"Dealer's score: {lstGames[gameCounter].DealerScore}");
        Console.WriteLine($"The house wins {usrBet:C}");
    }

    Console.WriteLine($"Balance: {newAcc.Balance:C}\n");
    gameCounter++;
}