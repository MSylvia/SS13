// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Medical2 : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 45 });
		}

		// Function from file: medical.dm
		public Obj_Structure_Closet_SecureCloset_Medical2 ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;
			double i2 = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, 3 )) {
				i = _a;
				
				new Obj_Item_Weapon_Tank_Internals_Anesthetic( this );
			}

			foreach (dynamic _b in Lang13.IterateRange( 1, 3 )) {
				i2 = _b;
				
				new Obj_Item_Clothing_Mask_Breath_Medical( this );
			}
			return;
		}

	}

}