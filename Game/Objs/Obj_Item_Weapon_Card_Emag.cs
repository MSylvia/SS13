// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Card_Emag : Obj_Item_Weapon_Card {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "card-id";
			this.origin_tech = "magnets=2;syndicate=2";
			this.flags = 4;
			this.icon_state = "emag";
		}

		public Obj_Item_Weapon_Card_Emag ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cards_ids.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic A = null;

			A = target;

			if ( !( proximity_flag == true ) ) {
				return false;
			}
			((Ent_Static)A).emag_act( user );
			return false;
		}

		// Function from file: cards_ids.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			return false;
		}

	}

}