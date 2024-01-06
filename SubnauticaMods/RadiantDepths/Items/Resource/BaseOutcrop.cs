

namespace Ramune.RadiantDepths.Items.Resource
{
    public class BaseOutcrop
    {
        public virtual TechType OutcropToClone => TechType.LimestoneChunk;
        public virtual string ID => "";
        public virtual string Name => "";
        public virtual string Description => "";

        public static CustomPrefab Prefab { get; set; }
        
        public BaseOutcrop()
        {
            Prefab = PrefabUtils.CreatePrefab(ID, Name, Description, ImageUtils.GetSprite(ID + "Sprite"))
                .WithPDACategory(TechGroup.Resources, TechCategory.BasicMaterials)
                .WithAutoUnlock();

            var clone = new CloneTemplate(Prefab.Info, OutcropToClone)
            {
                ModifyPrefab = go =>
                {
                    if(!go.TryGetComponentInChildren<Renderer>(out var renderer))
                        return;

                    renderer
                        .SetTexture(new[] { TextureType.Main, TextureType.Specular }, ImageUtils.GetTexture(ID + "Texture"));
                }
            };

            Prefab.SetGameObject(clone);
        }
    }

    public class RamuneOutcrop : BaseOutcrop
    {
        public override TechType OutcropToClone => TechType.SandstoneChunk;
        public override string ID => "RamuneOutcrop";
        public override string Name => "Ramune outcrop";
        public override string Description => "An outcrop comprised of pure Ramune";

        public RamuneOutcrop() : base()
        {
            Prefab
                .WithSize(2, 2)
                .WithAutoUnlock()
                .WithEquipment(EquipmentType.Hand);
        }
    }
}