﻿using Assets.Scripts.Atmospherics;
using Assets.Scripts.Objects;
using HarmonyLib;
using System;
using UnityEngine;

namespace ColoredGasses
{
    internal class CondensationParticles
    {
        [HarmonyPatch(typeof(AtmosphericFog), nameof(AtmosphericFog.EmitAtmosphericFogParticles))]
        public static class AtmosphericFog_EmitAtmosphericFogParticles_Patch
        {
            [HarmonyPrefix]
            static bool Prefix(AtmosphericFog __instance)
            {
                if (ColoredGasses.toggleColorCondensationParticles.Value)
                {

                    if (AtmosphericFog.AllAtmosphericFogs.Count <= 0)
                    {
                        return false;
                    }
                    int num = AtmosphericFog.MAXFogParticles - AtmosphericFog.AtmosphericFogParticleSystem.particleCount;
                    int num2 = (AtmosphericFog._lastIndex != -1) ? AtmosphericFog._lastIndex : (AtmosphericFog.AllAtmosphericFogs.Count - 1);
                    if (num2 > AtmosphericFog.AllAtmosphericFogs.Count - 1)
                    {
                        num2 = AtmosphericFog.AllAtmosphericFogs.Count - 1;
                    }
                    int num3 = 0;
                    for (int i = num2; i >= 0; i--)
                    {
                        try
                        {
                            if (num <= 0 || (float)num3 >= 30f)
                            {
                                AtmosphericFog._lastIndex = i;
                                break;
                            }
                            AtmosphericFog._lastIndex = i;
                            AtmosphericFog atmosphericFog = AtmosphericFog.AllAtmosphericFogs[i];
                            ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
                            float maxValue = 0f;
                            if (atmosphericFog.IsEmitting() && !atmosphericFog.IsEmitCooldown)
                            {
                                //if (ColoredGasses.toggleColorCondensationParticles.Value)
                                //{
                                float polwater = atmosphericFog.Atmosphere.GetGasTypeRatio(Chemistry.GasType.PollutedWater);
                                float water = atmosphericFog.Atmosphere.GetGasTypeRatio(Chemistry.GasType.Water);
                                float liquidCo2 = atmosphericFog.Atmosphere.GetGasTypeRatio(Chemistry.GasType.LiquidCarbonDioxide);
                                float liquidNitrogen = atmosphericFog.Atmosphere.GetGasTypeRatio(Chemistry.GasType.LiquidNitrogen);
                                float liquidNitrousOxide = atmosphericFog.Atmosphere.GetGasTypeRatio(Chemistry.GasType.LiquidNitrousOxide);
                                float liquidOxygen = atmosphericFog.Atmosphere.GetGasTypeRatio(Chemistry.GasType.LiquidOxygen);
                                float liquidPollutant = atmosphericFog.Atmosphere.GetGasTypeRatio(Chemistry.GasType.LiquidPollutant);
                                float liquidVolatiles = atmosphericFog.Atmosphere.GetGasTypeRatio(Chemistry.GasType.LiquidVolatiles);
                                AtmosphericFog.AtmosphereFogVisualizerTransform.position = atmosphericFog.EmissionPosition();

                                if (polwater / 100 > maxValue)
                                {
                                    emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedPolWater.Value, (byte)ColoredGasses.RGBGreenPolWater.Value, (byte)ColoredGasses.RGBBluePolWater.Value, (byte)ColoredGasses.RGBAlphaPolWater.Value);
                                    AtmosphericFog.AtmosphericFogParticleSystem.Emit(emitParams, 1);
                                }
                                if (water / 100 > maxValue)
                                {
                                    emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedWater.Value, (byte)ColoredGasses.RGBGreenWater.Value, (byte)ColoredGasses.RGBBlueWater.Value, (byte)ColoredGasses.RGBAlphaWater.Value);
                                    AtmosphericFog.AtmosphericFogParticleSystem.Emit(emitParams, 1);
                                }
                                if (liquidCo2 / 100 > maxValue)
                                {
                                    emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedCarbon.Value, (byte)ColoredGasses.RGBGreenCarbon.Value, (byte)ColoredGasses.RGBBlueCarbon.Value, (byte)ColoredGasses.RGBAlphaCarbon.Value);
                                    AtmosphericFog.AtmosphericFogParticleSystem.Emit(emitParams, 1);
                                }
                                if (liquidNitrogen / 100 > maxValue)
                                {
                                    emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedNitrogen.Value, (byte)ColoredGasses.RGBGreenNitrogen.Value, (byte)ColoredGasses.RGBBlueNitrogen.Value, (byte)ColoredGasses.RGBAlphaNitrogen.Value);
                                    AtmosphericFog.AtmosphericFogParticleSystem.Emit(emitParams, 1);
                                }
                                if (liquidNitrousOxide / 100 > maxValue)
                                {
                                    emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedNitrousOxide.Value, (byte)ColoredGasses.RGBGreenNitrousOxide.Value, (byte)ColoredGasses.RGBBlueNitrousOxide.Value, (byte)ColoredGasses.RGBAlphaNitrousOxide.Value);
                                    AtmosphericFog.AtmosphericFogParticleSystem.Emit(emitParams, 1);
                                }
                                if (liquidOxygen / 100 > maxValue)
                                {
                                    emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedOxygen.Value, (byte)ColoredGasses.RGBGreenOxygen.Value, (byte)ColoredGasses.RGBBlueOxygen.Value, (byte)ColoredGasses.RGBAlphaOxygen.Value);
                                    AtmosphericFog.AtmosphericFogParticleSystem.Emit(emitParams, 1);
                                }
                                if (liquidPollutant / 100 > maxValue)
                                {
                                    emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedPollutant.Value, (byte)ColoredGasses.RGBGreenPollutant.Value, (byte)ColoredGasses.RGBBluePollutant.Value, (byte)ColoredGasses.RGBAlphaPollutant.Value);
                                    AtmosphericFog.AtmosphericFogParticleSystem.Emit(emitParams, 1);
                                }
                                if (liquidVolatiles / 100 > maxValue)
                                {
                                    emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedVolatiles.Value, (byte)ColoredGasses.RGBGreenVolatiles.Value, (byte)ColoredGasses.RGBBlueVolatiles.Value, (byte)ColoredGasses.RGBAlphaVolatiles.Value);
                                    AtmosphericFog.AtmosphericFogParticleSystem.Emit(emitParams, 1);
                                }
                                //}
                                // else
                                // {
                                //     AtmosphericFog.AtmosphericFogParticleSystem.Emit(1);
                                // }
                                atmosphericFog._lastEmitTime = Time.fixedTime;
                                num--;
                                num3++;
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            AtmosphericFog._lastIndex = i;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            AtmosphericFog._lastIndex = i;
                        }
                    }
                    if (num > 0)
                    {
                        AtmosphericFog._lastIndex = -1;
                    }
                    return false;
                }
                else return true;
            }
        }
    }
}
