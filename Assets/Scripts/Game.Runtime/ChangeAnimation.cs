using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game.Runtime
{
    public class ChangeAnimation : MonoBehaviour
    {
        [SerializeField]float valuespeed;
        float tdgy;
        [SerializeField]
        Rigidbody2D _rdbd2;
        [SerializeField]
        Animator _animator;
        public bool isJump = false;
        [SerializeField]
        Slider slider;
        [SerializeField]
         LayerMask enemyLayer;
        public LayerMask enemyBoss1Layer;
        public LayerMask enemyBBLayer;
        float attackdame=1f;
        float jumpdame=1f;
        public Toggle AttackCheck;
        public Toggle JumpCheck;




        // Start is called before the first frame update
        void Start()
        {
            tdgy = transform.localPosition.y;
        }

        // Update is called once per frame
        void Update()
        {
            MoveCharacter();
            JumpCharacter();
            AttackCharacter();
            
        }
        void MoveCharacter()
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (gameObject.transform.localRotation.y == 0) { transform.localRotation = Quaternion.Euler(transform.localRotation.x, 180, 0); }
                _animator.SetTrigger("Walk");
                gameObject.transform.DOLocalMoveX(transform.localPosition.x - valuespeed, 1, false); ;
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (gameObject.transform.localRotation.y != 0) { transform.localRotation = Quaternion.Euler(transform.localRotation.x, 0, 0); }
                _animator.SetTrigger("Walk");
                gameObject.transform.DOLocalMoveX(transform.localPosition.x + valuespeed, 1, false);
            }

        }
        void JumpCharacter()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger("Jump_1");
                isJump = true;
            }
            if (isJump == true)
            {
                gameObject.transform.DOLocalJump(new Vector2(transform.localPosition.x, tdgy), jumpdame, 1, 1, false);
            }
            if (gameObject.transform.localPosition.y > 1f)
            {
                isJump = false;
            }
        }
        void AttackCharacter()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger("Attack_1");
                Collider2D[] enemybb = Physics2D.OverlapCircleAll(transform.position, 1f, enemyBBLayer);
               
                foreach (Collider2D item in enemybb)
                {
                    Debug.Log("Vo");
                    item.GetComponent<TriggedBigBoss>().Hit(attackdame);
                }
                Collider2D[] enemy = Physics2D.OverlapCircleAll(transform.position, 1f, enemyLayer);
               
                foreach (Collider2D item in enemy)
                {
                    item.GetComponent<Trigged>().Hit(attackdame);
                }

                Collider2D[] enemyboss1 = Physics2D.OverlapCircleAll(transform.position, 1f, enemyBoss1Layer);
                
                foreach (Collider2D item in enemyboss1)
                {
                    item.GetComponent<TriggedBoss>().Hit(attackdame);
                }

                
            }

        }
        public void Lamcham(float value)
        {
            StartCoroutine(Slow(value));
            Debug.Log("Lamcham");
        }
        public IEnumerator Slow(float valuest)
        {
            WasHit(valuest);
            yield return new WaitForSeconds(0.1f);
        }
        public void WasHit(float values)
        {
            slider.value -= values;
            if (slider.value <= 0)
            {
                _animator.SetTrigger("Death");
                
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("HPBonus"))
            {
                Debug.Log("An HP");
                slider.value = slider.maxValue;
                Destroy(Trigged.a);
                Destroy(TriggedBoss.a);
                //Trigged.a = new GameObject();
            }
          
            if (collision.gameObject.CompareTag("AttackBonus"))
            {
                AttackCheck.isOn=true;
                Debug.Log("An Attack");
                attackdame = 2;
                Destroy(Trigged.a);        
                //Trigged.a = new GameObject();
            }
            if (collision.gameObject.CompareTag("JumpBonus"))
            {
                JumpCheck.isOn = true;
                Debug.Log("An Attack");
                jumpdame = 2;
                Destroy(TriggedBoss.b);
            }
            if (collision.gameObject.CompareTag("Water"))
            {
                Debug.Log("Nuoc");
                slider.value = 0;
            }
        }
    }
}
