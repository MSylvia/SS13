// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Gloves_Orange : Obj_Item_Clothing_Gloves {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "orange";
			this._color = "orange";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "orange";
		}

		public Obj_Item_Clothing_Gloves_Orange ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}