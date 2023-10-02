

namespace Ramune.RamunesTextureUpscales
{
    public static class Utils
    {
        public static string AssetPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");


        public static bool HasMainTex(string name)
        {
            if(File.Exists(Path.Combine(AssetPath, name + "_Main.png"))) return true;
            return false;
        }


        public static bool HasSpecTex(string name)
        {
            if(File.Exists(Path.Combine(AssetPath, name + "_Spec.png"))) return true;
            return false;
        }


        public static bool HasIllumTex(string name)
        {
            if(File.Exists(Path.Combine(AssetPath, name + "_Illum.png"))) return true;
            return false;
        }


        public static void ApplyUpscaling(Renderer renderer, string name)
        {
            if(HasMainTex(name)) renderer.material.SetTexture(ShaderPropertyID._MainTex, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Main.png")));
            if(HasSpecTex(name)) renderer.material.SetTexture(ShaderPropertyID._SpecTex, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Spec.png")));
            if(HasIllumTex(name)) renderer.material.SetTexture(ShaderPropertyID._Illum, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Illum.png")));
        }


        public static void ApplyUpscaling(MeshRenderer renderer, string name)
        {
            if(HasMainTex(name)) renderer.material.SetTexture(ShaderPropertyID._MainTex, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Main.png")));
            if(HasSpecTex(name)) renderer.material.SetTexture(ShaderPropertyID._SpecTex, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Spec.png")));
            if(HasIllumTex(name)) renderer.material.SetTexture(ShaderPropertyID._Illum, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Illum.png")));
        }


        public static void ApplyUpscaling(SkinnedMeshRenderer renderer, string name)
        {
            if(HasMainTex(name)) renderer.material.SetTexture(ShaderPropertyID._MainTex, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Main.png")));
            if(HasSpecTex(name)) renderer.material.SetTexture(ShaderPropertyID._SpecTex, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Spec.png")));
            if(HasIllumTex(name)) renderer.material.SetTexture(ShaderPropertyID._Illum, ImageUtils.LoadTextureFromFile(Path.Combine(AssetPath, name + "_Illum.png")));
        }
    }
}