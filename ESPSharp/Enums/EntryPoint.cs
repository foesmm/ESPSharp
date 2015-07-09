﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESPSharp.Enums
{
    public enum EntryPoint : byte
    {
        CalculateWeaponDamage = 0,
        CalculateMyCriticalHitChance,
        CalculateMyCriticalHitDamange,
        CalculateWeaponAttackAPCost,
        CalculateMineExplodeChance,
        AdjustRangePenalty,
        AdjustLimbDamage,
        CalculateWeaponRange,
        CalculateToHitChance,
        AdjustExperiencePoints,
        AdjustGainedSkillPoints,
        AdjustBookSkillPoints,
        ModifyRecoveredHealth,
        CalculateInventoryAPCost,
        GetDisposition,
        GetShouldAttack,
        GetShouldAssist,
        CalculateBuyPrice,
        GetBadKarma,
        GetGoodKarma,
        IgnoreLockedTerminal,
        AddLeveledListOnDeath,
        GetMaxCarryWeight,
        ModifyAddictionChance,
        ModifyAddictionDuration,
        ModifyPositiveChemDuration,
        AdjustDrinkingRadiation,
        Activate,
        MysteriousStranger,
        HasParalyzingPalm,
        HackingScienceBonus,
        IgnoreRunningDuringDetection,
        IgnoreBrokenLock,
        HasConcentratedFire,
        CalculateGunSpread,
        PlayerKillAPAward,
        ModifyEnemyCriticalHitChance,
        ReloadSpeed,
        EquipSpeed,
        ActionPointRegen,
        ActionPointCost,
        MissFortune,
        ModifyRunSpeed,
        ModifyAttackSpeed,
        ModifyRadiationConsumed,
        HasPipHacker,
        HasMeltdown,
        SeeEnemyHealth,
        HasJuryRigging,
        ModifyThreatRange,
        ModifyThreat,
        HasFastTravelAlways,
        KnockdownChance,
        ModifyWeaponStrengthReq,
        ModifyAimingMoveSpeed,
        ModifyLightItems,
        ModifyDamageThresholdDefender,
        ModifyChanceForAmmoItem,
        ModifyDamageThresholdAttacker,
        ModifyThrowingVelocity,
        ChanceForItemOnFire,
        HasUnarmedForwardPowerAttack,
        HasUnarmedBackPowerAttack,
        HasUnarmedCrouchedPowerAttack,
        HasUnarmedCounterPowerAttack,
        HasUnarmedLeftPowerAttack,
        HasUnarmedRightPowerAttack,
        VATSHelperChance,
        ModifyItemDamage,
        HasImprovedDetection,
        HasImprovedSpotting,
        HasImprovedItemDetection,
        AdjustExplosionRadius,
        Reserved
    }
}