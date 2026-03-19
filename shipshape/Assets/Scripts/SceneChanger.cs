using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdusing UnityEngine;
 public void NextScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
