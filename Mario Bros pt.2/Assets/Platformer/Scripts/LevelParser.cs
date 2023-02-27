using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject fireBall;
    public GameObject end;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top

        int rows = levelRows.Count;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (int column = 0; column < letters.Length; column++)
            {
                var letter = letters[column];
                switch (letter)
                {
                    case 'x':
                    {
                        Instantiate(rockPrefab, new Vector3(0, rows - levelRows.Count, column), Quaternion.identity);
                        break;
                    }

                    case 'b':
                    {
                        Instantiate(brickPrefab, new Vector3(0, rows - levelRows.Count, column), Quaternion.identity);
                        break;
                    }

                    case '?':
                    {
                        Instantiate(questionBoxPrefab, new Vector3(0, rows - levelRows.Count, column), Quaternion.identity);
                        break;
                    }

                    case 's':
                    {
                        Instantiate(stonePrefab, new Vector3(0, rows - levelRows.Count, column), Quaternion.identity);
                        break;
                    }
                    
                    case 'f':
                    {
                        Instantiate(fireBall, new Vector3(0, rows - levelRows.Count, column), Quaternion.identity);
                        break;
                    }
                    
                    case 'e':
                    {
                        Instantiate(end, new Vector3(0, rows - levelRows.Count, column), Quaternion.identity);
                        break;
                    }
                }
                
            }
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
