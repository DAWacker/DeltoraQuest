using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Player;

public class InventoryVisualization : MonoBehaviour
{
    public UIAtlas atlas;

    PlayerController playerController;
    CameraController cameraController;

    int numRows = 6;
    int numColumns = 4;

    float squareWidth = 49.0f;
    float squareHeight = 49.0f;

    bool visible;

    List<GameObject> sprites;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        cameraController = FindObjectOfType<CameraController>();
        visible = false;

        CreateInventory();
    }

    void CreateInventory()
    {
        for (int column = 0; column < numColumns; column++)
        {
            for (int row = 0; row < numRows; row++)
            {
                var inventorySquare = new GameObject("Square");
                var sprite = inventorySquare.AddComponent<UISprite>();
                sprite.atlas = atlas;
                sprite.spriteName = "empty";
                sprite.MakePixelPerfect();

                inventorySquare.transform.parent = gameObject.transform;
                inventorySquare.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                inventorySquare.transform.localPosition = new Vector3(column * squareWidth, -row * squareHeight, 0.0f);
            }
        }

        sprites = gameObject.GetComponentsInChildren<UISprite>()
            .Select(s => s.gameObject)
            .ToList();
        sprites.ForEach(g => g.SetActive(visible));
    }

    public void AddItem(int column, int row, string imageName)
    {
        var item = new GameObject(imageName);
        var sprite = item.AddComponent<UISprite>();
        sprite.atlas = atlas;
        sprite.spriteName = imageName;
        sprite.depth = 2;
        sprite.MakePixelPerfect();

        item.transform.parent = gameObject.transform;
        item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        item.transform.localPosition = new Vector3(column * squareWidth, -row * squareHeight, 0.0f);

        sprites.Add(item);
        item.SetActive(false);
    }

    public void ToggleVisibility()
    {
        visible = !visible;
        if (visible)
        {
            playerController.Disable();
            cameraController.Disable();
        }
        else
        {
            playerController.Enable();
            cameraController.Enable();
        }
        sprites.ForEach(g => g.SetActive(visible));
    }
}