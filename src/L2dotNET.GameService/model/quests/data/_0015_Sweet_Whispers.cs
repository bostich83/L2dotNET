﻿using L2dotNET.GameService.Model.Npcs;
using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Model.Quests.Data
{
    class _0015_Sweet_Whispers : QuestOrigin
    {
        private const int trader_vladimir = 31302;
        private const int dark_necromancer = 31518;
        private const int dark_presbyter = 31517;

        public _0015_Sweet_Whispers()
        {
            questId = 15;
            questName = "Sweet Whispers";
            startNpc = trader_vladimir;
            talkNpcs = new int[] { startNpc, dark_necromancer, dark_presbyter };
        }

        public override void tryAccept(L2Player player, L2Npc npc)
        {
            if (player.Level >= 60)
                player.ShowHtm("trader_vladimir_q0015_0101.htm", npc);
            else
            {
                player.ShowHtm("trader_vladimir_q0015_0103.htm", npc);
            }
        }

        public override void onAccept(L2Player player, L2Npc npc)
        {
            player.questAccept(new QuestInfo(this));
            player.ShowHtm("trader_vladimir_q0015_0104.htm", npc);
        }

        public override void onTalkToNpcQM(L2Player player, L2Npc npc, int reply)
        {
            //todo
        }

        public override void onTalkToNpc(L2Player player, L2Npc npc, int cond)
        {
            int npcId = npc.Template.NpcId;
            string htmltext = no_action_required;
            switch (npcId)
            {
                case trader_vladimir:
                    switch (cond)
                    {
                        case 1:
                            htmltext = "trader_vladimir_q0015_0105.htm";
                            break;
                    }
                    break;
                case dark_necromancer:
                    switch (cond)
                    {
                        case 1:
                            htmltext = "dark_necromancer_q0015_0101.htm";
                            break;
                        case 2:
                            htmltext = "dark_necromancer_q0015_0202.htm";
                            break;
                    }
                    break;
                case dark_presbyter:
                    switch (cond)
                    {
                        case 2:
                            htmltext = "dark_presbyter_q0015_0201.htm";
                            break;
                    }
                    break;
            }

            player.ShowHtm(htmltext, npc);
        }

        public override void onEarnItem(L2Player player, int cond, int id)
        {
            //todo
        }
    }
}