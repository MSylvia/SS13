// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paint_PaintRemover : Obj_Item_Weapon_Paint {

		public Obj_Item_Weapon_Paint_PaintRemover ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: paint.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( target is Tile && target.color != Lang13.Initial( target, "color" ) ) {
				target.color = Lang13.Initial( target, "color" );
			}
			return false;
		}

	}

}