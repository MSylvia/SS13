// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Slimepotion_Speed : Obj_Item_Slimepotion {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/chemical.dmi";
			this.icon_state = "bottle3";
		}

		public Obj_Item_Slimepotion_Speed ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: xenobiology.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic I = null;
			dynamic V = null;

			base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );

			if ( !( target is Obj ) ) {
				user.WriteMsg( "<span class='warning'>The potion can only be used on items or vehicles!</span>" );
				return false;
			}

			if ( target is Obj_Item ) {
				I = target;

				if ( Convert.ToDouble( I.slowdown ) <= 0 ) {
					user.WriteMsg( "<span class='warning'>The " + target + " can't be made any faster!</span>" );
					return base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
				}
				I.slowdown = 0;
			}

			if ( target is Obj_Vehicle ) {
				V = target;

				if ( V.vehicle_move_delay <= 0 ) {
					user.WriteMsg( "<span class='warning'>The " + target + " can't be made any faster!</span>" );
					return base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
				}
				V.vehicle_move_delay = 0;
			}
			user.WriteMsg( "<span class='notice'>You slather the red gunk over the " + target + ", making it faster.</span>" );
			target.color = "#FF0000";
			GlobalFuncs.qdel( this );
			return false;
		}

	}

}