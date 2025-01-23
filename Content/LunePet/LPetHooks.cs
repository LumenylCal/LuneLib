using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Content.LunePet
{
    public partial class LPet : ModProjectile
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return LuneLib.debug.LunesPet;
        }
        public override string Texture => "LuneLib/Assets/Images/LPet/LPet";
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 17;
            if (!LL)
            {
                Main.projPet[Projectile.type] = true;
                ProjectileID.Sets.LightPet[Projectile.type] = true;
            }
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 38;
            Projectile.height = 58;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft *= 5;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
        {
            Projectile.netUpdate = true;
            FollowMouse();

            if (LuneLib.clientConfig.DebugMessages && sleepyTimer > 30)
            {
                Main.NewText($"Sleepy? {sleepy}, Asleep? {asleep}, LightLevel? {lightLevel}, SleepyTimer? {sleepyTimer}, Left {isItLeft}, Right {isItRight}");
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(isItLeft);
            writer.Write(isItRight);
            writer.Write(asleep);
            writer.Write(sleepy);
            writer.Write(sleepyTimer);
            writer.Write(lightLevel);
            writer.WriteVector2(mouseVec);
            writer.Write7BitEncodedInt(Projectile.spriteDirection);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            isItLeft = reader.ReadBoolean();
            isItRight = reader.ReadBoolean();
            asleep = reader.ReadBoolean();
            sleepy = reader.ReadBoolean();
            sleepyTimer = reader.ReadInt32();
            lightLevel = reader.ReadInt32();
            mouseVec = reader.ReadVector2();
            Projectile.spriteDirection = reader.Read7BitEncodedInt();
        }

    }
}
