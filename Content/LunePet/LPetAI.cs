using LuneLib.Common.Players.LuneLibPlayer;
using LuneLib.Utilities;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

using static LuneLib.Utilities.LuneLibUtils;

namespace LuneLib.Content.LunePet
{
    public partial class LPet : ModProjectile
    {
        private int sleepyTimer = 0;
        private int lightLevel = 0;
        private bool sleepy;
        private bool asleep;
        private Vector2 mouseVec;
        private bool isItLeft = false;
        private bool isItRight = false;

        public void FollowMouse()
        {
            Player player = Main.player[Projectile.owner];

            LibPlayer modPlayer = player.LibPlayer();

            if (!player.active)
            {
                Projectile.active = false;
                return;
            }

            if (player.dead)
            {
                modPlayer.LunesSpiritPet = false;
            }

            if (modPlayer.LunesSpiritPet)
            {
                Projectile.timeLeft = 2;
            }

            if (Main.mouseRight && player.whoAmI == Main.myPlayer)
            {
                sleepyTimer++;
                if (sleepyTimer >= 61)
                {
                    sleepy = false;
                    asleep = false;
                }
                if (sleepyTimer >= 180)
                {
                    sleepyTimer = 180;
                }
            }

            if (!Main.mouseRight && player.whoAmI == Main.myPlayer)
            {
                sleepyTimer = 0;
                sleepy = false;
                asleep = true;
            }

            if (sleepyTimer >= 15 && sleepyTimer <= 60 && player.whoAmI == Main.myPlayer)
            {
                sleepy = true;
                asleep = false;
            }

            if (!asleep)
            {
                Projectile.frameCounter++;
                if (Projectile.frameCounter > 6)
                {
                    Projectile.frame++;
                    Projectile.frameCounter = 0;
                }
            }

            if (!asleep && !sleepy)
            {
                if (Projectile.frame >= 8)
                {
                    Projectile.frame = 0;
                }
            }

            if (!asleep && sleepy)
            {
                if (Projectile.frame >= 16)
                {
                    Projectile.frame = 8;
                }
            }

            if (!sleepy && !asleep)
            {
                lightLevel = 0;
            }

            if (sleepy && !asleep)
            {
                lightLevel = 1;
            }

            if (asleep)
            {
                lightLevel = 2;
                Projectile.frame = 16;
            }

            switch (lightLevel)
            {
                case 0:
                    Lighting.AddLight(Projectile.Center, 0f, 2f, 2.5f);
                    break;
                case 1:
                    Lighting.AddLight(Projectile.Center, 0f, 1.32f, 1.65f);
                    break;
                case 2:
                    Lighting.AddLight(Projectile.Center, 0f, 0.5f, 0.7f);
                    break;
            }
            Projectile.netUpdate = true;

            float velAdjustment = 0.2f;
            float speedLimit = 16f;
            Vector2 playerVec = player.Center - Projectile.Center;
            playerVec.Y += player.gfxOffY;
            playerVec.Y -= 60f;
            bool left = false;
            bool right = false;

            if (player.direction == 1)
            {
                right = true;
            }
            if (player.direction == -1)
            {
                left = true;
            }

            if (Projectile.velocity.X == 0f && left)
            {
                Projectile.direction = -1;
                right = false;
            }
            else if (Projectile.velocity.X == 0f && right)
            {
                Projectile.direction = 1;
                left = false;
            }

            Projectile.spriteDirection = Projectile.direction;

            float playerDist = playerVec.Length();

            if (playerDist > 1000f && asleep)
            {
                Projectile.position.X += playerVec.X;
                Projectile.position.Y += playerVec.Y;
            }
            if (playerDist < 10f && asleep)
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

            if (asleep)
            {
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
            }

            if (Projectile.velocity.X != 0f || Projectile.velocity.Y != 0f)
            {
                Projectile.rotation = Projectile.velocity.X * 0.05f;
            }

            if (!asleep)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    mouseVec = Main.MouseWorld - Projectile.Center;
                    mouseVec.Y -= 60f;
                }

                float mouseDist = mouseVec.Length();

                float maxSpeed = 16f;
                float Acceleration = 0.2f;

                if (mouseDist <= 10f)
                {
                    Projectile.velocity = Vector2.Zero;
                }
                else
                {
                    mouseDist = maxSpeed / mouseDist;
                    mouseVec *= mouseDist;
                    if (Projectile.velocity.X < mouseVec.X)
                    {
                        Projectile.velocity.X += Acceleration;
                        if (Projectile.velocity.X < 0f)
                        {
                            Projectile.velocity.X *= 0.99f;
                        }
                    }
                    if (Projectile.velocity.X > mouseVec.X)
                    {
                        Projectile.velocity.X -= Acceleration;
                        if (Projectile.velocity.X > 0f)
                        {
                            Projectile.velocity.X *= 0.99f;
                        }
                    }
                    if (Projectile.velocity.Y < mouseVec.Y)
                    {
                        Projectile.velocity.Y += Acceleration;
                        if (Projectile.velocity.Y < 0f)
                        {
                            Projectile.velocity.Y *= 0.99f;
                        }
                    }
                    if (Projectile.velocity.Y > mouseVec.Y)
                    {
                        Projectile.velocity.Y -= Acceleration;
                        if (Projectile.velocity.Y > 0f)
                        {
                            Projectile.velocity.Y *= 0.99f;
                        }
                    }
                }

                if (Projectile.velocity.X != 0f || Projectile.velocity.Y != 0f)
                {
                    Projectile.rotation = Projectile.velocity.X * 0.05f;
                }
                else if (Projectile.velocity.X == 0f || Projectile.velocity.Y == 0f)
                {
                    Projectile.rotation = Projectile.oldVelocity.X * 0.05f;
                }

                if (player.whoAmI == Main.myPlayer)
                {
                    if (Main.MouseWorld.X < player.Center.X)
                    {
                        isItLeft = true;
                        isItRight = false;
                    }
                    else if (Main.MouseWorld.X > player.Center.X)
                    {
                        isItLeft = false;
                        isItRight = true;
                    }
                }

                if (isItLeft)
                {
                    Projectile.spriteDirection = -1;
                }
                else if (isItRight)
                {
                    Projectile.spriteDirection = 1;
                }
            }
            Projectile.netUpdate = true;
        }
    }
}
