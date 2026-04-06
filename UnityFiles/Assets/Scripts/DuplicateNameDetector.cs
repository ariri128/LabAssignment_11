using UnityEngine;
using System.Collections.Generic;

public class DuplicateNameDetector : MonoBehaviour
{
    private static string[] firstNames =
    {
        "Carol", "Adam", "Maria", "John", "Leila",
        "Sophia", "Ethan", "Olivia", "Liam", "Emma",
        "Noah", "Ava", "Mason", "Mia", "Lucas",
        "Isabella", "Elijah", "Charlotte", "James", "Amelia",
        "Benjamin", "Harper", "Daniel", "Evelyn", "Henry", "Grace"
    };

    private void Start()
    {
        List<string> randomNames = new List<string>();

        for (int i = 0; i < 15; i++)
        {
            string randomName = firstNames[Random.Range(0, firstNames.Length)];
            randomNames.Add(randomName);
        }

        Debug.Log("Created the name array: " + string.Join(", ", randomNames));

        HashSet<string> seen = new HashSet<string>();
        HashSet<string> duplicates = new HashSet<string>();

        foreach (string name in randomNames)
        {
            if (!seen.Add(name))
            {
                duplicates.Add(name);
            }
        }

        if (duplicates.Count > 0)
        {
            Debug.Log("The array has duplicate names: " + string.Join(", ", duplicates));
        }
        else
        {
            Debug.Log("The array has no duplicate names.");
        }
    }
}
