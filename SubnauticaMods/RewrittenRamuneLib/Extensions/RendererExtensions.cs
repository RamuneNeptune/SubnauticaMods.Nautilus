

namespace RamuneLib.Extensions
{
    public static class RendererExtensions
    {
        /// <summary>
        /// Types of textures that can be set on a Renderer.
        /// </summary>
        public enum TextureType
        {
            Main,
            Specular,
            Illum,
        }


        /// <summary>
        /// Sets a texture on the specified material index of the Renderer.
        /// </summary>
        /// <param name="type">The type of texture to set (Main, Specular, Illum)</param>
        /// <param name="texture">The texture to apply</param>
        /// <param name="materialIndex">The index of the material to set the texture on (default is 0.</param>
        /// <returns>The modified Renderer.</returns>
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


        /// <summary>
        /// Sets a texture for multiple materials
        /// </summary>
        /// <param name="type">The type of texture to set (Main, Specular, Illum)</param>
        /// <param name="texture">The texture to apply</param>
        /// <param name="materialIndexes">An array of material indexes to apply the textures to</param>
        /// <returns>The modified Renderer.</returns>
        public static Renderer SetTextures(this Renderer renderer, TextureType type, Texture2D texture, params int[] materialIndexes)
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
        

        /// <summary>
        /// Sets textures for multiple materials
        /// </summary>
        /// <param name="types">Array of texture types to set (Main, Specular, Illum)</param>
        /// <param name="texture">The texture to apply</param>
        /// <param name="materialIndexes">An array of material indexes to apply the textures to</param>
        public static Renderer SetTextures(this Renderer renderer, TextureType[] types, Texture2D texture, params int[] materialIndexes)
        {
            if(renderer == null)
                throw new NullReferenceException("RendererExtensions.SetTextures: renderer is null");

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


        /// <summary>
        /// Sets the glow strength of the specified material
        /// </summary>
        /// <param name="strength">The glow strength value</param>
        /// <param name="materialIndex">The index of the material to set the glow strength on (default is 0)</param>
        public static Renderer SetGlowStrength(this Renderer renderer, float strength, int materialIndex = 0)
        {
            if(renderer == null)
                throw new NullReferenceException("RendererExtensions.SetGlowStrength: renderer is null");

            renderer.materials[materialIndex].SetFloat(ShaderPropertyID._GlowStrength, strength);
            renderer.materials[materialIndex].SetFloat(ShaderPropertyID._GlowStrengthNight, strength);
            return renderer;
        }


        /// <summary>
        /// Sets the glow strength on multiple materials
        /// </summary>
        /// <param name="strength">The glow strength value</param>
        /// <param name="materialIndexes">An array of material indexes to apply the glow strength to</param>
        public static Renderer SetGlowStrengths(this Renderer renderer, float strength, params int[] materialIndexes)
        {
            if(renderer == null)
                throw new NullReferenceException("RendererExtensions.SetGlowStrengths: renderer is null");

            materialIndexes.ForEach(i =>
            {
                renderer.materials[i].SetFloat(ShaderPropertyID._GlowStrength, strength);
                renderer.materials[i].SetFloat(ShaderPropertyID._GlowStrengthNight, strength);
            });
            return renderer;
        }


        /// <summary>
        /// Toggles 'MARMO_EMISSION' keyword on all materials
        /// </summary>
        /// <param name="toggleState">True to enable emission, false to disable</param>
        public static Renderer ToggleEmission(this Renderer renderer, bool toggleState)
        {
            if(toggleState) renderer.materials.ForEach(m => m.EnableKeyword("MARMO_EMISSION"));
            else renderer.materials.ForEach(m => m.DisableKeyword("MARMO_EMISSION"));
            return renderer;
        }


        /// <summary>
        /// Toggles 'MARMO_EMISSION' keyword for the specified material
        /// </summary>
        /// <param name="toggleState">True to enable emission, false to disable</param>
        /// <param name="materialIndex">The index of the material to toggle emission on</param>
        public static Renderer ToggleEmission(this Renderer renderer, bool toggleState, int materialIndex)
        {
            if(toggleState) renderer.materials[materialIndex].EnableKeyword("MARMO_EMISSION");
            else renderer.materials[materialIndex].DisableKeyword("MARMO_EMISSION");
            return renderer;
        }


        /// <summary>
        /// Toggles 'MARMO_EMISSION' keyword for multiple materials
        /// </summary>
        /// <param name="toggleState">True to enable emission, false to disable</param>
        /// <param name="materialIndexes">An array of material indexes to toggle emission on to</param>
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