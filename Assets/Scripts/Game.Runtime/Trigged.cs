using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game.Runtime
{
    public class Trigged : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;
        public Animator animator;
        float tdgy;
        bool moveGoal=true;
        public LayerMask playerLayer;
        public GameObject HPBonus;
        public GameObject Bang;
        public static GameObject a ;

        // Start is called before the first frame update
        void Start()
        {
            
            tdgy = transform.localPosition.y;
        }
       
        public void Hit(float values)
        {
            slider.value -= values;
            animator.SetTrigger("Hurt");
            if (slider.value <= 1)
            {
                Destroy(gameObject);
                Instantiate(Bang, transform.position, Quaternion.identity);
                a = Instantiate(HPBonus, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
            }
        }
        
        
        public void EnemyAttack()
        {
            animator.SetTrigger("Attack_1");
        }

        // Update is called once per frame
        void Update()
        {
            
            //dI CHUYEN
            if (moveGoal)
            {
                gameObject.transform.localRotation = Quaternion.Euler(transform.localRotation.y, 0, 0);
                gameObject.transform.DOLocalMoveX(transform.localPosition.x - 1, 1, false);
            }
            if (transform.localPosition.x - (-12) <= 1 && transform.localPosition.x - (-12) >= 0) { moveGoal = false; }

            if (moveGoal == false)
            {
                gameObject.transform.localRotation = Quaternion.Euler(transform.localRotation.y, 180, 0);
                gameObject.transform.DOLocalMoveX(transform.localPosition.x + 1, 1, false);
            }
            if (transform.localPosition.x - (12) >= -1 && (transform.localPosition.x - (12) <= 0)) { moveGoal = true; }
            Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, 1f, playerLayer);
            //Debug.Log(enemy.Length);
            foreach (Collider2D item in player)
            {
                EnemyAttack();
                item.GetComponent<ChangeAnimation>().Lamcham(0.02f);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")){
                Debug.Log("Vacham");
            }
        }
    }
}
