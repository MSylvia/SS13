// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Fedora : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "fedora";
			this.icon_state = "fedora";
		}

		public Obj_Item_Clothing_Head_Fedora ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: misc.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			Mob_Living_Carbon_Human H = null;

			
			if ( user.gender == GlobalVars.FEMALE ) {
				return 0;
			}
			H = user;
			user.visible_message( "<span class='suicide'>" + user + " is donning " + this + "! It looks like they're trying to be nice to girls.</span>" );
			user.say( "M'lady." );
			Task13.Sleep( 10 );
			H.facial_hair_style = "Neckbeard";
			return 1;
		}

	}

}