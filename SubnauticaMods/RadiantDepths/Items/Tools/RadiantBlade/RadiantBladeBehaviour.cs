﻿

namespace Ramune.RadiantDepths.Items.Tools.RadiantBlade
{
    public class RadiantBladeBehaviour : HeatBlade
    {
        public static FMODAsset SeismicAsset = Utility.AudioUtils.GetFmodAsset("event:/creature/crash/die");
        public static FMODAsset ExplosiveAsset = Utility.AudioUtils.GetFmodAsset("");
        public static FMODAsset NanoswarmAsset = Utility.AudioUtils.GetFmodAsset("event:/tools/stasis_gun/sphere_enter");
        public static FMODAsset NextAsset = Utility.AudioUtils.GetFmodAsset("event:/env/input_number");
        public Renderer renderer;

        public bool shouldDisplay = false;
        public bool isPowered = false;
        public string handText = "";
        public int attackIndex = 0;


        public List<RadiantBladeAttack> Attacks = new()
        {
            {new("None", "<color=#ffffff>None</color>", new(0.67f, 0.1f, 0.85f), null)},


            {new("Seismic", "<color=#ffffff>Seismic</color> (1/3)", new(0f, 1f, 0f), (go, renderer) =>
            {
                FMODUWE.PlayOneShot(SeismicAsset, go.transform.position, 5f);

                WorldForces.AddCurrent(go.transform.position, DayNightCycle.main.timePassed, 10f, -Vector3.Cross(go.transform.forward, new Vector3(0, 1, 0)), go.GetComponent<Rigidbody>().mass * 1.5f, 4f);
                MainCameraControl.main.ShakeCamera(1f, 1.5f, MainCameraControl.ShakeMode.Linear, 1.4f);
            })},


            {new("Explosive", "<color=#ffffff>Explosive</color> (2/3)", new(1f, 0f, 0f), (go, renderer) =>
            {
                FMODUWE.PlayOneShot(ExplosiveAsset, go.transform.position, 5f);
            })},


            {new("Nanoswarm", "<color=#ffffff>Nanoswarm</color> (3/3)", new(0f, 0f, 1f), (go, renderer) =>
            {
                FMODUWE.PlayOneShot(NanoswarmAsset, go.transform.position, 5f);

                if(go.TryGetComponent<FreezeBitch>(out var freeze)) freeze.duration = 1.3f;
                else go.AddComponent<FreezeBitch>();
            })},
        };


        public void Start()
        {
            damage = 50f * RadiantDepths.config.RadiantBladeDamage;
            attackDist = 3.5f * RadiantDepths.config.RadiantBladeRange;
            handText = Attacks[attackIndex].HandText;
            renderer = GetComponentInChildren<Renderer>(true);
        }


        public bool IsPowered()
        {
            if(energyMixin.HasItem())
            {
                isPowered = true;
                return true;
            }

            isPowered = false;
            return false;
        }


        public void Update()
        {
            if(!IsPowered())
            {
                shouldDisplay = false;
                HandReticle.main.SetText(HandReticle.TextType.Use, "Missing vital power source", false);
                return;
            }
            
            if(!shouldDisplay) 
                return;


            if(Input.anyKeyDown && !Cursor.visible)
            {
                if(Input.GetKeyDown(KeyCode.Q))
                    CycleNextMode();
            }

            HandReticle.main.SetText(HandReticle.TextType.Use, "Switch mode", false, GameInput.Button.Deconstruct);
            HandReticle.main.SetText(HandReticle.TextType.UseSubscript, $"{handText}", false);
        }


        public override void OnToolUseAnim(GUIHand hand)
        {
            base.OnToolUseAnim(hand);

            if(attackIndex == 0)
                return;

            Vector3 vector = default;
            GameObject gameObject = null;
            UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, attackDist, ref gameObject, ref vector, true);

            if(gameObject == null) 
                return;

            if(!gameObject.TryGetComponentInChildren<LiveMixin>(out var liveMixin))
                return;

            if(!IsValidTarget(liveMixin)) 
                return;

            if(!liveMixin.IsAlive())
                return;

            Attacks[attackIndex].Attack.Invoke(gameObject, renderer);
        }


        public override void OnDraw(Player p)
        {
            damage = 50f * RadiantDepths.config.RadiantBladeDamage;
            attackDist = 3.5f * RadiantDepths.config.RadiantBladeRange;
            shouldDisplay = true;
            base.OnDraw(p);
        }


        public override void OnHolster()
        {
            shouldDisplay = false;
            base.OnHolster();
        }


        public void CycleNextMode()
        {
            IngameMenu.main.PlaySound(NextAsset);

            _ = attackIndex == Attacks.Count - 1
                ? attackIndex = 0
                : attackIndex++;

            handText = Attacks[attackIndex].HandText;
            renderer.SetColor(ShaderPropertyID._GlowColor, Attacks[attackIndex].Color);
        }


        public override string animToolName => "knife";
    }
}