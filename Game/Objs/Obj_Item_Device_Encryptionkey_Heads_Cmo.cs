// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Encryptionkey_Heads_Cmo : Obj_Item_Device_Encryptionkey_Heads {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.channels = new ByTable().Set( "Medical", 1 ).Set( "Command", 1 );
			this.icon_state = "cmo_cypherkey";
		}

		public Obj_Item_Device_Encryptionkey_Heads_Cmo ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}