﻿using Assets.Scripts.Atmospherics;
using Assets.Scripts;
using HarmonyLib;
using UnityEngine;

namespace ColoredGasses
{
    internal class GasParticles
    {
        [HarmonyPatch(typeof(AtmosphericsManager), nameof(AtmosphericsManager.EmitAirVisualizerParticles))]
        public static class AtmosphericsManager_EmitAirVisualizerParticles_Patch
        {
            public static int id;
            //public static List<Atmosphere> AtmosphericsManager.AllAtmospheres;
            [HarmonyPrefix]
            static bool Prefix(AtmosphericsManager __instance) //AtmosphericsController atmosphericsController, 
            {
                if (ColoredGasses.toggleColorGasParticles.Value)
                {
                    for (int j = 0; j < AtmosphericsManager.AllAtmospheres.Count; j++)
                    {
                        id = j;
                    }
                    if (AtmosphericsManager.AllAtmospheres[id].DisplayName.Contains("WorldAtmosphere"))
                    {
                        float carbon = AtmosphericsManager.AllAtmospheres[id].GetGasTypeRatio(Chemistry.GasType.CarbonDioxide);
                        float volatiles = AtmosphericsManager.AllAtmospheres[id].GetGasTypeRatio(Chemistry.GasType.Volatiles);
                        float pollutant = AtmosphericsManager.AllAtmospheres[id].GetGasTypeRatio(Chemistry.GasType.Pollutant);
                        float nitrogen = AtmosphericsManager.AllAtmospheres[id].GetGasTypeRatio(Chemistry.GasType.Nitrogen);
                        float oxygen = AtmosphericsManager.AllAtmospheres[id].GetGasTypeRatio(Chemistry.GasType.Oxygen);
                        float nitrousOxide = AtmosphericsManager.AllAtmospheres[id].GetGasTypeRatio(Chemistry.GasType.NitrousOxide);
                        float maxValue = 0f;
                        if (carbon / 100 > maxValue)
                        {
                            AtmosphericsManager.emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedCarbon.Value, (byte)ColoredGasses.RGBGreenCarbon.Value, (byte)ColoredGasses.RGBBlueCarbon.Value, 255);
                            AtmosphericsManager.Emit(AtmosphericsManager.AllAtmospheres, AtmosphericsController.World.GasVisualizerParticleSystem, UnityEngine.Random.insideUnitSphere, AtmosphericsManager.AirVisualizerEmitCondition, true);
                        }
                        if (volatiles / 100 > maxValue)
                        {
                            AtmosphericsManager.emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedVolatiles.Value, (byte)ColoredGasses.RGBGreenVolatiles.Value, (byte)ColoredGasses.RGBBlueVolatiles.Value, 255);
                            AtmosphericsManager.Emit(AtmosphericsManager.AllAtmospheres, AtmosphericsController.World.GasVisualizerParticleSystem, UnityEngine.Random.insideUnitSphere, AtmosphericsManager.AirVisualizerEmitCondition, true);
                        }
                        if (pollutant / 100 > maxValue)
                        {
                            AtmosphericsManager.emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedPollutant.Value, (byte)ColoredGasses.RGBGreenPollutant.Value, (byte)ColoredGasses.RGBBluePollutant.Value, 255);
                            AtmosphericsManager.Emit(AtmosphericsManager.AllAtmospheres, AtmosphericsController.World.GasVisualizerParticleSystem, UnityEngine.Random.insideUnitSphere, AtmosphericsManager.AirVisualizerEmitCondition, true);
                        }
                        if (nitrogen / 100 > maxValue)
                        {
                            AtmosphericsManager.emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedNitrogen.Value, (byte)ColoredGasses.RGBGreenNitrogen.Value, (byte)ColoredGasses.RGBBlueNitrogen.Value, 255);
                            AtmosphericsManager.Emit(AtmosphericsManager.AllAtmospheres, AtmosphericsController.World.GasVisualizerParticleSystem, UnityEngine.Random.insideUnitSphere, AtmosphericsManager.AirVisualizerEmitCondition, true);
                        }
                        if (oxygen / 100 > maxValue)
                        {
                            AtmosphericsManager.emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedOxygen.Value, (byte)ColoredGasses.RGBGreenOxygen.Value, (byte)ColoredGasses.RGBBlueOxygen.Value, 255);
                            AtmosphericsManager.Emit(AtmosphericsManager.AllAtmospheres, AtmosphericsController.World.GasVisualizerParticleSystem, UnityEngine.Random.insideUnitSphere, AtmosphericsManager.AirVisualizerEmitCondition, true);
                        }
                        if (nitrousOxide / 100 > maxValue)
                        {
                            AtmosphericsManager.emitParams.startColor = new Color32((byte)ColoredGasses.RGBRedNitrousOxide.Value, (byte)ColoredGasses.RGBGreenNitrousOxide.Value, (byte)ColoredGasses.RGBBlueNitrousOxide.Value, 255);
                            AtmosphericsManager.Emit(AtmosphericsManager.AllAtmospheres, AtmosphericsController.World.GasVisualizerParticleSystem, UnityEngine.Random.insideUnitSphere, AtmosphericsManager.AirVisualizerEmitCondition, true);
                        }
                        return false;
                    }
                }
                else
                {
                    AtmosphericsManager.emitParams.startColor = new Color(255, 255, 255, 255);
                    //AtmosphericsManager.Emit(AtmosphericsManager.AllAtmospheres, AtmosphericsController.World.GasVisualizerParticleSystem, UnityEngine.Random.insideUnitSphere, AtmosphericsManager.AirVisualizerEmitCondition, true);
                }
                return true;
            }
        }
    }
}
