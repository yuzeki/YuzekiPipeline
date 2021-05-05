using System.IO;
using UnityEditor;
using UnityEngine;

public class LutCopyTool
{   
    static readonly string SAVE_PATH = Application.dataPath + "/lut_temp.png";
    
    [MenuItem("Test/Save lut")]
    public static void SaveCopyTex()
    {
        if(LutCopy.s_CopyTex == null)
        {
            Debug.LogError($"s_CopyTex == null");
            return;
        }
        var oldRT = RenderTexture.active;
        RenderTexture.active = LutCopy.s_CopyTex;
        LutCopy.s_CopyTex2D.ReadPixels(new Rect(0, 0, LutCopy.s_CopyTex2D.width, LutCopy.s_CopyTex2D.height), 0, 0);
        LutCopy.s_CopyTex2D.Apply();
        RenderTexture.active = oldRT;
        byte[] bytes = LutCopy.s_CopyTex2D.EncodeToPNG();
        File.WriteAllBytes(SAVE_PATH, bytes);
        AssetDatabase.Refresh();
        Debug.Log($"save lut texture to path:{SAVE_PATH}");
    }

    [MenuItem("Test/Copy lut")]
    public static void TakeAnotherCopy()
    {
        LutCopy.s_AllowCopy = false;
    }
}
