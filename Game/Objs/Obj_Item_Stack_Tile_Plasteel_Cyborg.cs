// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Tile_Plasteel_Cyborg : Obj_Item_Stack_Tile_Plasteel {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.materials = new ByTable();
			this.is_cyborg = true;
			this.cost = 125;
		}

		public Obj_Item_Stack_Tile_Plasteel_Cyborg ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

	}

}