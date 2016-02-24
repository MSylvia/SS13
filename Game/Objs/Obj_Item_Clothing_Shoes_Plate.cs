// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Plate : Obj_Item_Clothing_Shoes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 50 ).Set( "bullet", 50 ).Set( "laser", 50 ).Set( "energy", 40 ).Set( "bomb", 60 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.flags = 1024;
			this.cold_protection = 96;
			this.min_cold_protection_temperature = 2;
			this.heat_protection = 96;
			this.max_heat_protection_temperature = 1500;
			this.icon_state = "crusader";
		}

		public Obj_Item_Clothing_Shoes_Plate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: items.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( !GlobalFuncs.is_handofgod_cultist( user ) ) {
				Task13.User.WriteMsg( "Metal boots, they look heavy." );
			} else {
				Task13.User.WriteMsg( "Heavy boots that are blessed for sure footing.  You'll be safe from being taken down by the heresy that is the banana peel." );
			}
			return 0;
		}

	}

}