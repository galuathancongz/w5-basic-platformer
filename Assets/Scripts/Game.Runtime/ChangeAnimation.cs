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
                gameObject.transform.DOLocalJump(new Vector2(transform.localPosition.x, tdgy), 2, 1, 1, false);
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
                Collider2D[] enemy = Physics2D.OverlapCircleAll(transform.position, 1f, enemyLayer);
                Debug.Log(enemy.Length);
                foreach (Collider2D item in enemy)
                {
                    item.GetComponent<Trigged>().Hit(1);
                }
            }

        }
        public void WasHit(float values)
        {
            slider.value -= values;
            if (slider.value <= 0)
            {
                _animator.SetTrigger("dead");
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("HPBonus"))
            {
                Debug.Log("An HP");
                slider.value = slider.maxValue;
                Destroy(Trigged.a);        
                //Trigged.a = new GameObject();
            }
        }
    }
}
