using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blackjack.Program;

namespace Blackjack
{
    internal class Program
    {
        public class Card
        {
            string name;
            int num;
            public string Name { get; set; }
            public int Num { get; set; }
            public Card(string name, int num)
            {
                Name = name;
                Num = num;
            }
        }
        public class PackOfCards
        {
            public List<Card> cards = new List<Card>();
            Card six = new Card("six", 6);
            Card seven = new Card("seven", 7);
            Card eight = new Card("eight", 8);
            Card nine = new Card("nine", 9);
            Card ten = new Card("ten", 10);
            Card jack = new Card("jack", 10);
            Card queen = new Card("queen", 10);
            Card king = new Card("king", 10);
            Card ace = new Card("ace", 1);
            public List<Card> Cards { get => cards; set => cards = value; }
            public PackOfCards()
            {
                List<Card>Cards = new List<Card>();
                for (int i = 0; i < 4; i++)
                {
                    cards.Add(six);
                    cards.Add(seven);
                    cards.Add(eight);
                    cards.Add(nine);
                    cards.Add(ten);
                    cards.Add(jack);
                    cards.Add(queen);
                    cards.Add(king);
                    cards.Add(ace);
                }
            }
        }

        public class Player
        {
            List<Card> cards = new List<Card>();
            Player player;
            public List<Card> PCards { get => cards; set => cards = value; }
            public Player(PackOfCards pack) 
            {
                for (int i = 0; i < 5; i++)
                {
                    Random random = new Random();
                    int index = random.Next(pack.Cards.Count);
                    PCards.Add(pack.Cards[index]);
                    pack.Cards.RemoveAt(index); 
                }
            }
            public List<string> MyCards()
            {
                List<string> mycards = new List<string>();
                for (int i = 0; i < PCards.Count; i++)
                {
                    mycards.Add(PCards[i].Name);
                }
                return mycards;
            }
            public int TotalSum()
            {
                int sum = 0;
                for (int i = 0; i < PCards.Count; i++)
                {
                    sum += PCards[i].Num;
                }
                return sum;
            }
            public int TakeACard(PackOfCards pack)
            {
                Random random = new Random();
                int index = random.Next(pack.Cards.Count);
                PCards.Add(pack.Cards[index]);
                pack.Cards.RemoveAt(index);
                return TotalSum();
            }
            public void Chip2(string card2, int num2) 
            {
                Console.WriteLine("Choose a card to change:");
                string change = Console.ReadLine();
                for (int i = 0; i < PCards.Count; i++)
                {
                    if (PCards[i].Name == change)
                    {
                        PCards.RemoveAt(i);
                        Card newcard = new Card(card2, num2);
                        PCards.Add(newcard);
                    }
                }
            }
        }
        public class Game
        {
            public PackOfCards pack = new PackOfCards();
            public Game() { }
            public void Start()
            {
                Console.WriteLine("New game");
            }
            public void Chip1(Player player1, Player player2)
            {
                List<Card> cards3 = player1.PCards;
                player1.PCards = player2.PCards;
                player2.PCards = cards3;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 'Take a card', чтобы взять ещё одну карту");
            Console.WriteLine("Введите 'Break', чтобы остановиться");
            Console.WriteLine("Введите 'Chip 1', чтобы поменяться картами с другим игроком");
            Console.WriteLine("Введите 'Chip 2', чтобы забрать любую карту у другого игрока");
            Console.WriteLine();
            Game game = new Game();
            PackOfCards pack = new PackOfCards();
            Player player1 = new Player(pack);
            Player player2 = new Player(pack);
            game.Start();
            bool x = true;
            bool y = true;
            while (true)
            {
                while (x == true)
                {
                    Console.WriteLine();
                    if(player1.TotalSum() <= 60)
                    {
                        Console.Write($"Player1\nCards: ");
                        for (int i = 0; i < player1.MyCards().Count; i++)
                        {
                            Console.Write($"{player1.MyCards()[i]} ");
                        }
                        Console.WriteLine($"; Total: {player1.TotalSum()}");
                        string a = Console.ReadLine();
                        if (a == "Take a card")
                        {
                            player1.TakeACard(pack);
                            if (player1.TotalSum() <= 60)
                            {
                                Console.Write($"Cards: ");
                                for (int i = 0; i < player1.MyCards().Count; i++)
                                {
                                    Console.Write($"{player1.MyCards()[i]} ");
                                }
                                Console.WriteLine($"; Total: {player1.TotalSum()}");
                                break;
                            } else
                            {
                                x = false;
                                y = false;
                            }
                        }
                        else if (a == "Break")
                        {
                            x = false;
                            break;
                        } else if (a == "Chip 1")
                        {
                            if (y != false)
                            {
                                game.Chip1(player1, player2);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Обмен невозможен. Игрок воспользовался фишкой Break. Введите другую команду.");
                            }
                        } else if (a == "Chip 2")
                        {
                            Card card1 = player1.PCards[player1.MyCards().Count - 1];
                            player1.PCards.RemoveAt(player1.PCards.Count - 1);
                            player1.PCards.Add(player2.PCards[player2.PCards.Count - 1]);
                            player2.PCards.RemoveAt(player2.PCards.Count - 1);
                            player2.PCards.Add(card1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error. Try again");
                        }
                    } else
                    {
                        x = false;
                    }
                }
                while (y == true)
                {
                    Console.WriteLine();
                    if (player2.TotalSum() <= 60)
                    {
                        Console.Write($"Player2.\nCards: ");
                        for (int i = 0; i < player2.MyCards().Count; i++)
                        {
                            Console.Write($"{player2.MyCards()[i]} ");
                        }
                        Console.WriteLine($"; Total: {player2.TotalSum()}");
                        string a = Console.ReadLine();
                        if (a == "Take a card")
                        {
                            player2.TakeACard(pack);
                            if (player2.TotalSum() <= 60)
                            {
                                Console.Write($"Cards: ");
                                for (int i = 0; i < player2.MyCards().Count; i++)
                                {
                                    Console.Write($"{player2.MyCards()[i]} ");
                                }
                                Console.WriteLine($"; Total: {player2.TotalSum()}");
                                break;
                            }
                            else
                            {
                                x = false;
                                y = false;
                            }
                        } else if (a == "Chip 1")
                        {
                            if (x != false)
                            {
                                game.Chip1(player2, player1);
                                break;
                            } else
                            {
                                Console.WriteLine("Обмен невозможен. Игрок воспользовался фишкой Break. Введите другую команду.");
                            }
                        }
                        else if (a == "Chip 2")
                        {
                            Card card1 = player2.PCards[player2.MyCards().Count - 1];
                            player2.PCards.RemoveAt(player2.PCards.Count - 1);
                            player2.PCards.Add(player1.PCards[player1.PCards.Count - 1]);
                            player1.PCards.RemoveAt(player1.PCards.Count - 1);
                            player1.PCards.Add(card1);
                            break;
                        }
                        else if (a == "Break")
                        {
                            y = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    } else
                    {
                        y = false;
                    }
                }
                if (x == false && y == false)
                {

                    if (player1.TotalSum() <= 60 && player2.TotalSum() <= 60)
                    {
                        if (player1.TotalSum() > player2.TotalSum())
                        {
                            Console.WriteLine("\nWinner: Player 1.\n");
                        }
                        else if (player2.TotalSum() > player1.TotalSum())
                        {
                            Console.WriteLine("\nWinner: Player 2.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nDraw.\n");
                        }
                    }else
                    {
                        if (player1.TotalSum() > 60)
                        {
                            Console.WriteLine("\nWinner: Player 2.\n");
                        }
                        else if (player2.TotalSum() > 60)
                        {
                            Console.WriteLine("\nWinner: Player 1.\n");
                        }
                    }
                    pack = new PackOfCards();
                    player1 = new Player(pack);
                    player2 = new Player(pack);
                    x = true; y = true;
                    game.Start();
                }
            }
        }
    }
}