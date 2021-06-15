using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;

public class Group : MonoBehaviour
{
    // Time since last gravity tick
    public float lastFall = 0;
    public float speedOfTetr; //к ней нужен доступ из скрипта ChangeSpeed 
  
    public GameObject goSceneSwap;
    public SceneSwap changeSpeedInSwap;    

    bool isValidGridPos() 
    {        
        foreach (Transform child in transform) {
            Vector2 v = Playfield.roundVec2(child.position);

            // Not inside Border?
            if (!Playfield.insideBorder(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (Playfield.grid[(int)v.x, (int)v.y] != null &&
                Playfield.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }
    

    public void GetSpeedFromSwap()
    {
        // Найти объект по имени
        // GameObject go = GameObject.Find(ChangeSpeed);
        // взять его компонент где лежит скорость
        changeSpeedInSwap = goSceneSwap.GetComponent<SceneSwap>();
        // взять переменную скорости
        changeSpeedInSwap.SpeedInSeconds();   
        // Debug.Log("changeSpeedInSetOfGetSpeedFromChangeSpeed="+ changeSpeedInSet); 
        SpeedOfTetr();
        // Debug.Log("speedInSecondsOfGetSpeedFromChangeSpeed="+ speedInSeconds); 
    } 
    public void SpeedOfTetr()
    {
        float speedOfTetr = Convert.ToSingle(changeSpeedInSwap);
    }
    

    void Start() 
    {       
        GetSpeedFromSwap();   
        Debug.Log("SpeedOfTetr="+ speedOfTetr);  
        
        // Default position not valid? Then it's game over
        if (!isValidGridPos()) {
            Debug.Log("GAME OVER");
            // Debug.Log("timeForSpeedInGroup = "+ timeForSpeed);
            // Debug.Log("speedInSecondsInGroup="+speedInSeconds);
            Destroy(gameObject);
            SceneManager.LoadScene(3);                                          
        }
    }
    void Update() 
    {        
        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);
        
            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            // Modify position
            transform.position += new Vector3(1, 0, 0);
        
            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Rotate(0, 0, -90);
        
            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                    Time.time - lastFall >= speedOfTetr)               
                {                    
                // Modify position
                transform.position += new Vector3(0, -1, 0);

                // See if valid
                if (isValidGridPos()) {
                    // It's valid. Update grid.
                    updateGrid();
                } 
                else 
                {
                    // It's not valid. revert.
                    transform.position += new Vector3(0, 1, 0);

                    // Clear filled horizontal lines
                    Playfield.deleteFullRows();

                    // Spawn next Group
                    FindObjectOfType<Spawner>().spawnNext();

                    // Disable script
                    enabled = false;
                }

            lastFall = Time.time;
        }
    }
    void updateGrid() 
    {
        // Remove old children from grid
        for (int y = 0; y < Playfield.h; ++y)
            for (int x = 0; x < Playfield.w; ++x)
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform) {
            Vector2 v = Playfield.roundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }        
    }        
}
