// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Card_Data : Obj_Item_Weapon_Card {

		public string function = "storage";
		public string data = "null";
		public dynamic special = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "card-id";
			this.icon_state = "data";
		}

		public Obj_Item_Weapon_Card_Data ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cards_ids.dm
		[Verb]
		[VerbInfo( name: "Label Disk", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		[VerbArg( 1, InputType.Str )]
		public void label( dynamic t = null ) {
			
			if ( Task13.User.stat != 0 || !Task13.User.canmove || Task13.User.restrained() ) {
				return;
			}

			if ( Lang13.Bool( t ) ) {
				this.name = "data disk- '" + t + "'";
			} else {
				this.name = "data disk";
			}
			this.add_fingerprint( Task13.User );
			return;
		}

	}

}