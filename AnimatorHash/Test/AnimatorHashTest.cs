using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Neonagee.Tests
{
    public class AnimatorHashTest : MonoBehaviour
    {
        public Animator animator;
        public ParticleSystem shotParticle;
        [Space]
        public float fireTime = 0.3f;
        float m_fireTime;
        [Space]
        public AnimatorHash fireAnim = new AnimatorHash("Fire");
        public AnimatorHash moveAnim = new AnimatorHash("Move");
        public AnimatorHash jumpAnim = new AnimatorHash("Jump");
        public AnimatorHash horizontalParam = new AnimatorHash("Horizontal");
        public AnimatorHash verticalParam = new AnimatorHash("Vertical");

        private void Update()
        {
            var HAxis = Input.GetAxis("Horizontal");
            var VAxis = Input.GetAxis("Vertical");

            if (Input.GetMouseButton(0) && Time.time >= m_fireTime)
            {
                animator.Play(fireAnim, 1, 0);
                shotParticle.Play();
                m_fireTime = Time.time + fireTime;
            }
            if (Input.GetKeyDown(KeyCode.Space))
                animator.Play(jumpAnim);

            if (HAxis != 0 || VAxis != 0)
            {
                animator.Play(moveAnim);
                animator.SetFloat(horizontalParam, HAxis);
                animator.SetFloat(verticalParam, VAxis);
            }
        }
    }
}
