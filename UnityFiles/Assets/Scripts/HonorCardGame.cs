using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HonorCardGame : MonoBehaviour
{
    private List<string> deck = new List<string>();
    private List<string> hand = new List<string>();

    private void Start()
    {
        CreateDeck();
        ShuffleDeck();
        DrawOpeningHand();

        Debug.Log("I made the initial deck and draw. My hand is: " + string.Join(", ", hand) + ".");

        while (true)
        {
            if (IsWinningHand())
            {
                Debug.Log("My hand is: " + string.Join(", ", hand) + ". The game is WON.");
                break;
            }

            if (deck.Count == 0)
            {
                Debug.Log("The deck is empty. The game is LOST.");
                break;
            }

            int discardIndex = Random.Range(0, hand.Count);
            string discardedCard = hand[discardIndex];
            hand.RemoveAt(discardIndex);

            string drawnCard = deck[0];
            deck.RemoveAt(0);
            hand.Add(drawnCard);

            if (IsWinningHand())
            {
                Debug.Log("I discarded " + discardedCard +
                          " and drew " + drawnCard +
                          ". My hand is: " + string.Join(", ", hand) +
                          ". The game is WON.");
                break;
            }
            else
            {
                Debug.Log("I discarded " + discardedCard +
                          " and drew " + drawnCard +
                          ". My hand is: " + string.Join(", ", hand) +
                          ". This is not a winning hand. I will attempt to play another round.");
            }
        }
    }

    private void CreateDeck()
    {
        deck.Clear();
        hand.Clear();

        string[] ranks = { "K", "Q", "J", "A" };
        string[] suits = { "\u2660", "\u2663", "\u2665", "\u2666" };

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                deck.Add(rank + suit);
            }
        }
    }

    private void ShuffleDeck()
    {
        deck = deck.OrderBy(card => Random.value).ToList();
    }

    private void DrawOpeningHand()
    {
        for (int i = 0; i < 4; i++)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }
    }

    private bool IsWinningHand()
    {
        var suitCounts = hand
            .GroupBy(card => card.Substring(card.Length - 1))
            .Select(group => group.Count());

        return suitCounts.Any(count => count >= 3);
    }
}
