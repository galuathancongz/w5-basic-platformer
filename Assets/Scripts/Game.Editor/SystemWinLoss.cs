using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Editor
{
    public class SystemWinLoss : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject Creepy_1;
        public GameObject Creepy_2;
        public Slider sliderplayer;
        public GameObject Win;
        public GameObject Loss;
       
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Creepy_1 == null && Creepy_2 == null)
            {
                Win.SetActive(true);
            }
            if (sliderplayer.value <= 1)
            {
                Loss.SetActive(true);
            }
        }
    }
}
