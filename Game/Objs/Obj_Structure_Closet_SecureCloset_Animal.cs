// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Animal : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 45 });
		}

		// Function from file: medical.dm
		public Obj_Structure_Closet_SecureCloset_Animal ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Device_Assembly_Signaler( this );

			foreach (dynamic _a in Lang13.IterateRange( 1, 3 )) {
				i = _a;
				
				new Obj_Item_Device_Electropack( this );
			}
			return;
		}

	}

}