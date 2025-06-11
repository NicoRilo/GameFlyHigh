using UnityEngine;
using UnityEngine.UI;

public class SpriteSelector : MonoBehaviour
{
    public Sprite[] availableSprites;
    public Image previewImage;
    private int selectedIndex = 0;


    void Start()
    {
        // Cargamos el índice seleccionado previamente guardado en PlayerPrefs
        selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        // Actualizamos la imagen de vista previa con el sprite seleccionado
        UpdatePreview();
    }

    // Método para seleccionar el siguiente sprite
    public void NextSprite()
    {
        // Incrementamos índice y usamos módulo para que vuelva al principio si supera el límite
        selectedIndex = (selectedIndex + 1) % availableSprites.Length;
        // Guardamos la selección en PlayerPrefs
        SaveSelection();
        // Actualizamos la vista previa
        UpdatePreview();
    }

    // Método público para seleccionar el sprite anterior
    public void PreviousSprite()
    {
        // Decrementamos índice y usamos módulo para que vuelva al final si pasa por debajo de 0
        selectedIndex = (selectedIndex - 1 + availableSprites.Length) % availableSprites.Length;
        SaveSelection();
        UpdatePreview();
    }

    // Guarda la selección actual en PlayerPrefs
    private void SaveSelection()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);
        PlayerPrefs.Save();
    }

    // Actualiza la imagen de vista previa para mostrar el sprite seleccionado
    void UpdatePreview()
    {
        previewImage.sprite = availableSprites[selectedIndex];
    }
}
