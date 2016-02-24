// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Carpplushie_DehyCarp : Obj_Item_Toy_Carpplushie {

		public dynamic owner = null;
		public bool owned = false;

		public Obj_Item_Toy_Carpplushie_DehyCarp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: dehy_carp.dm
		public void Swell(  ) {
			Mob_Living_SimpleAnimal_Hostile_Carp C = null;
			dynamic factions = null;
			dynamic F = null;

			this.desc = "It's growing!";
			this.visible_message( "<span class='notice'>" + this + " swells up!</span>" );
			this.icon = "icons/mob/animal.dmi";
			Icon13.Flick( "carp_swell", this );
			Task13.Sleep( 6 );
			C = new Mob_Living_SimpleAnimal_Hostile_Carp( GlobalFuncs.get_turf( this ) );

			if ( Lang13.Bool( this.owner ) ) {
				factions = this.owner.faction;

				foreach (dynamic _a in Lang13.Enumerate( factions )) {
					F = _a;
					

					if ( F == "neutral" ) {
						factions -= F;
					}
				}
				C.faction = factions;
			}

			if ( !Lang13.Bool( this.owner ) || this.owner.faction != C.faction ) {
				this.visible_message( "<span class='warning'>You have a bad feeling about this.</span>" );
			} else {
				this.visible_message( "<span class='notice'>The newly grown carp looks up at you with friendly eyes.</span>" );
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: dehy_carp.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( target is Obj_Structure_Sink ) {
				user.drop_item();
				this.loc = GlobalFuncs.get_turf( target );
				this.Swell(); return false;
			}
			base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
			return false;
		}

		// Function from file: dehy_carp.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.add_fingerprint( user );

			if ( !this.owned ) {
				user.WriteMsg( "<span class='notice'>You pet " + this + ". You swear it looks up at you.</span>" );
				this.owner = user;
				this.owned = true;
			}
			return base.attack_self( (object)(user), (object)(flag), emp );
		}

	}

}