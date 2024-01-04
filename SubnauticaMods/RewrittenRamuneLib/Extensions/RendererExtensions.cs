

namespace RamuneLib.Extensions
{
    public static class RendererExtensions
    {
        public enum TextureType
        {
            Main,
            Specular,
            Illum,
        }


        public static Renderer SetTexture(this Renderer renderer, TextureType type, Texture2D texture, int materialIndex = 0)
        {
            if(renderer == null)
                throw new NullReferenceException("RendererExtensions.SetTexture: renderer is null");

            switch (type)
            {
                case TextureType.Main:
                    renderer.materials[materialIndex].SetTexture(ShaderPropertyID._MainTex, texture);
                    break;

                case TextureType.Specular:
                    renderer.materials[materialIndex].SetTexture(ShaderPropertyID._SpecTex, texture);
                    break;

                case TextureType.Illum:
                    renderer.materials[materialIndex].SetTexture(ShaderPropertyID._Illum, texture);
                    break;
            }
            return renderer;
        }


        public static Renderer MultiSetTexture(this Renderer renderer, TextureType type, Texture2D texture, params int[] materialIndexes)
        {
            if(renderer == null)
                throw new NullReferenceException("RendererExtensions.SetTexture: renderer is null");

            materialIndexes.ForEach(i =>
            {
                switch (type)
                {
                    case TextureType.Main:
                        renderer.materials[i].SetTexture(ShaderPropertyID._MainTex, texture);
                        break;

                    case TextureType.Specular:
                        renderer.materials[i].SetTexture(ShaderPropertyID._SpecTex, texture);
                        break;

                    case TextureType.Illum:
                        renderer.materials[i].SetTexture(ShaderPropertyID._Illum, texture);
                        break;
                }
            });
            return renderer;
        }


        public static Renderer MultiSetTexture(this Renderer renderer, TextureType[] types, Texture2D texture, params int[] materialIndexes)
        {
            if(renderer == null)
                throw new NullReferenceException("RendererExtensions.SetTexture: renderer is null");

            materialIndexes.ForEach(i =>
            {
                foreach(var type in types)
                {
                    switch(type)
                    {
                        case TextureType.Main:
                            renderer.materials[i].SetTexture(ShaderPropertyID._MainTex, texture);
                            break;

                        case TextureType.Specular:
                            renderer.materials[i].SetTexture(ShaderPropertyID._SpecTex, texture);
                            break;

                        case TextureType.Illum:
                            renderer.materials[i].SetTexture(ShaderPropertyID._Illum, texture);
                            break;
                    }
                }
            });
            return renderer;
        }


        public static Renderer SetGlowStrength(this Renderer renderer, float strength, int materialIndex = 0)
        {
            if(renderer == null)
                throw new NullReferenceException("RendererExtensions.SetGlowStrength: renderer is null");

                
            renderer.materials[materialIndex].SetFloat(ShaderPropertyID._GlowStrength, strength);
            renderer.materials[materialIndex].SetFloat(ShaderPropertyID._GlowStrengthNight, strength);
            return renderer;
        }


        public static Renderer MultiSetGlowStrength(this Renderer renderer, float strength, params int[] materialIndexes)
        {
            if(renderer == null)
                throw new NullReferenceException("RendererExtensions.SetGlowStrength: renderer is null");

            materialIndexes.ForEach(i =>
            {
                renderer.materials[i].SetFloat(ShaderPropertyID._GlowStrength, strength);
                renderer.materials[i].SetFloat(ShaderPropertyID._GlowStrengthNight, strength);
            });
            return renderer;
        }


        public static Renderer ToggleEmission(this Renderer renderer, bool toggleState)
        {
            if(toggleState) renderer.materials.ForEach(m => m.EnableKeyword("MARMO_EMISSION"));
            else renderer.materials.ForEach(m => m.DisableKeyword("MARMO_EMISSION"));
            return renderer;
        }


        public static Renderer ToggleEmission(this Renderer renderer, bool toggleState, int materialIndex)
        {
            if(toggleState) renderer.materials[materialIndex].EnableKeyword("MARMO_EMISSION");
            else renderer.materials[materialIndex].DisableKeyword("MARMO_EMISSION");
            return renderer;
        }


        public static Renderer MultiToggleEmission(this Renderer renderer, bool toggleState, params int[] materialIndexes)
        {
            materialIndexes.ForEach(i =>
            {
                if(toggleState) renderer.materials[i].EnableKeyword("MARMO_EMISSION");
                else renderer.materials[i].DisableKeyword("MARMO_EMISSION");
            });
            return renderer;
        }
    }
}