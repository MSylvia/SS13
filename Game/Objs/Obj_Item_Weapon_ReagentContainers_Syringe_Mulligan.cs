// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Syringe_Mulligan : Obj_Item_Weapon_ReagentContainers_Syringe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.amount_per_transfer_from_this = 1;
			this.volume = 1;
			this.list_reagents = new ByTable().Set( "mulligan", 1 );
		}

		public Obj_Item_Weapon_ReagentContainers_Syringe_Mulligan ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}