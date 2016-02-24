// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Bluespace : Obj_Item_Weapon_ReagentContainers_Glass_Beaker {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.materials = new ByTable().Set( "$glass", 5000 );
			this.volume = 300;
			this.possible_transfer_amounts = new ByTable(new object [] { 5, 10, 15, 20, 25, 30, 50, 100, 300 });
			this.icon_state = "beakerbluespace";
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Bluespace ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}