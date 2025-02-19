using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager 
{
    public class SceneManager : Singletons<SceneManager>
    {
        public void LoadScene(SceneName sceneName, bool isSingle)
        {
            LoadSceneMode loadSceneMode = isSingle ? LoadSceneMode.Single : LoadSceneMode.Additive;
            StartCoroutine(Load(sceneName, loadSceneMode));
        }
        
        IEnumerator Load(SceneName sceneName , LoadSceneMode loadSceneMode)
        {
            yield return null;
            AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName.ToString(), loadSceneMode);
            asyncOperation.allowSceneActivation = false;
            while(!asyncOperation.isDone)
            {
                if(asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation=true;
                    Say.say("µã»÷¿ªÊ¼",MessagesColor.Red);
                }
                yield return null;
            }

        }
    }
}
