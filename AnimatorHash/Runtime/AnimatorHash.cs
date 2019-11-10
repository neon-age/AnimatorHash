using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AnimatorHash
{
    public string property;
    public int hash;
    public AnimatorHash(string propertyName)
    {
        property = propertyName;
        hash = Animator.StringToHash(property);
    }
    public static implicit operator int (AnimatorHash animatorHash)
    {
        return animatorHash.hash;
    }
    public static implicit operator AnimatorHash(string propertyName)
    {
        return new AnimatorHash(propertyName);
    }
}
static class AnimatorHashExtension
{
    public static bool IsCurrentState(this Animator animator, AnimatorHash stateNameHash, int layerIndex = 0)
    {
        return animator.GetCurrentAnimatorStateInfo(layerIndex).shortNameHash == stateNameHash.hash;
    }
    public static bool IsCurrentState(this Animator animator, AnimatorHash stateNameHash, out AnimatorStateInfo stateInfo, int layer = 0)
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(layer);
        return stateInfo.shortNameHash == stateNameHash.hash;
    }
}