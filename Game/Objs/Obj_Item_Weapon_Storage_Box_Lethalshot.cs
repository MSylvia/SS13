// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Lethalshot : Obj_Item_Weapon_Storage_Box {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "lethalshot_box";
		}

		// Function from file: boxes.dm
		public Obj_Item_Weapon_Storage_Box_Lethalshot ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_AmmoCasing_Shotgun_Buckshot( this );
			new Obj_Item_AmmoCasing_Shotgun_Buckshot( this );
			new Obj_Item_AmmoCasing_Shotgun_Buckshot( this );
			new Obj_Item_AmmoCasing_Shotgun_Buckshot( this );
			new Obj_Item_AmmoCasing_Shotgun_Buckshot( this );
			new Obj_Item_AmmoCasing_Shotgun_Buckshot( this );
			new Obj_Item_AmmoCasing_Shotgun_Buckshot( this );
			return;
		}

	}

}