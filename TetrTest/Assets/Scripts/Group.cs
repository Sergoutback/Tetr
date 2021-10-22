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
    public float delta;  
    public GameObject goDontDestroy;
    public DontDestroy changeSpeedInDontDestroy;    

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
    

    public void GetSpeedFromDontDestroy()
    {
        
        //changeSpeedInDontDestroy = goDontDestroy.GetComponent<DontDestroy>();
        
        //changeSpeedInDontDestroy.SpeedInDontDestroy();   
        
        SpeedOfTetr();
        Debug.Log("speedOfTetr="+ speedOfTetr);  
        
    } 
    public void SpeedOfTetr()
    {
        float speedOfTetr = Convert.ToSingle(changeSpeedInDontDestroy);
    }

    public void Swipe()
    {
        Vector2 delta = Input.GetTouch(0).deltaPosition;

        if ((int)((Mathf.Abs(delta.x))) > (int)(Mathf.Abs(delta.y)))
        {
            if (delta.x > 0)
            {
                MoveRight();
                Debug.Log("right");
            }
            else
            {
                MoveLeft();
                Debug.Log("left");
            }
        }
        else
        {
            if (delta.y > 0)
            {
                Rotate();
                Debug.Log("up");
            }
            else
            {
                DownwardsandFall();
                Debug.Log("down");
            }
        }
    }
    

    void Start() 
    {       
        GetSpeedFromDontDestroy();
        // GetSpeedFromSwap();           
        Debug.Log("changeSpeedInDontDestroy="+ changeSpeedInDontDestroy);  
        
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
        Swipe();

        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }        

        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }        

        // Rotate
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Rotate();
        }        

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                    Time.time - lastFall >=1 )        //instead of a number use  speedOfTetr;
        {
            DownwardsandFall();
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
    public void MoveLeft()
    {
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
    public void MoveRight()
    {
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
    public void Rotate()
    {
        transform.Rotate(0, 0, -90);

        // See if valid
        if (isValidGridPos())
            // It's valid. Update grid.
            updateGrid();
        else
            // It's not valid. revert.
            transform.Rotate(0, 0, 90);
    }
    public void DownwardsandFall()
    {                    
        // Modify position
        transform.position += new Vector3(0, -1, 0);

        // See if valid
        if (isValidGridPos()) 
            {
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
