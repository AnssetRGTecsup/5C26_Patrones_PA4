using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleTransition : MonoBehaviour
{
    [SerializeField] private string newScene;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(newScene);
    }
}
