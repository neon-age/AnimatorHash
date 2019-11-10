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
        public AnimatorHash fireAnim = "Fire";
        public AnimatorHash moveAnim = "Move";
        public AnimatorHash jumpAnim = "Jump";
        public AnimatorHash horizontalParam = "Horizontal";
        public AnimatorHash verticalParam = "Vertical";

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
