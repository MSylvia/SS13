// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Snowball : Obj_Item_Toy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.throwforce = 12;
			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "snowball";
		}

		public Obj_Item_Toy_Snowball ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: toys.dm
		public override bool throw_impact( dynamic target = null, Mob_Living_Carbon thrower = null ) {
			
			if ( !base.throw_impact( (object)(target), thrower ) ) {
				GlobalFuncs.playsound( this, "sound/effects/pop.ogg", 20, 1 );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: toys.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			user.drop_item();
			this.throw_at( target, this.throw_range, this.throw_speed );
			return false;
		}

	}

}