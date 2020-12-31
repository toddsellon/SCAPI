using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Sandbox.Common;
using Sandbox.Game.World;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.Game.EntityComponents;
using Sandbox.Game.GameSystems;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces;
using Sandbox.ModAPI.Weapons;
using SpaceEngineers.Game.ModAPI;
using ProtoBuf;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Utils;
using VRageMath;
using VRage.Collections;
using SCAPI;

namespace SCAPI {

	[MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation)]
	public class SCAPISession:MySessionComponentBase {

		private bool Done = false;

    public override void Init(MyObjectBuilder_SessionComponent session) {
      base.Init(session);
			Done = !MyAPIGateway.Multiplayer.IsServer;
    }

		public override void UpdateBeforeSimulation() {
			if( Done ) return;

			SCAPI.Set("difficulty","2");

			MyAPIGateway.Utilities.ShowMessage( "SCAPISession", "Done" );

			Done = true;
		}

  }
}
