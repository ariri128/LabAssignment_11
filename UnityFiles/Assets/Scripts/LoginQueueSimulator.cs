using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LoginQueueSimulator : MonoBehaviour
{
    private static string[] firstNames =
    {
        "Carol", "Adam", "Maria", "John", "Leila",
        "Sophia", "Ethan", "Olivia", "Liam", "Emma",
        "Noah", "Ava", "Mason", "Mia", "Lucas",
        "Isabella", "Elijah", "Charlotte", "James", "Amelia",
        "Benjamin", "Harper", "Daniel", "Evelyn", "Henry", "Grace"
    };

    private static string[] lastInitials =
    {
        "A","B","C","D","E","F","G","H","I","J","K","L","M",
        "N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
    };

    private Queue<string> loginQueue = new Queue<string>();

    private void Start()
    {
        int startingPlayers = Random.Range(4, 7);

        for (int i = 0; i < startingPlayers; i++)
        {
            loginQueue.Enqueue(GetRandomPlayerName());
        }

        List<string> queueList = loginQueue.ToList();

        Debug.Log("Initial login queue created. There are " +
                  loginQueue.Count +
                  " players in the queue: " +
                  string.Join(", ", queueList));

        StartCoroutine(AddPlayerRoutine());
        StartCoroutine(LoginPlayerRoutine());
    }

    private IEnumerator AddPlayerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            string newPlayer = GetRandomPlayerName();
            loginQueue.Enqueue(newPlayer);

            Debug.Log(newPlayer + " is trying to login and added to the login queue.");
        }
    }

    private IEnumerator LoginPlayerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            if (loginQueue.Count > 0)
            {
                string playerInside = loginQueue.Dequeue();
                Debug.Log(playerInside + " is now inside the game.");
            }
            else
            {
                Debug.Log("Login server is idle. No players are waiting.");
            }
        }
    }

    private string GetRandomPlayerName()
    {
        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        string initial = lastInitials[Random.Range(0, lastInitials.Length)];
        return firstName + " " + initial + ".";
    }
}
