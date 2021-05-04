#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
#endif
using System;

namespace UnityEngine.Rendering.Universal
{
    [Serializable]
    public class PostProcessData : ScriptableObject
    {
        private const string PackagePath = "Assets/com.unity.render-pipelines.universal/";
#if UNITY_EDITOR
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812")]
        internal class CreatePostProcessDataAsset : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                var instance = CreateInstance<PostProcessData>();
                AssetDatabase.CreateAsset(instance, pathName);
                ResourceReloader.ReloadAllNullIn(instance, UniversalRenderPipelineAsset.packagePath);
                Selection.activeObject = instance;
            }
        }

        [MenuItem("Assets/Create/Rendering/Universal Render Pipeline/Post-process Data", priority = CoreUtils.assetCreateMenuPriority3)]
        static void CreatePostProcessData()
        {
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, CreateInstance<CreatePostProcessDataAsset>(), "CustomPostProcessData.asset", null, null);
        }
#endif

        [Serializable, ReloadGroup]
        public sealed class ShaderResources
        {
            [Reload(PackagePath + "Shaders/PostProcessing/StopNaN.shader")]
            public Shader stopNanPS;

            [Reload(PackagePath + "Shaders/PostProcessing/SubpixelMorphologicalAntialiasing.shader")]
            public Shader subpixelMorphologicalAntialiasingPS;

            [Reload(PackagePath + "Shaders/PostProcessing/GaussianDepthOfField.shader")]
            public Shader gaussianDepthOfFieldPS;

            [Reload(PackagePath + "Shaders/PostProcessing/BokehDepthOfField.shader")]
            public Shader bokehDepthOfFieldPS;

            [Reload(PackagePath + "Shaders/PostProcessing/CameraMotionBlur.shader")]
            public Shader cameraMotionBlurPS;

            [Reload(PackagePath + "Shaders/PostProcessing/PaniniProjection.shader")]
            public Shader paniniProjectionPS;

            [Reload(PackagePath + "Shaders/PostProcessing/LutBuilderLdr.shader")]
            public Shader lutBuilderLdrPS;

            [Reload(PackagePath + "Shaders/PostProcessing/LutBuilderHdr.shader")]
            public Shader lutBuilderHdrPS;

            [Reload(PackagePath + "Shaders/PostProcessing/Bloom.shader")]
            public Shader bloomPS;

            [Reload(PackagePath + "Shaders/PostProcessing/UberPost.shader")]
            public Shader uberPostPS;

            [Reload(PackagePath + "Shaders/PostProcessing/FinalPost.shader")]
            public Shader finalPostPassPS;
        }

        [Serializable, ReloadGroup]
        public sealed class TextureResources
        {
            // Pre-baked noise
            [Reload(PackagePath + "Textures/BlueNoise16/L/LDR_LLL1_{0}.png", 0, 32)]
            public Texture2D[] blueNoise16LTex;

            // Post-processing
            [Reload(new[]
            {
                PackagePath + "Textures/FilmGrain/Thin01.png",
                PackagePath + "Textures/FilmGrain/Thin02.png",
                PackagePath + "Textures/FilmGrain/Medium01.png",
                PackagePath + "Textures/FilmGrain/Medium02.png",
                PackagePath + "Textures/FilmGrain/Medium03.png",
                PackagePath + "Textures/FilmGrain/Medium04.png",
                PackagePath + "Textures/FilmGrain/Medium05.png",
                PackagePath + "Textures/FilmGrain/Medium06.png",
                PackagePath + "Textures/FilmGrain/Large01.png",
                PackagePath + "Textures/FilmGrain/Large02.png"
            })]
            public Texture2D[] filmGrainTex;

            [Reload(PackagePath + "Textures/SMAA/AreaTex.tga")]
            public Texture2D smaaAreaTex;

            [Reload(PackagePath + "Textures/SMAA/SearchTex.tga")]
            public Texture2D smaaSearchTex;
        }

        public ShaderResources shaders;
        public TextureResources textures;
    }
}
