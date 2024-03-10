using UnityEngine;
using System.Collections;
using System.IO;

public class TextureLoader : MonoBehaviour
{
    public string[] textureFolders; // Paths to folders containing textures

    void Start()
    {
        StartCoroutine(LoadTexturesAdditively());
    }

    IEnumerator LoadTexturesAdditively()
    {
        Debug.Log(textureFolders.Length);
        foreach (string folderPath in textureFolders)
        {
            string[] texturePaths = Directory.GetFiles(Application.dataPath + "/" + folderPath, "*.png");

            Debug.Log("test");
            Debug.Log(texturePaths.Length);

            foreach (string texturePath in texturePaths)
            {
                // Load texture from file path
                byte[] fileData = File.ReadAllBytes(texturePath);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(fileData); // Load texture data

                // Do something with the loaded texture, e.g., assign it to a material
            }
        }

        // Additive loading is complete, proceed with the game
        Debug.Log("All textures are loaded additively.");

        yield return null;
    }
}
