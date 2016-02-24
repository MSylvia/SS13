// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gavelhammer : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 5;
			this.throwforce = 6;
			this.w_class = 2;
			this.attack_verb = new ByTable(new object [] { "bashed", "battered", "judged", "whacked" });
			this.burn_state = 0;
			this.icon_state = "gavelhammer";
		}

		public Obj_Item_Weapon_Gavelhammer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: courtroom.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " has sentenced " ).himself_herself_itself_themself().str( " to death with the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			GlobalFuncs.playsound( this.loc, "sound/items/gavel.ogg", 50, 1, -1 );
			return 1;
		}

	}

}