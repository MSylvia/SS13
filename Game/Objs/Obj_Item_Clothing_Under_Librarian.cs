// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Librarian : Obj_Item_Clothing_Under {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "red_suit";
			this._color = "red_suit";
			this.flags = 8448;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "red_suit";
		}

		public Obj_Item_Clothing_Under_Librarian ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}