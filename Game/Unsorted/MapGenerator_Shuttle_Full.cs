// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGenerator_Shuttle_Full : MapGenerator_Shuttle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.modules = new ByTable(new object [] { typeof(MapGeneratorModule_BottomLayer_ShuttleFloor), typeof(MapGeneratorModule_Border_ShuttleWalls), typeof(MapGeneratorModule_BottomLayer_Repressurize) });
		}

	}

}