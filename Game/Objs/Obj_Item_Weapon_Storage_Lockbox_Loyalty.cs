// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Lockbox_Loyalty : Obj_Item_Weapon_Storage_Lockbox {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 1 });
		}

		// Function from file: lockbox.dm
		public Obj_Item_Weapon_Storage_Lockbox_Loyalty ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, 3 )) {
				i = _a;
				
				new Obj_Item_Weapon_Implantcase_Loyalty( this );
			}
			new Obj_Item_Weapon_Implanter_Loyalty( this );
			return;
		}

	}

}