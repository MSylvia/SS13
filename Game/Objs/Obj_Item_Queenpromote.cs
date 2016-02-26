// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Queenpromote : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 130;
			this.icon = "icons/mob/alien.dmi";
			this.icon_state = "alien_medal";
		}

		public Obj_Item_Queenpromote ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: queen.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			user.WriteMsg( "<span class='noticealien'>You discard " + this + ".</span>" );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: queen.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			dynamic A = null;
			Mob_Living_Carbon_Alien_Humanoid_Royal_Praetorian new_prae = null;

			
			if ( !( M is Mob_Living_Carbon_Alien_Humanoid ) || M is Mob_Living_Carbon_Alien_Humanoid_Royal ) {
				user.WriteMsg( "<span class='noticealien'>You may only use this with your adult, non-royal children!</span>" );
				return false;
			}

			if ( GlobalFuncs.alien_type_present( typeof(Mob_Living_Carbon_Alien_Humanoid_Royal_Praetorian) ) ) {
				user.WriteMsg( "<span class='noticealien'>You already have a Praetorian!</span>" );
				return false;
			}
			A = M;

			if ( Lang13.Bool( A.stat ) == false && Lang13.Bool( A.mind ) && Lang13.Bool( A.key ) ) {
				
				if ( !((Mob_Living_Carbon)user).usePlasma( 500 ) ) {
					user.WriteMsg( "<span class='noticealien'>You must have 500 plasma stored to use this!</span>" );
					return false;
				}
				A.WriteMsg( "<span class='noticealien'>The queen has granted you a promotion to Praetorian!</span>" );
				((Ent_Static)user).visible_message( "<span class='alertalien'>" + A + " begins to expand, twist and contort!</span>" );
				new_prae = new Mob_Living_Carbon_Alien_Humanoid_Royal_Praetorian( A.loc );
				((Mind)A.mind).transfer_to( new_prae );
				GlobalFuncs.qdel( A );
				GlobalFuncs.qdel( this );
				return false;
			} else {
				user.WriteMsg( "<span class='warning'>This child must be alert and responsive to become a Praetorian!</span>" );
			}
			return false;
		}

	}

}