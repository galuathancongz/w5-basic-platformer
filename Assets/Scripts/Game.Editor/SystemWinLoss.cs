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
        public GameObject Creepy_3;
        public GameObject Creepy_4;
        public Slider sliderplayer;
        public GameObject Win;
        public GameObject Loss;
       
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Creepy_4 == null && Creepy_3 == null && Creepy_1 == null && Creepy_2 == null)
            {
                Creepy_3.SetActive(false);
                Creepy_4.SetActive(false);
                Win.SetActive(true);
            }
            else if (Creepy_3 == null && Creepy_1 == null && Creepy_2 == null)
            {
                
                Creepy_4.SetActive(true);
            }
            else if (Creepy_1 == null && Creepy_2 == null)
            {
                Creepy_3.SetActive(true);
            }
          
            
            if (sliderplayer.value <= 1)
            {
                Loss.SetActive(true);
            }
        }
    }
}
