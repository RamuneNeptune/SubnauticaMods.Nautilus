

namespace RadiantBlade.Monos
{
    public class RadiantBlade : HeatBlade
    {
        public int currentIndex;
        public bool shouldDisplay, tooltipIsSet;
        public MeshRenderer? renderer;
        public List<BladeMode> bladeModes = Enum.GetValues(typeof(BladeMode)).Cast<BladeMode>().ToList();
        public BladeMode currentMode = BladeMode.None;
        public enum BladeMode
        {
            None,
            Seismic,
            Explosive,
            Nanoswarm,
            Vitality,
            Anomaly,
        };


        public void Start()
        {
            attackDist = 5f;
            damage = 10f;
            renderer = GetComponentInChildren<MeshRenderer>();
        }


        public bool IsPowered()
        {
            if (GetComponent<EnergyMixin>().HasItem()) return true;
            return false;
        }


        public override void OnDraw(Player p)
        {
            shouldDisplay = true;
            base.OnDraw(p);
        }


        public override void OnHolster()
        {
            shouldDisplay = false;
            base.OnHolster();
        }


        public override void OnToolUseAnim(GUIHand hand)
        {
            base.OnToolUseAnim(hand);

            Vector3 vector = default;
            GameObject? gameObject = null;
            UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, attackDist, ref gameObject, ref vector, true);

            if(gameObject == null) return;
            var livemixin = gameObject.FindAncestor<LiveMixin>();

            if(!IsValidTarget(livemixin)) return;

            switch(currentMode)
            {
                case BladeMode.None:
                    break;
                case BladeMode.Seismic:
                    SpecialAttacks.Seismic(gameObject, livemixin);
                    break;
                case BladeMode.Explosive:
                    SpecialAttacks.Explosive(gameObject, livemixin);
                    break;
                case BladeMode.Nanoswarm:
                    SpecialAttacks.Nanoswarm(gameObject, livemixin);
                    break;
                case BladeMode.Vitality:
                    SpecialAttacks.Nanoswarm(gameObject, livemixin);
                    break;
                case BladeMode.Anomaly:
                    SpecialAttacks.Anomaly(gameObject, livemixin);
                    break;
            }
        }


        public void Update()
        {
            if(!shouldDisplay) return;

            if(!IsPowered())
            {
                HandReticle.main.SetText(HandReticle.TextType.Use, "Missing power source", false);
                HandReticle.main.SetIcon(HandReticle.IconType.None, 1f);
                return;
            }

            if(Input.GetKeyDown(KeyCode.Q) & !Cursor.visible)
            {
                IngameMenu.main.PlaySound(SpecialAttacks.NextAsset);
                currentIndex = (currentIndex > bladeModes.Count) ? 0 : (currentIndex + 1);
            }

            HandReticle.main.SetText(HandReticle.TextType.Use, "Switch mode", false, GameInput.Button.Deconstruct);
            HandReticle.main.SetIcon(HandReticle.IconType.None, 1f);

            if(currentIndex == 0) HandReticle.main.SetText(HandReticle.TextType.UseSubscript, $"None", false);
            else HandReticle.main.SetText(HandReticle.TextType.UseSubscript, $"{bladeModes[currentIndex]} ({currentIndex}/{bladeModes.Count - 1})", false);
        }
    }


    public static class SpecialAttacks
    {
        public static FMODAsset NextAsset = AudioUtils.GetFmodAsset("event:/env/input_number");
        public static FMODAsset SeismicAsset = AudioUtils.GetFmodAsset("event:/creature/crash/die");
        public static FMODAsset ExplosiveAsset = AudioUtils.GetFmodAsset("event:/creature/crash/die");
        public static FMODAsset NanoswarmAsset = AudioUtils.GetFmodAsset("event:/tools/stasis_gun/sphere_enter");
        public static FMODAsset VitalityAsset = AudioUtils.GetFmodAsset("event:/tools/stasis_gun/sphere_enter");
        public static FMODAsset AnomalyAsset = AudioUtils.GetFmodAsset("event:/tools/stasis_gun/sphere_enter");


        public static void Seismic(GameObject creature, LiveMixin livemixin)
        {
            WorldForces.AddCurrent(creature.transform.position, DayNightCycle.main.timePassed, 10f, -Vector3.Cross(Player.main.transform.forward, new Vector3(0, 1, 0)), creature.GetComponent<Rigidbody>().mass * 1.5f, 4f);
            MainCameraControl.main.ShakeCamera(1f, 1.5f, MainCameraControl.ShakeMode.Linear, 1.4f);
            FMODUWE.PlayOneShot(SeismicAsset, creature.transform.position, 1f);
        }


        public static void Explosive(GameObject creature, LiveMixin livemixin)
        {
            FMODUWE.PlayOneShot(ExplosiveAsset, creature.transform.position, 1f);
        }


        public static void Nanoswarm(GameObject creature, LiveMixin livemixin)
        {
            livemixin.TakeDamage(10f, creature.transform.position, DamageType.Electrical);
            FMODUWE.PlayOneShot(NanoswarmAsset, creature.transform.position);
            creature.AddComponent<CreatureFreezer>();
        }


        public static void Vitality(GameObject creature, LiveMixin livemixin)
        {
            livemixin.AddHealth(5f);
            FMODUWE.PlayOneShot(VitalityAsset, creature.transform.position);
        }


        public static void Anomaly(GameObject creature, LiveMixin livemixin)
        {
            livemixin.TakeDamage(10f, creature.transform.position, DamageType.Electrical);
            FMODUWE.PlayOneShot(AnomalyAsset, creature.transform.position);
        }
    }
}