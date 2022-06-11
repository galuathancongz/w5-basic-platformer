using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


namespace Game.Editor
{
    public class Replay : MonoBehaviour
    {
        public Button button;
        // Start is called before the first frame update
        void Start()
        {
            button.onClick.AddListener(RestartLevel);
        }
        void RestartLevel() //Restarts the level
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
