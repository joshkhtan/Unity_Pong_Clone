using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{
    public void OnClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");
    }
}
