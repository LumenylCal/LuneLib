using LuneLib.Common.Players.LuneLibPlayer;
using LuneLib.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuneWoL.Content.LunePet
{
    public partial class LPet : ModProjectile
    {
        public override string Texture => "LuneLib/Assets/Images/LPet";
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
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

        public void FollowMouse()
        {
            // In Multi Player (MP) This code only runs on the client of the Projectile's owner, this is because it relies on mouse position, which isn't the same across all clients.
            if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
            {

                Player player = Main.player[Projectile.owner];
                // If the player channels the weapon, do something. This check only works if item.channel is true for the weapon.
                if (player.channel)
                {
                    float maxDistance = 18f; // This also sets the maximun speed the Projectile can reach while following the cursor.
                    Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                    float distanceToCursor = vectorToCursor.Length();

                    // Here we can see that the speed of the Projectile depends on the distance to the cursor.
                    if (distanceToCursor > maxDistance)
                    {
                        distanceToCursor = maxDistance / distanceToCursor;
                        vectorToCursor *= distanceToCursor;
                    }

                    int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
                    int oldVelocityXBy1000 = (int)(Projectile.velocity.X * 1000f);
                    int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
                    int oldVelocityYBy1000 = (int)(Projectile.velocity.Y * 1000f);

                    // This code checks if the precious velocity of the Projectile is different enough from its new velocity, and if it is, syncs it with the server and the other clients in MP.
                    // We previously multiplied the speed by 1000, then casted it to int, this is to reduce its precision and prevent the speed from being synced too much.
                    if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
                    {
                        Projectile.netUpdate = true;
                    }

                    Projectile.velocity = vectorToCursor;

                }
            }
        }

        public void OldAI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.active)
            {
                Projectile.active = false;
                return;
            }
            LibPlayer modPlayer = player.LibPlayer();
            if (player.dead)
            {
                modPlayer.LunesSpiritPet = false;
            }
            if (modPlayer.LunesSpiritPet)
            {
                Projectile.timeLeft = 2;
            }

            Projectile.frameCounter++;
            if (Projectile.frameCounter > 8)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame >= 8)
            {
                Projectile.frame = 0;
            }

            // Always emit light
            Lighting.AddLight(Projectile.Center, 0f, 1.32f, 1.65f); // Light level 1

            float velAdjustment = 0.2f;
            float speedLimit = 5f;
            Vector2 playerVec = player.Center - Projectile.Center;
            playerVec.Y += player.gfxOffY;
            if (player.controlLeft)
            {
                playerVec.X -= 120f;
            }
            else if (player.controlRight)
            {
                playerVec.X += 120f;
            }
            if (player.controlDown)
            {
                playerVec.Y += 120f;
            }
            else
            {
                if (player.controlUp)
                {
                    playerVec.Y -= 120f;
                }
                playerVec.Y -= 60f;
            }

            if (Projectile.velocity.X < -0.25f || player.controlLeft)
            {
                Projectile.direction = -1; //face left
            }
            else if (Projectile.velocity.X > 0.25f || player.controlRight)
            {
                Projectile.direction = 1; //face right
            }
            Projectile.spriteDirection = Projectile.direction;

            float playerDist = playerVec.Length();
            if (playerDist > 1000f)
            {
                Projectile.position.X += playerVec.X;
                Projectile.position.Y += playerVec.Y;
            }
            if (Projectile.localAI[0] == 1f)
            {
                if (playerDist < 10f && player.velocity.Length() < speedLimit && player.velocity.Y == 0f)
                {
                    Projectile.localAI[0] = 0f;
                }
                speedLimit = 12f;
                if (playerDist < speedLimit)
                {
                    Projectile.velocity = playerVec;
                }
                else
                {
                    playerDist = speedLimit / playerDist;
                    Projectile.velocity = playerVec * playerDist;
                }
                Projectile.rotation = Projectile.velocity.X * 0.05f;
                return;
            }
            if (playerDist > 200f)
            {
                Projectile.localAI[0] = 1f;
            }
            if (playerDist < 10f)
            {
                Projectile.velocity.X = playerVec.X;
                Projectile.velocity.Y = playerVec.Y;
                Projectile.rotation = Projectile.velocity.X * 0.05f;
                if (playerDist < speedLimit)
                {
                    Projectile.position += Projectile.velocity;
                    Projectile.velocity *= 0f;
                    velAdjustment = 0f;
                }
            }
            playerDist = speedLimit / playerDist;
            playerVec *= playerDist;
            if (Projectile.velocity.X < playerVec.X)
            {
                Projectile.velocity.X += velAdjustment;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.velocity.X *= 0.99f;
                }
            }
            if (Projectile.velocity.X > playerVec.X)
            {
                Projectile.velocity.X -= velAdjustment;
                if (Projectile.velocity.X > 0f)
                {
                    Projectile.velocity.X *= 0.99f;
                }
            }
            if (Projectile.velocity.Y < playerVec.Y)
            {
                Projectile.velocity.Y += velAdjustment;
                if (Projectile.velocity.Y < 0f)
                {
                    Projectile.velocity.Y *= 0.99f;
                }
            }
            if (Projectile.velocity.Y > playerVec.Y)
            {
                Projectile.velocity.Y -= velAdjustment;
                if (Projectile.velocity.Y > 0f)
                {
                    Projectile.velocity.Y *= 0.99f;
                }
            }
            if (Projectile.velocity.X != 0f || Projectile.velocity.Y != 0f)
            {
                Projectile.rotation = Projectile.velocity.X * 0.05f;
            }
        }
    }
}
