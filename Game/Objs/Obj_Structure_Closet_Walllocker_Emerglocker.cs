// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Walllocker_Emerglocker : Obj_Structure_Closet_Walllocker {

		public ByTable spawnitems = new ByTable(new object [] { typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), typeof(Obj_Item_Clothing_Mask_Breath), typeof(Obj_Item_Weapon_Crowbar) });
		public int amount = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "emerg";
		}

		public Obj_Structure_Closet_Walllocker_Emerglocker ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: walllocker.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic path = null;

			
			if ( a is Mob_Living_Silicon_Ai ) {
				return null;
			}

			if ( !( this.amount != 0 ) ) {
				GlobalFuncs.to_chat( Task13.User, "<spawn class='notice'>It's empty." );
				return null;
			}

			if ( this.amount != 0 ) {
				GlobalFuncs.to_chat( Task13.User, new Txt( "<spawn class='notice'>You take out some items from " ).the( this ).item().str( "." ).ToString() );

				foreach (dynamic _a in Lang13.Enumerate( this.spawnitems )) {
					path = _a;
					
					Lang13.Call( path, this.loc );
				}
				this.amount--;
			}
			return null;
		}

	}

}