using UnityEngine;

public class TextLevelGenerator : MonoBehaviour
{
    [SerializeField] TextAsset levelText;
    [SerializeField] Vector3 startPosition;
    [SerializeField] CharToPrefab[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        string[] levelStrings = levelText.text.Split('\n');

        for (int y = 0; y < levelStrings.Length; ++y)
        {
            string rowLineText = levelStrings[y];
            char[] chars = rowLineText.ToCharArray();

            for (int x = 0; x < chars.Length; ++x)
            {
                char charText = chars[x];

                PlacePrefab(charText, x, y);
            }
        }
    }

    public void PlacePrefab(char symbol, int xPosition, int yPosition)
    {
        foreach (CharToPrefab prefab in prefabs)
        {
            if (prefab.character.Equals(symbol))
            {
                Vector2 position = startPosition + new Vector3(xPosition, -yPosition);
                Instantiate(prefab.prefab, position, Quaternion.identity);
            }
        }
    }
}