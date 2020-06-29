using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tetramino : MonoBehaviour
{

    public Vector3 rotationPoint;
    private float previousTime; // For vertical movement
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 90);
            if (!ValidMove())
            {
                transform.Rotate(0, 0, -90);
            }
        }


        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime)) // When down key is pressed the tetromino falls more fast
        {
            transform.position += new Vector3(0, -1, 0); //Made the tetromino fall
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;
                FindObjectOfType<SpawnTetramino>().NewTetromino();
            }
            previousTime = Time.time;
        }

        void CheckForLines()
        {
            for (int i = height -1; i >= 0; i--)
            {
                if(HasLines(i))
                {
                    DeleteLines(i);
                    RowDown(i);

                }
            }
        }

        bool HasLines(int i)
        {
            for(int j = 0; j < width; j++)
            {
                if (grid[j, i] == null)
                    return false;
            }
            return true;
        }

        void DeleteLines(int i)
        {
            for (int j = 0; j < width; j++)
            {
                Destroy(grid[j, i].gameObject);
                grid[j, i] = null;
            }
        }

        void RowDown(int i)
        {
            for (int y = i; y < height; y++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (grid[j, y] != null)
                    {
                        grid[j, y - 1] = grid[j, y];
                        grid[j, y] = null;
                        grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                    }
                }
            }
        }

        void AddToGrid()
        {
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);
                grid[roundedX, roundedY] = children;
            }
            CheckEndGame();
        }
    }

    void CheckEndGame()
    {
        // For every block in the column
        for (int j = 0; j < width; j++)
        {
            // Check to see if there are any blocks in the highest row
            if (grid[j, height - 1] != null)
            {
                // If there are blocks at the top, the game is over
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    // Check if the tetromino is inside the grid
    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height) // If it is bigger than the grid size, will return false
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null) // if its already taken
            {
                return false;
       
            }
        }
        return true;
    }
}