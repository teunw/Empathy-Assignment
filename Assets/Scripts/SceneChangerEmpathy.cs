using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneChangerEmpathy : MonoBehaviour
    {
        public void ChangeToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}