// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Encryptionkey_Deathsquad : Obj_Item_Device_Encryptionkey {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.channels = new ByTable().Set( "Deathsquad", 1 ).Set( "Science", 1 ).Set( "Command", 1 ).Set( "Medical", 1 ).Set( "Engineering", 1 ).Set( "Security", 1 ).Set( "Mining", 1 ).Set( "Cargo", 1 );
			this.icon_state = "deathsquad_cypherkey";
		}

		public Obj_Item_Device_Encryptionkey_Deathsquad ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}