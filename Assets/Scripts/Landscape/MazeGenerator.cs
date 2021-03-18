using UnityEngine;
using UnityEditor;
using System.IO;

public class MazeGenerator : MonoBehaviour
{
    public GameObject prefabTop;
    public GameObject prefabTopLeftToDownRigth;
    public GameObject prefabTopRightToDownLeft;
    public GameObject parent;

    void Start()
    {
        StreamReader reader = new StreamReader("./Assets/Scripts/Landscape/Maze2.txt");
        string itemStrings = reader.ReadToEnd();
        int switcher = 0;
        float xpos = 0;
        float ypos = 0;
        float xincrement = 5;
        float yincrement = -4.5f;
        foreach(char c in itemStrings)       
        {
            switch (switcher)
            {
                case 0: //Top
                    xpos += xincrement;
                    if(c == 'T')
                    {
                        GameObject obj = Instantiate(prefabTop, new Vector3(xpos,ypos,0), Quaternion.identity);
                        obj.transform.parent = parent.transform;
                    }
                    if(c == '\n')
                    {
                        switcher++;
                        xpos = -5;
                    }    
                break;

                case 1: //Diagonals
                    xpos += xincrement;
                    if(c == 'L')
                    {
                        GameObject obj = Instantiate(prefabTopRightToDownLeft, new Vector3(xpos,ypos,0), Quaternion.identity);
                        obj.transform.parent = parent.transform;

                    }
                    else if(c == 'R')
                    {
                        GameObject obj = Instantiate(prefabTopLeftToDownRigth, new Vector3(xpos,ypos,0), Quaternion.identity);
                        obj.transform.parent = parent.transform;

                    }
                    
                    if(c == '\n')
                    {
                        switcher=0;
                        xpos = 0;
                        ypos += yincrement;
                    }
                break;

                // case 2: //Middle
                //     if(c == '*')
                //     {
                //         Instantiate(prefabTop, new Vector3(xpos,ypos,0), Quaternion.identity);
                //     }
                //     xpos += xincrement;
                //     if(c == '\n')
                //     {
                //         switcher++;
                //         xpos = -5;
                //     }
                // break;

                // case 3:
                //     if(c == '*')
                //     {
                //         Instantiate(prefabTop, new Vector3(xpos,ypos,0), Quaternion.identity);
                //     }
                //     xpos += xincrement;
                //     if(c == '\n')
                //     {
                //         switcher++;
                //         xpos = -5;
                //         ypos += yincrement;
                //     }
                // break;

                // case 4:
                // if(c == '*')
                //     {
                //         Instantiate(prefabTop, new Vector3(xpos,ypos,0), Quaternion.identity);
                //     }
                //     xpos += xincrement;
                //     if(c == '\n')
                //     {
                //         switcher = 0;
                //         xpos = -5;
                //     }
                // break;
            }
        }
    }
   
}
