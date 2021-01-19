using System;
using System.Collections;
using System.Collections.Generic;
using VRageMath;
using VRage;
using VRage.Game.Entity;
using VRage.Game.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using VRage.Game.ModAPI.Ingame.Utilities;
using Sandbox.Game.Entities;
using SCAPI;

namespace SCAPI {

  // You can rename this class to be whatever you want
  public class SCAPI {

    protected static ushort Id = 8008; // Do not change this

    public static void ChatMessage( string sender, string text, string sound = "" ) {
      Send( new Message {
        Text = text,
        Sender = sender,
        Sound = sound
      });
    }

    // Toggles debug mode on/off
    public static void Debug() {
      Send( new Message {
        Text = "/sc debug"
      });
    }

    // Displays the value of a convar in the chat
    public static void Get( string convar ) {
      Send( new Message {
        Text = "/sc get " + convar
      });
    }

    // Changes the value of a convar
    public static void Set( string convar, string value ) {
      Send( new Message {
        Text = "/sc set " + convar + " " + value
      });
    }

    // Spawns the specified prefab for target faction or host player's faction if not specified
    public static void Spawn( string prefab, string faction = "" ) {
      Send( new Message {
        Text = "/sc spawn \"" + prefab + "\" " + faction
      });
    }

    // Completes construction for target faction or host player's faction if not specified
    public static void Complete( string prefab, string faction = "" ) {
      Send( new Message {
        Text = "/sc complete " + faction
      });
    }

    // Pays off all balances for target faction or host player's faction if not specified
    public static void Pay( string prefab, string faction = "" ) {
      Send( new Message {
        Text = "/sc pay " + faction
      });
    }

    // Faction takes control of specified entity
    public static void Control( long entityId, string faction = "" ) {
      Send( new Message {
        Text = "/sc control " + entityId.ToString() + " " + faction
      });
    }

    public static void Control( IMyEntity entity, string faction = "" ) {
      Control(entity.EntityId, faction);
    }

    // Faction loses control of specified entity
    public static void Release( long entityId, string faction = "" ) {
      Send( new Message {
        Text = "/sc release " + entityId.ToString() + " " + faction
      });
    }

    public static void Release( IMyEntity entity, string faction = "" ) {
      Release(entity.EntityId, faction);
    }

    // Respawns specified faction optionally onto specified planet. Set remain to true to leave behind loot
    public static void Respawn( string faction = "", string planet = "", bool remain = false ) {
      Send( new Message {
        Text = "/sc respawn " + faction + " " + planet + (remain ? " -remain" : String.Empty)
      });
    }

    // Donates the grid controlled by the host player
    public static void Donate() {
      Send( new Message {
        Text = "/sc donate"
      });
    }

    // Donates the grid controlled by the specified player
    public static void Donate( ulong steamUserId, long identityId ) {
      Send( new Message {
        Text = "/sc donate",
        SteamUserId = steamUserId,
        PlayerID = identityId
      });
    }

    public static bool Send(Message message) {
      if( message == null ) return false;
      IMyPlayer player = MyAPIGateway.Session.LocalHumanPlayer;
      message.SteamUserId = message.SteamUserId == 0 ? player.SteamUserId : message.SteamUserId;
      message.PlayerID = message.PlayerID == 0 ? player.IdentityId : message.PlayerID;

      byte[] data = MyAPIGateway.Utilities.SerializeToBinary<Message>(message);
      return MyAPIGateway.Multiplayer.SendMessageToServer(Id, data);
    }


  }

}
