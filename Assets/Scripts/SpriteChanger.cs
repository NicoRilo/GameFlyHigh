using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    public Sprite[] backgroundSprites;
    public SpriteRenderer backgroundRenderer;

    void Start()
    {
        // Obtenemos el índice del personaje seleccionado guardado en PlayerPrefs
        int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        
        if (selectedIndex < characterPrefabs.Length)
        {
             // Instanciamos el prefab del personaje seleccionado en el punto spawn con rotación neutra
            Instantiate(characterPrefabs[selectedIndex], spawnPoint.position, Quaternion.identity);
        }

        if (selectedIndex < backgroundSprites.Length && backgroundRenderer != null)
        {
            // Asignamos el sprite de fondo correspondiente al personaje seleccionado
            backgroundRenderer.sprite = backgroundSprites[selectedIndex];
        }
    }
}
