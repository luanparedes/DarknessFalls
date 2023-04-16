using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [MenuItem("Tools/Set Color Space to Linear")]
    public static void SetLinearColorSpace()
    {
        PlayerSettings.colorSpace = ColorSpace.Linear;
    }

    [MenuItem("Tools/Set Color Space to Gamma")]
    public static void SetGammaColorSpace()
    {
        PlayerSettings.colorSpace = ColorSpace.Gamma;
    }
}
