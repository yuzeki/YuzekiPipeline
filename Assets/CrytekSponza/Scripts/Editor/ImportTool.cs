using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ImportTool
{
    static Dictionary<string, Texture> textureCache = new Dictionary<string, Texture>();

    [MenuItem("Tools/Cache mats mainTex")]
    static void CacheTextures()
    {
        foreach(var select in Selection.objects)
        {
            var material = select as Material;
            if(material == null) continue;
            var sourceBaseTex = material.GetTexture("_MainTex");
            if(sourceBaseTex != null)
            {
                textureCache.Add(material.name, sourceBaseTex);
            } 
        }
    }

    [MenuItem("Tools/Release mats baseMap")]
    static void BatchConvertMats()
    {
        foreach(var select in Selection.objects)
        {
            var material = select as Material;
            if(material == null) continue;
            if(textureCache.ContainsKey(material.name))
            {
                material.SetTexture("_BaseMap", textureCache[material.name]);
            } 
        }
    }
}
