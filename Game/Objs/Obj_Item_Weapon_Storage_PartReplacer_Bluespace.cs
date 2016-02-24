// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_PartReplacer_Bluespace : Obj_Item_Weapon_Storage_PartReplacer {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.storage_slots = 400;
			this.max_combined_w_class = 800;
			this.works_from_distance = true;
			this.pshoom_or_beepboopblorpzingshadashwoosh = "sound/items/PSHOOM.ogg";
			this.alt_sound = "sound/items/PSHOOM_2.ogg";
			this.icon_state = "BS_RPED";
		}

		public Obj_Item_Weapon_Storage_PartReplacer_Bluespace ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: stock_parts.dm
		public override bool content_can_dump( dynamic dest_object = null, Mob user = null ) {
			
			if ( this.Adjacent( user ) ) {
				
				if ( Map13.GetDistance( user, dest_object ) < 8 ) {
					
					if ( ((Ent_Static)dest_object).storage_contents_dump_act( this, user ) ) {
						this.play_rped_sound();
						user.Beam( dest_object, "rped_upgrade", "icons/effects/effects.dmi", 5 );
						return true;
					}
				}
				user.WriteMsg( "The " + this.name + " buzzes." );
				GlobalFuncs.playsound( this, "sound/machines/buzz-sigh.ogg", 50, 0 );
			}
			return false;
		}

	}

}