﻿using System.Collections.Generic;
using L2dotNET.DataContracts;

namespace L2dotNET.Services.Contracts
{
    public interface IPlayerService
    {
        PlayerContract GetAccountByLogin(int objId);

        bool CheckIfPlayerNameExists(string name);

        void CreatePlayer(PlayerContract player);

        void UpdatePlayer(PlayerContract player);

        PlayerContract GetPlayerModelBySlotId(string accountName, int slotId);

        bool MarkToDeleteChar(int objId, long deletetime);

        bool MarkToRestoreChar(int objId);

        bool DeleteCharByObjId(int objId);

        List<SkillResponseContract> GetPlayerSkills(int objId);
    }
}