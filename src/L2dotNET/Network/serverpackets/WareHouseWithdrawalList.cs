﻿using System.Collections.Generic;
using L2dotNET.Models.Items;
using L2dotNET.Models.Player;

namespace L2dotNET.Network.serverpackets
{
    class WareHouseWithdrawalList : GameserverPacket
    {
        public static short WhPrivate = 1;
        public static short WhClan = 2;
        public static short WhCastle = 3;
        public static short WhFreight = 4;
        private readonly List<L2Item> _items;
        private readonly short _type;
        private readonly int _adena;

        public WareHouseWithdrawalList(L2Player player, List<L2Item> items, short type)
        {
            _type = type;
            _adena = player.GetAdena();
            _items = items;
        }

        public override void Write()
        {
            WriteByte(0x42);
            WriteShort(_type);
            WriteLong(_adena);
            WriteShort(_items.Count);

            foreach (L2Item item in _items)
            {
                WriteShort(item.Template.Type1);
                WriteInt(item.ObjectId);
                WriteInt(item.Template.ItemId);
                WriteInt(item.Count);
                WriteShort(item.Template.Type2);
                WriteShort(0); //custom type 1
                WriteInt((int) item.Template.BodyPart);
                WriteShort(item.Enchant);
                WriteShort(0); //custom type 2
                WriteShort(0);
                //writeD(item.AugmentationID);
                WriteInt(item.ObjectId);
                WriteLong(0x00);
            }
        }
    }
}