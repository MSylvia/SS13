// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Trackimp : Obj_Item_Weapon_Storage_Box {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "implant";
		}

		// Function from file: boxes.dm
		public Obj_Item_Weapon_Storage_Box_Trackimp ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, 4 )) {
				i = _a;
				
				new Obj_Item_Weapon_Implantcase_Tracking( this );
			}
			new Obj_Item_Weapon_Implanter( this );
			new Obj_Item_Weapon_Implantpad( this );
			new Obj_Item_Weapon_Locator( this );
			return;
		}

	}

}