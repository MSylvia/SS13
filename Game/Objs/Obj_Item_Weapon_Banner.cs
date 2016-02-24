// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Banner : Obj_Item_Weapon {

		public int moralecooldown = 0;
		public int moralewait = 600;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "banner";
			this.icon_state = "banner";
		}

		public Obj_Item_Weapon_Banner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: items.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string side = null;
			Mob_Living_Carbon_Human H = null;

			
			if ( this.moralecooldown + this.moralewait > Game13.time ) {
				return null;
			}
			side = "";

			if ( GlobalFuncs.is_handofgod_redcultist( user ) ) {
				side = "red";
			} else if ( GlobalFuncs.is_handofgod_bluecultist( user ) ) {
				side = "blue";
			}

			if ( !Lang13.Bool( side ) ) {
				return null;
			}
			user.WriteMsg( "<span class='notice'>You increase the morale of your fellows!</span>" );
			this.moralecooldown = Game13.time;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( GlobalFuncs.get_turf( this ), 4 ), typeof(Mob_Living_Carbon_Human) )) {
				H = _a;
				

				if ( side == "red" && GlobalFuncs.is_handofgod_redcultist( H ) || side == "blue" && GlobalFuncs.is_handofgod_bluecultist( H ) ) {
					H.WriteMsg( "<span class='notice'>Your morale is increased by " + user + "'s banner!</span>" );
					H.adjustBruteLoss( -15 );
					H.adjustFireLoss( -15 );
					H.AdjustStunned( -2 );
					H.AdjustWeakened( -2 );
					H.AdjustParalysis( -2 );
				}
			}
			return null;
		}

	}

}