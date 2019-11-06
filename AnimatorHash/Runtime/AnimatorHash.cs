using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

    public static void Play(this Animator animator, AnimatorHash stateNameHash)
    {
        animator.Play(stateNameHash.hash);
    }
    public static void Play(this Animator animator, AnimatorHash stateNameHash, int layer)
    {
        animator.Play(stateNameHash.hash, layer);
    }
    /// <summary>
    /// Plays a state.
    /// </summary>
    /// <param name="stateNameHash">The state hash name. If stateNameHash is 0, it changes the current state time.</param>
    /// <param name="layer">The layer index. If layer is -1, it plays the first state with the given state name or hash.</param>
    /// <param name="normalizedTime">The time offset between zero and one.</param>
    public static void Play(this Animator animator, AnimatorHash stateNameHash, int layer = -1, float normalizedTime = float.NegativeInfinity)
    {
        animator.Play(stateNameHash.hash, layer, normalizedTime);
    }

    /// <summary>
    /// Plays a state.
    /// </summary>
    /// <param name="stateNameHash">The state hash name. If stateNameHash is 0, it changes the current state time.</param>
    /// <param name="layer">The layer index. If layer is -1, it plays the first state with the given state name or hash.</param>
    /// <param name="fixedTime">The time offset (in seconds).</param>
    public static void PlayInFixedTime(this Animator animator, AnimatorHash stateNameHash, int layer, float fixedTime)
    {
        animator.PlayInFixedTime(stateNameHash.hash, layer, fixedTime);
    }
    public static void PlayInFixedTime(this Animator animator, AnimatorHash stateNameHash)
    {
        animator.PlayInFixedTime(stateNameHash.hash);
    }
    public static void PlayInFixedTime(this Animator animator, AnimatorHash stateNameHash, int layer)
    {
        animator.PlayInFixedTime(stateNameHash.hash, layer);
    }

    //
    // Сводка:
    //     Plays a state.
    //
    // Параметры:
    //   stateName:
    //     
    //
    //   stateNameHash:
    //     The state hash name. If stateNameHash is 0, it changes the current state time.
    //
    //   layer:
    //     The layer index. If layer is -1, it plays the first state with the given state
    //     name or hash.
    //
    //   normalizedTime:
    //     The time offset between zero and one.


    /// <summary>
    /// Sets the value of the given float parameter.
    /// </summary>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    public static void SetFloat(this Animator animator, AnimatorHash id, float value)
    {
        animator.SetFloat(id.hash, value);
    }
    /// <summary>
    /// Send float values to the Animator to affect transitions.
    /// </summary>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    /// <param name="dampTime">The damper total time.</param>
    /// <param name="deltaTime">The delta time to give to the damper.</param>
    public static void SetFloat(this Animator animator, AnimatorHash id, float value, float dampTime, float deltaTime)
    {
        animator.SetFloat(id.hash, value, dampTime, deltaTime);
    }
    /// <summary>
    /// Sets the value of the given integer parameter.
    /// </summary>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    public static void SetInteger(this Animator animator, AnimatorHash id, int value)
    {
        animator.SetInteger(id.hash, value);
    }
    /// <summary>
    /// Sets the value of the given boolean parameter.
    /// </summary>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    public static void SetBool(this Animator animator, AnimatorHash id, bool value)
    {
        animator.SetBool(id.hash, value);
    }
    /// <summary>
    /// Sets the value of the given quaternion parameter.
    /// </summary>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    [System.Obsolete]
    public static void SetQuaternion(this Animator animator, AnimatorHash id, Quaternion value)
    {
        animator.SetQuaternion(id.hash, value);
    }
    /// <summary>
    /// Sets the value of the given vector parameter.
    /// </summary>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    [System.Obsolete]
    public static void SetVector(this Animator animator, AnimatorHash id, Vector3 value)
    {
        animator.SetVector(id.hash, value);
    }
    /// <summary>
    /// Sets the value of the given trigger parameter.
    /// </summary>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    public static void SetTrigger(this Animator animator, AnimatorHash id)
    {
        animator.SetTrigger(id.hash);
    }
    /// <summary>
    /// Resets the value of the given trigger parameter.
    /// </summary>
    /// <param name="id">The parameter ID.</param>
    /// <param name="value">The new parameter value.</param>
    public static void ResetTrigger(this Animator animator, AnimatorHash id)
    {
        animator.ResetTrigger(id.hash);
    }
}
#if UNITY_EDITOR
namespace Neonagee.Editor.PropertyDrawers 
{
    [CustomPropertyDrawer(typeof(AnimatorHash))]
    public class AnimatorHashDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var propertyName = property.FindPropertyRelative("property");
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();
            propertyName.stringValue = EditorGUI.TextField(position, label, propertyName.stringValue);
            if (EditorGUI.EndChangeCheck())
            {
                property.FindPropertyRelative("hash").intValue = Animator.StringToHash(propertyName.stringValue);
            }
            EditorGUI.EndProperty();
        }
    }
}
#endif
