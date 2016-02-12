// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimefire : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime fire";
			this.id = "m_fire";
			this.required_reagents = new ByTable().Set( "plasma", 5 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Orange);
			this.required_other = true;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			dynamic location = null;
			Tile_Simulated_Floor target_tile = null;
			GasMixture napalm = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + GlobalFuncs.replacetext( this.name, " ", "_" ) );

			if ( !( holder.my_atom.loc is Obj_Item_Weapon_Grenade_ChemGrenade ) ) {
				holder.my_atom.visible_message( "<span class='warning'>The slime extract begins to vibrate violently !</span>" );
				this.send_admin_alert( holder, "orange slime + plasma (Napalm)" );
				Task13.Sleep( 50 );
			} else {
				this.send_admin_alert( holder, "orange slime + plasma (Napalm)in a grenade" );
			}
			location = GlobalFuncs.get_turf( holder.my_atom.loc );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( location, 0 ), typeof(Tile_Simulated_Floor) )) {
				target_tile = _a;
				
				napalm = new GasMixture();
				napalm.toxins = 25;
				napalm.temperature = 1400;
				target_tile.assume_air( napalm );
				Task13.Schedule( 0, (Task13.Closure)(() => {
					target_tile.hotspot_expose( 700, 400, null, true );
					return;
				}));
			}
			return;
		}

	}

}