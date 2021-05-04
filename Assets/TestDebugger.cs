using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TestDebugger : MonoBehaviour
{
    public PostProcessData postProcessData;

    public Material material;

    [ContextMenu("GenerateMat")]
    void GenerateMat()
    {
        material = new Material(postProcessData.shaders.uberPostPS);
    }
}
