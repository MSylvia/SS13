// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Encryptionkey_Syndicate : Obj_Item_Device_Encryptionkey {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.channels = new ByTable().Set( "Syndicate", 1 );
			this.origin_tech = "syndicate=3";
			this.syndie = true;
		}

		public Obj_Item_Device_Encryptionkey_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}