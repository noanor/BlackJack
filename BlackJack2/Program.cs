Console.WriteLine("Hello, what is your name?");
string theName = Console.ReadLine();

Account newAcc = new Account(theName);

/* 
Split situation

Conditions
1. Pair
2. Bet same amount on both hands, balance must be greater or equal to bet after bet

*/

/*
    Game continues until there is no more money in the account
*/


while (newAcc.Balance > 0)
{
    int gameCounter = 0;
    List<Game> lstGames = [];
    lstGames.Add(new Game());
    Game currentGame = lstGames[gameCounter];

    Console.WriteLine($"Welcome to Black Jack, {newAcc.Name}!\nPlease place your bets or type 'Debt' to pay debts:");
    string usrBetS = Console.ReadLine();

    if ((usrBetS.ToLower() == "debt") && (newAcc.Debt > 0))
    {
        Console.Write("Downpayment amount: ");
        decimal usrDownPayment = decimal.Parse(Console.ReadLine());

        if (usrDownPayment <= newAcc.Balance)
        {
            newAcc.Balance -= usrDownPayment;
            newAcc.Debt -= usrDownPayment;
        }
        else { Console.WriteLine("\nInsufficient funds."); }

        Console.WriteLine($"Account balance: {newAcc.Balance}\nAccount debt: {newAcc.Debt.ToString("0.00")}");

        Console.WriteLine("Place bet to continue betting:");
        usrBetS = Console.ReadLine();
    }
    else if (decimal.Parse(usrBetS) > newAcc.Balance)
    {
        Console.WriteLine($"Cannot bet more than account balance.\nBalance: {newAcc.Balance:C}\n\nPlease place your bet:");
        usrBetS = Console.ReadLine();
    }


    decimal usrBet = decimal.Parse(usrBetS);
    currentGame.StartGame(usrBet);
    newAcc.Balance -= usrBet;

    while (currentGame.UserScore < 21)
    {
        Console.Write("Hit or Stand?");
        string hitOrStand = Console.ReadLine();

        if ((hitOrStand.ToLower() == "hit") || hitOrStand == "1")
        {
            currentGame.UserDrawCard();
            Console.WriteLine($"Your score: {currentGame.UserScore}");
            // currentGame.PrintCurrentDeck();
        }
        else if ((hitOrStand.ToLower() == "stand") || hitOrStand == "2")
        {
            Console.WriteLine($"Dealer's second card is {currentGame.dealerCards[1]}");
            Console.WriteLine($"Dealer score: {currentGame.DealerScore}");
            break;
        }
    }

    // Dealer draws cards until his score is 17 or above
    while (currentGame.DealerScore < 17)
    {
        currentGame.DealerDrawCard();
    }
    Console.WriteLine($"Dealer's score: {currentGame.DealerScore}");

    /*
    SITUATIONS & MESSAGES
    */

    // Situations
    bool winningSituation = ((currentGame.UserScore > currentGame.DealerScore) && (currentGame.UserScore <= 21) || (currentGame.UserScore <= 21) && (currentGame.DealerScore > 21));
    bool tieGame = (currentGame.UserScore == currentGame.DealerScore) || ((currentGame.UserScore > 21) && (currentGame.DealerScore > 21));

    // Messages
    string message = $"Dealer's score: {currentGame.DealerScore}\nThe house wins {usrBet:C}";
    string messageWin = $"Dealer's score: {currentGame.DealerScore}\nYou win {(usrBet * 2):C}!";
    string messageBJ = $"Dealer's score: {currentGame.DealerScore}\nYou win {(usrBet + (usrBet * 1.5m)):C}!";
    string messageTie = $"Dealer's score: {currentGame.DealerScore}\nTie game, you got {usrBet:C} back";

    if (winningSituation) // Winning situtaion
    {
        if (currentGame.IsBlackJack()) // BlackJack situation
        {
            newAcc.Balance += usrBet + (usrBet * 1.5m);
            message = messageBJ;
        }
        else
        {
            newAcc.Balance += (usrBet * 2);
            message = messageWin;
        }
    }
    else if (tieGame) // Tie situation
    {
        newAcc.Balance += usrBet;
        message = messageTie;
    }
    // else // Losing situation
    // {
    //     Console.WriteLine($"Dealer's score: {currentGame.DealerScore}");
    //     Console.WriteLine($"The house wins {usrBet:C}");
    // }

    Console.WriteLine(message);

    Console.WriteLine($"Balance: {newAcc.Balance:C}\n");
    gameCounter++;

    if (newAcc.Debt > 0)
    {
        newAcc.DebtInc();
    }

    if (newAcc.Balance == 0)
    {
        Console.WriteLine("Take loan?\nType 'YES' or 'NO'");
        string loanDecide = Console.ReadLine();

        if (loanDecide == "YES")
        {
            Console.WriteLine("Loan amount:");
            decimal loanAmount = decimal.Parse(Console.ReadLine());

            if (newAcc.Debt != 0) { newAcc.Debt += loanAmount; }
            else { newAcc.Debt = loanAmount; }

            newAcc.Balance = loanAmount;
            Console.WriteLine($"Current debt: {newAcc.Debt.ToString("0.00")}");
        }
    }
}
