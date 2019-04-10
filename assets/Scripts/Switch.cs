using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public void switch1()
    {
        SceneManager.LoadScene(1);
    }
    public void switch2()
    {
        SceneManager.LoadScene(2);
    }
}
