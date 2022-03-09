using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Problems_day_11_and_12
{
    internal class DeckOfCardQueue
    {
          public DeckCardQueue()
        {
            ///Create DeckOfCard Class Object 
            DeckOfCard DeckOfCardObject = new DeckOfCard();
            string[] Deck = DeckOfCardObject.Play();//By using DeckOfCard refence call Play() method Present inside the DeckOfCard class
            string[] ShuffleCardDeck = DeckOfCardObject.CardShuffle(Deck);//Call CardShuffle method and it returns Shuffle card string array
            int Player = 1, k = 0;

            //create Queue object
            if (players == null)
            {
                players = new Queue<Player>();
            }
            //Add Player class object and object content into the Queue
            for (int i = 1; i <= 4; i++)
            {
                Player p = new Player();
                p.player = "Player " + (Player++);
                for (int j = 0; j < 9; j++)
                {
                    p.Cards[j] = ShuffleCardDeck[k++]; //Distrubute 9 card for each player 
                }
                players.Enqueue(p);//Add Player object into the  Queue
            }
            //Display Each players cards
            foreach (var Print in players)
            {
                Console.WriteLine(Print + "\n");
            }
        }
    }
}
