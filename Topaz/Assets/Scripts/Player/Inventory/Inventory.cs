using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Items;

namespace Assets.Scripts.Player
{
    public class Inventory : MonoBehaviour
    {
        System.Random rand = new System.Random();
        public GameObject window;

        bool visible;

        PlayerController playerController;
        CameraController cameraController;

        Collectable[,] items;

        // These will be used to keep track of where the next free location
        // in the 2d array is without constantly looping through it
        int freeColumn = 0;
        int freeRow = 0;

        // Is the inventory full?
        bool full;

        void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
            cameraController = FindObjectOfType<CameraController>();

            items = new Collectable[4, 6];
            full = false;
            visible = false;
        }

        public void AddItem(Collectable item)
        {
            Debug.Log("");
            if (full)
            {
                Debug.Log("Nah bro, this bag is full.");
                return;
            }

            // The item only occupies one inventory space
            if (item.Size == 1)
            {
                Debug.Log("Adding item at [" + freeColumn + ", " + freeRow + "]");
                items[freeColumn, freeRow] = item;

                // If the item is occupying the last row of this column,
                // move to the next row
                if (freeRow >= items.GetLength(1) - 1)
                {
                    // If the item is in the last column, we are either full
                    // or there is a free space somewhere else
                    if (freeColumn >= items.GetLength(0) - 1)
                    {
                        bool anotherFreeSpace = CheckForFreeSpaces();

                        // If there are no other free spaces, we are full
                        if (!anotherFreeSpace)
                        {
                            Debug.Log("We are now full");
                            full = true;
                        }
                    }

                    // If the first space in the next column is free,
                    // that is our next free space
                    else if (items[freeColumn + 1, 0] == null)
                    {
                        freeRow = 0;
                        freeColumn++;
                        Debug.Log("Moving to next column " + freeColumn);
                    }
                }

                // If the next space is free, that is our next free space
                else if (items[freeColumn, freeRow + 1] == null)
                {
                    freeRow++;
                    Debug.Log("Moving to next row " + freeRow);
                }

                // This means the next space is not free and we need to see if other
                // spaces are available
                else
                {
                    bool anotherFreeSpace = CheckForFreeSpaces();

                    // If there are no other free spaces, we are full
                    if (!anotherFreeSpace)
                    {
                        full = true;
                        Debug.Log("We are now full");
                    }
                }
            }
        }

        public void RemoveItem(Collectable item)
        {
        }

        // For testing purposes only
        void RemoveAtRandom()
        {
            List<int[]> occupiedSpaces = new List<int[]>();

            for (int column = 0; column < items.GetLength(0); column++)
                for (int row = 0; row < items.GetLength(1); row++)
                    if (items[column, row] != null)
                        occupiedSpaces.Add(new int[2] { column, row });

            if (occupiedSpaces.Count == 0)
                return;

            Debug.Log("");
            var randomSpace = occupiedSpaces[rand.Next(0, occupiedSpaces.Count)];
            items[randomSpace[0], randomSpace[1]] = null;
            Debug.Log("Removed item at [" + randomSpace[0] + ", " + randomSpace[1] + "]");
            bool freeSpace = CheckForFreeSpaces();
            full = !freeSpace;
        }

        bool CheckForFreeSpaces()
        {
            Debug.Log("Checking for free spaces...");
            for (int column = 0; column < items.GetLength(0); column++)
            {
                for (int row = 0; row < items.GetLength(1); row++)
                {
                    if (items[column, row] == null)
                    {
                        freeColumn = column;
                        freeRow = row;
                        Debug.Log("Free space found at [" + freeColumn + ", " + freeRow + "]");
                        return true;
                    }
                }
            }
            Debug.Log("No free spaces found.");
            return false;
        }

        void ToggleVisibility()
        {
            visible = !visible;
            if (visible)
            {
                window.SetActive(true);
                playerController.Disable();
                cameraController.Disable();
            }
            else
            {
                window.SetActive(false);
                playerController.Enable();
                cameraController.Enable();
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleVisibility();
            }

            // Remove a random item
            if (Input.GetKeyDown(KeyCode.O))
            {
                RemoveAtRandom();
            }

            // Add a random apple
            if (Input.GetKeyDown(KeyCode.P))
            {
                var apple = FindObjectOfType<Apple>();
                if (apple == null)
                {
                    Debug.Log("You picked up all the apples! Restart the scene.");
                    return;
                }
                AddItem(apple);
            }
        }
    }
}