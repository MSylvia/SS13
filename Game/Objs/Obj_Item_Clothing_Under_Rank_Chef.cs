// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Rank_Chef : Obj_Item_Clothing_Under_Rank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this._color = "chef";
			this.flags = 8448;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "chef";
		}

		public Obj_Item_Clothing_Under_Rank_Chef ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}