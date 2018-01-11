using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneChangerEmpathy : MonoBehaviour
    {
        private string _sceneName;
        
        public void SetScene(string sceneName)
        {
            this._sceneName = sceneName;
        }

        public void ChangeToSceneAfter(float afterTime = 2.0f)
        {
            StartCoroutine(this.ChangeToSceneAfterEnum(afterTime));
        }

        private IEnumerator ChangeToSceneAfterEnum(float afterTime = 2.0f)
        {
            var sceneAysnc = SceneManager.LoadSceneAsync(this._sceneName);
            sceneAysnc.allowSceneActivation = false;
            yield return new WaitForSeconds(afterTime);
            sceneAysnc.allowSceneActivation = true;
        }
    }
}